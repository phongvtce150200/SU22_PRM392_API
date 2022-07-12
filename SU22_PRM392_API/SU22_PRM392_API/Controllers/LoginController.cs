using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SU22_PRM392_API.Database;
using SU22_PRM392_API.RequestRespone;
using System.Linq;

namespace SU22_PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            var check = _context.users.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
            if (check == null) return BadRequest(new { Response = "Wrong Username or Password please try again" });

            bool isAdmin = check.IsAdmin;

            return Ok(new { Response = "Login Successfully!" + isAdmin});
        }
    }
}
