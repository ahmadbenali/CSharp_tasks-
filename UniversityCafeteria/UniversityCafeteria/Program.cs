using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Data;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CafeteriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<EmployeesDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection")));

// Identity: uses the existing Identity tables (AspNetUsers, AspNetRoles, AspNetUserRoles)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = ""; // the user name is the full name, so spaces are allowed
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();      // where session data is kept
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cafeteria}/{action=Index}/{id?}")
    .WithStaticAssets();

// Create the 3 roles and one SuperAdmin account if they do not exist yet
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    foreach (var roleName in new[] { "User", "Admin", "SuperAdmin" })
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    if (await userManager.FindByEmailAsync("superadmin@cafeteria.com") == null)
    {
        var superAdmin = new IdentityUser
        {
            UserName = "Super Admin",
            Email = "superadmin@cafeteria.com"
        };
        var result = await userManager.CreateAsync(superAdmin, "SuperAdmin@123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
        }
    }
}

app.Run();
