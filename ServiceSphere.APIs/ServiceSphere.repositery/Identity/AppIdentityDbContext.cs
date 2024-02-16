using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.core.Entities.Identity;

public class AppIdentityDbContext : IdentityDbContext<AppUser>   
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {

    }
    // If you have additional DbSets, define them here
}
