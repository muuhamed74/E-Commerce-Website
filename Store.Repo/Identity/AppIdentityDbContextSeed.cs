using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.Domain.Models.Identity;

namespace Store.Repo.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            if (!userManager.Users.Any())
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var newuser = new Appuser()
                {
                    Name = "Mohamed Hesham",
                    Email = "mohamedelhanafy290@gmail.com",
                    UserName = "mohamedelhanafy290"
                };
                var result = await userManager.CreateAsync(newuser, "Pa$$w0rd");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newuser, "Admin");
                }
            }
        }
    }
}
