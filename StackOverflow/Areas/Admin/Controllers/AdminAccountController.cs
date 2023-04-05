using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Models;
using StackOverflow.ViewModels;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminAccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(AdminLoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await userManager.FindByNameAsync(loginVM.Username);

            if (user is null) return View();

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "You have already made 5 wrong attempts, so you have been blocked for 10 minutes.");
                    return View();

                }
                ModelState.AddModelError("", "Your Username or Password is incorrect");
                return View();
            }
            return RedirectToAction("index", "dashboard");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(AdminRegisterVM adminRegisterVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser User = new AppUser
            {
               UserName=adminRegisterVM.Username,
               Email=adminRegisterVM.Email,
               ProfilePhoto= "5d92051d2601e86382ae5422a5912e5c.png"
            };

            IdentityResult result = await userManager.CreateAsync(User, adminRegisterVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            await userManager.AddToRoleAsync(User, "Admin");

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home", new { area = string.Empty });
        }
    }
}