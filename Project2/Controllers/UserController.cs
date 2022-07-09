using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Database;
using Project2.DTO;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbContext> _userManager;
        private readonly SignInManager<ApplicationDbContext> _signInManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationDbContext> userManager,SignInManager<ApplicationDbContext> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO modelView)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }
                var result = await _userManager.ChangePasswordAsync(user, modelView.CurrentPassword, modelView.NewPassword);
                if (!result.Succeeded)
                {
                    return BadRequest();
                }
                await _signInManager.RefreshSignInAsync(user);
                return Ok();
            }
            return BadRequest();
        }

    }
}
