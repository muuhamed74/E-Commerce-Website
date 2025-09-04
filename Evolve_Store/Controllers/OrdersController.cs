using System.Security.Claims;
using AutoMapper;
using Evolve_Store.Helpers.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Encodings;
using Store.Domain.DTOs.Identity;
using Store.Domain.DTOs.Orders;
using Store.Domain.Models.Identity;
using Store.Domain.Models.Order_Models;
using Store.Domain.Services;

namespace Evolve_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService,
                                IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }




        
        [ProducesResponseType(typeof(ApiResponce) , StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Order) , StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var BuyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var MappingOrder = _mapper.Map<AddressDto , Address>(orderDto.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(BuyerEmail, orderDto.DeliveryMethodId, orderDto.BasketId, MappingOrder);
            if (order == null) return BadRequest(new ApiResponce(400, "Problem Creating Order"));
                return Ok(order);
        }


        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyList<OrderToReturnDto>), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
        {
            var BuyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderService.GetOrdersForSpecificUserAsync(BuyerEmail);
            if (orders == null) return BadRequest(new ApiResponce(400, "Problem Getting Orders For User"));
            var ordersToReturn = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders);
            return Ok(ordersToReturn);
        }




        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OrderToReturnDto), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
        {
            var BuyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var order = await _orderService.GetOrderByIdForSpecificUserAsync(id, BuyerEmail);
            if (order == null) return BadRequest(new ApiResponce(400, "Problem Getting Order For User"));
            var orderToReturn = _mapper.Map<Order, OrderToReturnDto>(order);
            return Ok(orderToReturn);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetAllDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }
    }
}
