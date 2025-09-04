using AutoMapper;
using Evolve_Store.Helpers.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.DTOs.Cart;
using Store.Domain.Models.Cart_Models;
using Store.Domain.Services;

namespace Evolve_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        public PaymentsController(IPaymentService paymentService,
            IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }



        //creat or update payment intent
        [ProducesResponseType(typeof(UserBasketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserBasketDto>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            if (basket == null) return BadRequest(new { Error = "Problem with your basket" });
            var mappedBasket = _mapper.Map<UserBasket , UserBasketDto>(basket);
            return Ok(mappedBasket);
        }
    }
}
