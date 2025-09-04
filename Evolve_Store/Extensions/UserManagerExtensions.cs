using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models.Identity;
using Store.Serv.Services;
using System.Security.Claims;

namespace Evolve_Store.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<Appuser?> FindUserWithAddressAsync(this UserManager<Appuser> userManager, ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users
                .Include(u => u.Adress)
                .FirstOrDefaultAsync(u => u.Email == email);
            
            
            
            
            
            return user;

            
        }
    }
}
