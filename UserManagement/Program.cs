using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


// DI
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
name: "default",
pattern: "{controller=Account}/{action=Login}/{id?}");
app.MapRazorPages();

app.Run();
