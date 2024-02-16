using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.core.Entities.Identity;
using System.Security.Claims;

namespace ServiceSphere.APIs.Extensions
{
    public static class UserManagerExtentions
    {
        public static async Task<AppUser?> FindUserWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal User)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(u=>u.Address).SingleOrDefaultAsync(u=> u.Email == Email);
            return user;
        }
    }
}
