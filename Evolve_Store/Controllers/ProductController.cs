using AutoMapper;
using Evolve_Store.Helpers;
using Evolve_Store.Helpers.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Domain;
using Store.Domain.DTOs;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.Domain.Specification;
using Store.Domain.Specification.ProductSpecification;
using static StackExchange.Redis.Role;

namespace Evolve_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IMapper mapper ,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [CachedAttribute(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetAllProducts([FromQuery]ProductSpecParams Params)
        {
            var spec = new ProductWithImagesSpecifications(Params);
            var products = await _unitOfWork.Reposit<Product>().GetAllWithSpecAsync(spec);
            var CountSpec = new ProductWithSpecForCount(Params);
            var Count = await _unitOfWork.Reposit<Product>().GetCountWithSpecAsync(CountSpec);
            var productDtos = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products.ToList());
            return Ok(new Pagination<ProductDto>(Params.Pagesize, Params.PageIndex, productDtos, Count));
        }


        [HttpGet("product/{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status404NotFound)]       
        public async Task<IActionResult> GetProductById(int id)
        {
            var spec = new ProductWithImagesSpecifications(id);
            var product= await _unitOfWork.Reposit<Product>().GetByIdWithSpecAsync(spec);
            if (product is null) return NotFound(new ApiResponce(404));
            var productDtos = _mapper.Map<ProductDto>(product);
            return Ok(productDtos); 
        }


         

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var spec = new CategoryWithProductsByIdSpec(id);
            var Categories = await _unitOfWork.Reposit<Category>().GetByIdWithSpecAsync(spec);
            if (Categories is null) return NotFound(new ApiResponce(404));
            var CategoryDtos = _mapper.Map<CategoryDto>(Categories);
            return Ok(CategoryDtos);
        }



      



    }
}
