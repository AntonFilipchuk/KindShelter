using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly ShelterContext _context;

        public BuggyController(ShelterContext context)
        {
            _context = context;
        }

        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(999);
            if (thing is null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            //Response comes from ExceptionMiddleware
            var thing = _context.Products.Find(999);

            var toReturn = thing!.ToString();
            return Ok();
        }

        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
    }
}
