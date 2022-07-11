using Microsoft.AspNetCore.Mvc;
using SU22_PRM392_API.Database;
using SU22_PRM392_API.Models;
using SU22_PRM392_API.RequestRespone;
using System.Linq;

namespace SU22_PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterRequest register)
        {
            var checkduplicate = _context.users.FirstOrDefault(x => x.UserName == register.UserName);
            if (checkduplicate != null) return BadRequest(new { Response = "UserName is already exists!" });
            if (register.ConfirmPassword.Equals(register.Password) == true)
            {
                try
                {
                    var user = new User()
                    {
                        UserName = register.UserName,
                        Password = register.Password,
                        Email = register.Email,
                        FullName = register.FullName,
                        PhoneNumber = register.PhoneNumber,
                        Address = register.Address,
                    };
                    _context.users.Add(user);
                    _context.SaveChanges();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok(new { Response = "Account has been create successfully"});
        }
    }
}
