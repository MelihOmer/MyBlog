using Microsoft.AspNetCore.Identity;
using MyBlog.Data;
using MyBlog.Data.Context;
using MyBlog.Entity.Entities;
using MyBlog.Services;
using NToastNotify;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddServicesLayer();
builder.Services.AddSession();
builder.Services.AddIdentity<AppUser, AppRole>(opt => // Kullanıcı Hesabı(Account) şartlar-kriterler bu options parametresi ile belli ediliyor.
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<BlogDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config => // Browserde yönetilen cookie bilgileri girilmektedir. Örn Yetkisiz kullanıcının yönlendirileceği path.
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name ="MyBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/Logout/AccessDenied");
});

builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();


app.UseAuthentication(); //Middle Ware yapısında sıra ile çalıştığı için sistem giriş yetkiden önce kontrol edilmeli.
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"); => MapDefaultControllerRoute

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName : "Admin",
        pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
