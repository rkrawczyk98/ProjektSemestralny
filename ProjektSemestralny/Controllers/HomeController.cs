using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektSemestralny.Areas.Identity.Data;
using ProjektSemestralny.Areas.Identity.Pages.Account;
using ProjektSemestralny.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml.Linq;

namespace ProjektSemestralny.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

    /*
    public class MyIdentityDataInitializer
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("User").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user";
                user.Email = "user1@user.eu";

                IdentityResult result = userManager.CreateAsync(user, "User123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Logged").Wait();
                }
            }


            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@admin.eu";

                IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            {
                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Admin";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }


                if (!roleManager.RoleExistsAsync("Logged").Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Logged";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }
            }
        }
    }
        */
    
}