using Lab07.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext với chuỗi kết nối
builder.Services.AddDbContext<ProductManagementContextcs>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreString")));



// Add services to the container.
builder.Services.AddControllersWithViews();


// C?u hình s? d?ng session
builder.Services.AddDistributedMemoryCache();

// ??ng ký d?ch v? cho HttpContextAccessor
builder.Services.AddHttpContextAccessor();
// C?u hình s? d?ng session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "DevXuongMoc";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();