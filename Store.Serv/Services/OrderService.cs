using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Models;
using Store.Domain.Models.Order_Models;
using Store.Domain.Services;
using Store.Domain.Specification.OrderSpec;

namespace Store.Serv.Services
{
    public class OrderService : IOrderService
    {
        private  readonly IBasketRepository _BasketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public OrderService(IBasketRepository basketRepository,
                           IUnitOfWork unitOfWork,
                           IPaymentService paymentService) 
        {
            _BasketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }


        public async Task<Order?> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //1.Get Basket From Basket Repo

            var basket = await _BasketRepository.GetBasketAsync(basketId);

            //2.Get Selected Items at Basket From Product Repo

            var orderItems = new List<OrderItems>();
            if (basket?.Items.Count > 0)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _unitOfWork.Reposit<Product>().GetByIdAsync(item.ProductId);
                    var imageUrl = product.Images?.FirstOrDefault()?.ImagePath;
                    var ProductItemOrdered = new ProductItemOrder(product.Id, product.Name, imageUrl);
                    var orderItem = new OrderItems(ProductItemOrdered, item.Quantity, product.Price);
                    orderItems.Add(orderItem);
                }
            }

            //3.Calculate SubTotal

            var subtotal = orderItems.Sum(item => item.Price * item.Quantity);

            //4.Get Delivery Method From DeliveryMethod Repo

            var deliveryMethod = await _unitOfWork.Reposit<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            //5.Create Order
            var spec = new OrderSpecification(basket.PaymentIntentId);
            var existingOrder = await _unitOfWork.Reposit<Order>().GetByIdWithSpecAsync(spec); 
            if (existingOrder != null) {
                _unitOfWork.Reposit<Order>().DeleteAsync(existingOrder);
                await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            }

            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, orderItems, subtotal , basket.PaymentIntentId);

            //6.Add Order Locally

            await _unitOfWork.Reposit<Order>().AddAsync(order);

            //7.Save Order To Database 

             var Result = await _unitOfWork.CompleteAsync();
             if (Result <= 0) return null;

             return order;
        }

        public Task<Order> GetOrderByIdForSpecificUserAsync(int OrderId, string buyerEmail)
        {
            var spec = new OrderSpecification(OrderId, buyerEmail);
            var order =  _unitOfWork.Reposit<Order>().GetByIdWithSpecAsync(spec);
            return order;

        }

        public async Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string buyerEmail)
        {
            var spec = new OrderSpecification(buyerEmail);
            var Orders = await _unitOfWork.Reposit<Order>().GetAllWithSpecAsync(spec);
            return Orders.ToList();

        }


        public async Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodsAsync()
        {
            var deliveryMethods = await _unitOfWork.Reposit<DeliveryMethod>().GetAllAsync();
            return deliveryMethods.ToList();
        }
    }
}
