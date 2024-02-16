using Microsoft.AspNetCore.Identity;
using ServiceSphere.core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            if (!await roleManager.RoleExistsAsync("Client"))
            {
                await roleManager.CreateAsync(new IdentityRole("Client"));
            }
            if (!await roleManager.RoleExistsAsync("Freelancer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Freelancer"));
            }
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "AhmedNasr",
                    Email = "ahmed.nasr@linkdev.com",
                    UserName = "ahmed.nasr",
                    PhoneNumber = "01003106487"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
    }
}
