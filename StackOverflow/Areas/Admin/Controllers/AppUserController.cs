using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAL;
using StackOverflow.Models;
using StackOverflow.Utilities;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppUserController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly IWebHostEnvironment env;

        public AppUserController(AppDbContext context,UserManager<AppUser> userManager,IWebHostEnvironment env)
        {
            this.context = context;
            this.userManager = userManager;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users =await context.AppUsers.ToListAsync();
            
            return View(users);
        }



        public async Task<IActionResult> Update(string id)
        {
            if(id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            AppUser user = await userManager.FindByIdAsync(id);
            if (user is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(user);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id,AppUser newInfo)
        {
        
            AppUser user = await userManager.FindByIdAsync(id);
            if (user is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            if (newInfo.ProfileImg!=null)
            {
                if (user.ProfilePhoto != null)
                {
                    Methods.FileDelete(env.WebRootPath, "assets/images/User-card", user.ProfilePhoto);
                }

                user.Email = newInfo.Email;
                user.About = newInfo.About;
                user.Location = newInfo.Location;
                user.Reputation = newInfo.Reputation;
                user.UserName = newInfo.UserName;
                user.BadgeCount = newInfo.BadgeCount;
                user.ProfilePhoto = await newInfo.ProfileImg.FileCreate(env.WebRootPath, "assets/images/User-card");
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            string ImageFile = user.ProfilePhoto;

            user.Email = newInfo.Email;
            user.About = newInfo.About;
            user.Location = newInfo.Location;
            user.Reputation = newInfo.Reputation;
            user.UserName = newInfo.UserName;
            user.BadgeCount = newInfo.BadgeCount;

            user.ProfilePhoto = ImageFile;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id is null) return RedirectToAction("notfound", "error");
            AppUser user = await userManager.FindByIdAsync(id);
            if(user is null) return RedirectToAction("notfound", "error");

            return View(user);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(string id,AppUser deleted)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user is null) return RedirectToAction("notfound", "error");

            context.AppUsers.Remove(user);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}