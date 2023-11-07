using DMS.az.DAL;
using DSM.az.Models;
using DSM.az.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSingleton<IFileService, FileService>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = options.Events.OnRedirectToAccessDenied = context =>
    {
        if (context.HttpContext.Request.Path.Value.StartsWith("/admin") || context.HttpContext.Request.Path.Value.StartsWith("/Admin"))
        {
            var redirectPath = new Uri(context.RedirectUri);
            context.Response.Redirect("/admin/account/login" + redirectPath.Query);
        }
        else
        {
            var redirectPath = new Uri(context.RedirectUri);
            context.Response.Redirect("/account/login" + redirectPath.Query);
        }
        return Task.CompletedTask;
    };

});

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roloManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    await DbInitializer.SeedAsync(roloManager, userManager);
}

app.Run();
