using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ProjektSemestralny.Models;
using ProjektSemestralny.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ProjektSemestralny.Controllers
{
    public class RoleController : Controller
    {
        private  RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
            //SeedData(userMrg, roleMgr);
        }

        //[Authorize(Roles = "Admin")]
        public ViewResult Index() => View(roleManager.Roles);

        public bool RoleExists(string name)
        {
            foreach(var role in roleManager.Roles)
            {
                if(role.ToString() == name) return true;
            }
            return false;
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

       // [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }


        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }

       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();
            foreach (ApplicationUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }

        public void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public async void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("User").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "User";
                user.LastName = "User";
                user.Email = "user1@user.eu";
                user.UserName = user.Email;
                user.EmailConfirmed = true;


                IdentityResult result = userManager.CreateAsync(user, "User123!").Result;

                await userManager.AddToRoleAsync(user, "Logged");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Logged").Wait();
                }
            }


            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.Email = "admin@admin.eu";
                user.UserName = user.Email;
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;
                await userManager.AddToRoleAsync(user, "Admin");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            {
                if (!RoleExists("Admin"))
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Admin";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }


                if (!RoleExists("Logged"))
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Logged";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }
            }
        }

    }
}
