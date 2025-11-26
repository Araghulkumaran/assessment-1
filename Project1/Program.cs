using Microsoft.AspNetCore.Authentication.Cookies;
using Project1.Data;
using Project1.Filters;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

// Register Dapper Helper
builder.Services.AddSingleton<DapperHelper>();

// Register Basic Auth Filter
builder.Services.AddScoped<BasicAuthAttribute>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllers();

app.Run();
