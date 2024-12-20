// Add services to the container.
﻿using Microsoft.EntityFrameworkCore;
using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Repositories;
using SWD392_Meraki_Web.Repositories.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using SWD392_Meraki_Web.Services.Interface;
using SWD392_Meraki_Web.Services; // Thêm namespace này

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.LogoutPath = "/auth/logout"; // Đường dẫn logout
    p.SlidingExpiration = true;
})
.AddGoogle(p =>
{
    p.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new Exception("Not found ClientId");
    p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new Exception("Not found ClientSecret");
});


builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICourtRepository, CourtRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddHttpContextAccessor();  
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();


builder.Services.AddDbContext<BookingBadmintonContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("BookingBadminton")));
builder.Services.AddDistributedMemoryCache(); // Necessary for session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();
app.UseAuthentication();  


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//// Cấu hình authentication cho Cookie
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/auth/login"; // Đường dẫn khi người dùng chưa đăng nhập
//        options.LogoutPath = "/auth/logout"; // Đường dẫn logout
//        options.SlidingExpiration = true;
//    });
///*.AddGoogle(p =>
// {
//     p.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new Exception("Not found ClientId");
//     p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new Exception("Not found ClientSecret");
// });*/