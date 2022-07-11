using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SU22_PRM392_API.Database;
using SU22_PRM392_API.RequestRespone;
using System.Linq;

namespace SU22_PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChangePasswordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ChangePassword(string UserName, [FromBody] ChangePasswordRequest changepassword)
        {
            var check = _context.users.FirstOrDefault(x => x.UserName == UserName);
            if (check == null)
            {
                return BadRequest(new { Response = "User invalid" });
            }
            else
            {
                if (check.Password == changepassword.CurrentPassword)
                {
                    if (changepassword.NewPassword.Equals(changepassword.ConfrimPassword) == true)
                    {
                        check.Password = changepassword.NewPassword;
                        _context.users.Update(check);
                        _context.SaveChanges();
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest(new { Response = "Wrong current password" });
                }

            }
            return BadRequest(new { Response = "Confirm password doesn't matching with password"}); 
        }
    }
}
