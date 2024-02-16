using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceSphere.APIs.Extensions;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Repositeries.contract;
using ServiceSphere.core.Services.contract;
using ServiceSphere.repositery;
using ServiceSphere.repositery.Data;
using ServiceSphere.repositery.Identity;
using ServiceSphere.services;
//using ServiceSphere.repositery.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ServiceSphereContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddApplicationServices();
builder.Services.AddSwaggerServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDbContext<AppIdentityDbContext>(OptionsBuilder =>
{
    OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});
builder.Services.AddScoped<NotificationService>();


var app = builder.Build();
#region Update database

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var LoggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    var dbcontext = services.GetRequiredService<ServiceSphereContext>();
    await dbcontext.Database.MigrateAsync();
    await ServiceSphereDbContextSeeding.DataSeed(dbcontext);

    var _IdentityDbContext = services.GetRequiredService<AppIdentityDbContext>();
    await _IdentityDbContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = LoggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "Update database error");
}

#endregion
var _userManager = services.GetRequiredService<UserManager<AppUser>>();
var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
await AppIdentityDbContextSeed.SeedUserAsync(_userManager,_roleManager);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerMiddlewares();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
