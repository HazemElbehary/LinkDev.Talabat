using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controllers.Controllers
{
    public class BuggyController : BaseApiController
    {

        [HttpGet("notFound")] // GET: /api/buggy/notFound
        public IActionResult GetNotFoundRequest()
        {
            return NotFound(new {StatusCode = 404, message = "Not Found"}); // 404
        }

        [HttpGet("serverError")] // GET: /api/buggy/serverError
		public IActionResult GetServerError()
        {
            throw new Exception(); // 500
        }

        [HttpGet("badRequest")] // GET: /api/buggy/badRequest
		public IActionResult GetBadRequest()
        {
            return BadRequest(new { StatusCode = 400, message = "Bad Request" }); // 400
        }

        [HttpGet("unathorizedError")] // // GET: /api/buggy/unathorizedError
		public IActionResult GetUnAuthorizedError()
        {
            return Unauthorized(new { StatusCode = 401, message = "unAuthorized" });
        }

        [HttpGet("validationError/{id}")] // // GET: /api/buggy/validationError/Five
		public IActionResult GetValidationError(int id)
        {
            return Ok();
        }

        [HttpGet("foribidden")] // GET: /api/buggy/foribidden
		public IActionResult GetForbiddenRequest()
        {
            return Forbid();
        }

        [HttpGet("unAuthorizedRequest")] // GET: /api/buggy/unAuthorizedRequest
		[Authorize]
        public IActionResult GetAuhtorizedRequest()
        {
            return Ok();
        }
	}
}
