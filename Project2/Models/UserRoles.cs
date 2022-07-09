using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public static async Task CreateRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create all Role for System
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

        }
    }
}
