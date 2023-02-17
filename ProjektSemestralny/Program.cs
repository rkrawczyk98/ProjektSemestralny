using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Areas.Identity.Data;
using ProjektSemestralny.Controllers;
using System.ServiceProcess;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AplicationDBContextConnection' not found.");

builder.Services.AddDbContext<AplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AplicationDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();

app.UseAuthorization();


//RoleController roleController = new RoleController(roleManager, userMrg);

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    if(!(await roleManager.RoleExistsAsync("Admin"))) await roleManager.CreateAsync(new IdentityRole("Admin"));
    if(!(await roleManager.RoleExistsAsync("Logged"))) await roleManager.CreateAsync(new IdentityRole("Logged"));
    
    if (userManager.FindByNameAsync("admin@admin.eu").Result == null)
    {
        ApplicationUser user = new ApplicationUser();
        user.FirstName = "Admin";
        user.LastName = "Admin";
        user.Email = "admin@admin.eu";
        user.UserName = user.Email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user,"Admin123!");

        ApplicationUser applicationUser = await userManager.FindByNameAsync("admin@admin.eu");
        if (!await userManager.IsInRoleAsync(applicationUser, "Admin"))
        {
            var userResult = await userManager.AddToRoleAsync(applicationUser, "Admin");
        }
    }

    if (userManager.FindByNameAsync("user@user.eu").Result == null)
    {
        ApplicationUser user = new ApplicationUser();
        user.FirstName = "User";
        user.LastName = "User";
        user.Email = "user@user.eu";
        user.UserName = user.Email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, "User123!");

        ApplicationUser applicationUser = await userManager.FindByNameAsync("user@user.eu");
        if (!await userManager.IsInRoleAsync(applicationUser, "Logged"))
        {
            var userResult = await userManager.AddToRoleAsync(applicationUser, "Logged");
        }
    }

}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
