using Project2.Models;
using Project2.ResponeRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public RegisterController(UserManager<User> userManager,  RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = userManager;
            _rolemanager = rolemanager;
            
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            await UserRoles.CreateRolesAsync(_usermanager,_rolemanager);
            var user = new User()
            {
                UserName = register.UserName,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                PhoneNumber = register.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _usermanager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _usermanager.AddToRoleAsync(user, "Customer");
                return Ok();
            }
            return BadRequest();
        }
    }
}
