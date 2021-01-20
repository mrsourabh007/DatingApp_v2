using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        public DataContext _context { get; set; }
        public BuggyController(DataContext context)
        {
            _context = context;

        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret Text";
        }
        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            var t = _context.Users.Find(-1);
            if (t == null) return NotFound();
            return Ok(t);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var t = _context.Users.Find(-1);
            var tToReturn = t.ToString();
            return tToReturn;
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is not a good request");
        }

    }
}