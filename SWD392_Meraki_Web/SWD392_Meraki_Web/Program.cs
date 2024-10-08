using Microsoft.EntityFrameworkCore;
using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Repositories;
using SWD392_Meraki_Web.Repositories.Interface;
using Microsoft.AspNetCore.Authentication.Cookies; // Thêm namespace này

var builder = WebApplication.CreateBuilder(args);

// Cấu hình authentication cho Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/login"; // Đường dẫn khi người dùng chưa đăng nhập
        options.LogoutPath = "/auth/logout"; // Đường dẫn logout
        options.SlidingExpiration = true;
    });
/*.AddGoogle(p =>
 {
     p.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new Exception("Not found ClientId");
     p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new Exception("Not found ClientSecret");
 });*/
// Cấu hình các dịch vụ cho Repository và DbContext
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICourtRepository, CourtRepository>();
builder.Services.AddHttpContextAccessor();  // Cung cấp HttpContext trong các service
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

// Cấu hình DbContext với kết nối tới SQL Server
builder.Services.AddDbContext<BookingBadmintonContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("BookingBadminton")));

var app = builder.Build();

// Cấu hình môi trường (Development vs Production)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();  // Đảm bảo mọi kết nối đều được chuyển hướng sang HTTPS
app.UseStaticFiles();  // Dùng để phục vụ các tài nguyên tĩnh như CSS, JS

app.UseRouting();

// Cấu hình middleware cho Authentication và Authorization
app.UseAuthentication();  // Xác thực người dùng
app.UseAuthorization();   // Phân quyền người dùng

// Cấu hình các route controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
