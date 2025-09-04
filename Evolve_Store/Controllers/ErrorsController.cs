﻿using Evolve_Store.Helpers.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolve_Store.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponce(code))
            {
                StatusCode = code
            };
        }
    }
}
