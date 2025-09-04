using Evolve_Store.Helpers.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Models;
using Store.Repo;

namespace Evolve_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

       

        [HttpGet("NotFound")]
        public ActionResult GetNotFountRequest( ) 
        {
            var Product = _context.Product.Find(100);
            if (Product is null)
            return NotFound(new ApiResponce(404));
            return Ok(Product);
        }
            


        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            var Product = _context.Product.Find(100);
            var ProductToReturn = Product.ToString();
            return Ok(ProductToReturn);
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        { 
            return BadRequest(new ApiResponce(400));
        }


        [HttpGet("BadRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(new ApiResponce(400));
        }



    }
}
