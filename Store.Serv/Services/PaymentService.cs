using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Store.Domain;
using Store.Domain.Models;
using Store.Domain.Models.Cart_Models;
using Store.Domain.Models.Order_Models;
using Store.Domain.Services;
using Stripe;
using Product = Store.Domain.Models.Product;

namespace Store.Serv.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IConfiguration configuration,
            IBasketRepository basketRepository,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserBasket?> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeKeys:Secretkey"];

            var basket = await  _basketRepository.GetBasketAsync(basketId);
            if (basket is null) return null;

            var shippingPrice = 0m; //decimal
            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.Reposit<DeliveryMethod>().GetByIdAsync(basket.DeliveryMethodId.Value);
                shippingPrice = deliveryMethod.Cost;
            }

            if(basket.Items.Count > 0)
            {
                 foreach (var item in basket.Items)
                {
                    var productItem = await _unitOfWork.Reposit<Product>().GetByIdAsync(item.ProductId);
                    if (item.Price != productItem.Price)
                    {   
                        item.Price = productItem.Price;
                    }
                }
            }

            var subtotal = basket.Items.Sum(i => i.Price * i.Quantity);

            //create payment intent service
            var service = new PaymentIntentService();
            if(string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long) (subtotal * 100 + (shippingPrice * 100)), //in cents
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                var intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)(subtotal * 100 + (shippingPrice * 100)), //in cents
                };
                var intent = await service.UpdateAsync(basket.PaymentIntentId, options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }

            await _basketRepository.UpdateBasketAsync(basket);
            return basket;

        }
    }
}
