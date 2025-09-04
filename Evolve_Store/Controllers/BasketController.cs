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
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepo,
            IMapper mapper )
        {
            _basketRepo = basketRepo;
            _mapper = mapper;
        }




        [HttpGet("{basketId}")]
        public async Task<ActionResult<UserBasket>> GetBasket(string basketId)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);
            return basket ?? new UserBasket(basketId);
        }



        [HttpPost]
        public async Task<ActionResult<UserBasketDto>> UpdateBasket(UserBasketDto basket)
        {
            var MappedBasket = _mapper.Map<UserBasketDto, UserBasket >(basket);
            var updatedBasket = await _basketRepo.UpdateBasketAsync(MappedBasket);
            if (updatedBasket is null) return BadRequest(new ApiResponce(400));
            return Ok(updatedBasket);
        }



        [HttpDelete("{basketId}")]
        public async Task<IActionResult> DeleteBasket(string basketId)
        {
            var deleted = await _basketRepo.DeleteBasketAsync(basketId);
            if (!deleted) return NotFound();
            return Ok("Delete");
        }
    }
}
