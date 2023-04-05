using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Models;
using StackOverflow.ViewModels;

namespace StackOverflow.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
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
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await userManager.FindByEmailAsync(login.Email);

            if (user is null) return View();

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password,true,true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "You have already made 5 wrong attempts, so you have been blocked for 10 minutes.");
                    return View();

                }
                ModelState.AddModelError("", "Your Email or Password is incorrect");
                return View();
            }
            return RedirectToAction("index", "home");

        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                ProfilePhoto = "9d19f76e-c652-4057-ac65-c181d524582dc7171204-99b7-4bb1-92c9-19f8486e76aadownload (1).png"
            };

            IdentityResult result = await userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            #region Send email
            //string Token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            //string Link = Url.Action(nameof(ConfirmEmail), "Account", new { email = user.Email, Token }, Request.Scheme, Request.Host.ToString());

            //MailMessage email = new MailMessage();
            //email.From = new MailAddress("gunelfh@code.edu.az", "Stack Overflow");
            //email.To.Add(new MailAddress(user.Email));

            //email.Subject = "Confirmation";
            //string body = string.Empty;

            //using (StreamReader stream = new StreamReader("wwwroot/assets/confirm/index.html"))
            //{
            //    body = stream.ReadToEnd();
            //}
            //string about = $"<strong>{user.UserName}</strong> Welcome to Stack Overflow,Please check and click to link for confirmation your account";

            //body = body.Replace("{{link}}", Link);
            //email.Body = body.Replace("{{About}}", about);
            //email.IsBodyHtml = true;


            //SmtpClient client = new SmtpClient();
            //client.Host = "smtp.gmail.com";
            //client.Port = 587;
            //client.EnableSsl = true;

            //client.Credentials = new NetworkCredential();
            //client.Send(email);
            //TempData["Verify"] = true;
            #endregion


            await userManager.AddToRoleAsync(user, "Member");


            return RedirectToAction("login", "account");
        }

        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            AppUser user = await userManager.FindByEmailAsync(email);

            if (user is null) return RedirectToAction("notfound", "error");

            await userManager.ConfirmEmailAsync(user, token);

            await signInManager.SignInAsync(user, true);
            TempData["Verify"] = true;

            return RedirectToAction("login", "account");
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        //ROLES

        //public async Task CreateRoles()
        //{
        //    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await roleManager.CreateAsync(new IdentityRole("Member"));
        //}


        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ForgotPassword(AccountVM accountVM)
        {
            AppUser user = await userManager.FindByEmailAsync(accountVM.AppUser.Email);
            if (user is null) return RedirectToAction("notfound", "error");


            string token = await userManager.GeneratePasswordResetTokenAsync(user);

            string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("gunelfh@code.edu.az", "Stack Overflow");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Reset Password";
            mail.Body = $"<a href='{link}'>Please click here to reset your password</a>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("gunelfh@code.edu.az", "gunel6864");
            smtp.Send(mail);
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> ResetPassword(string email, string token)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user is null) return BadRequest();
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ResetPassword(AccountVM account)
        {
            AppUser user = await userManager.FindByEmailAsync(account.AppUser.Email);
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = account.Token
            };
            if (!ModelState.IsValid) return View(model);
            IdentityResult result = await userManager.ResetPasswordAsync(user, account.Token, account.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);

            }
            await signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }
    }
}