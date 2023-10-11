using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Repository;
using TestProject.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using TestProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnection")
    ));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient<IEmailSender, clsEmailConfirm>();
//builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddTransient<IunitOfwork, MyUnitOfwork>();
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

//app.MapControllerRoute(
  //  name: "area",
  //  pattern: "{area=exist}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages(); // This maps Razor Pages
                               // You can add additional endpoints here for MVC controllers, API controllers, etc.
});

app.Run();
