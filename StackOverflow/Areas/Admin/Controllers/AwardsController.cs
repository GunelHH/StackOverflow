using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAL;
using StackOverflow.Models;
using StackOverflow.Utilities;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class AwardsController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public AwardsController(AppDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }


        public IActionResult Index()
        {
            List<Award> awards = context.Awards.ToList();
            return View(awards);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Award award)
        {
          
            if (award.Photo is null)
            {
                ModelState.AddModelError("Photo", "You forgot to select image");
                return View();
            }
            if (!ModelState.IsValid) return View();

            if (!award.Photo.ImageIsOkay(2))
            {
                ModelState.AddModelError("Photo", "Please choose valid Image");
                return View();
            }

            Award exist =await context.Awards.FirstOrDefaultAsync(i => i.Name.ToLower().Trim() == award.Name.Trim().ToLower());

            if (exist != null)
            {
                ModelState.AddModelError("Name", "Already has such award");
                return View();
            }


            award.Image = await award.Photo.FileCreate(env.WebRootPath, "assets/Images/about");
            context.Awards.Add(award);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Award award = context.Awards.FirstOrDefault(i => i.Id == id);
            if (award is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(award);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id,Award NewAward)
        {
            Award award = context.Awards.FirstOrDefault(c => c.Id == id);
            if (award is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Award ExistName = context.Awards.FirstOrDefault(c => c.Name == NewAward.Name);
            if (NewAward.Photo is null)
            {
                if (!ModelState.IsValid) return View(award);

                if (Methods.CheckAward(id, ExistName))
                {
                    ModelState.AddModelError("Name", "The award is already exist!");
                    return View(award);
                }

                string ImageFile = award.Image;
                context.Entry(award).CurrentValues.SetValues(NewAward);
                award.Image = ImageFile;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid) return View(award);
            if (!NewAward.Photo.ImageIsOkay(2))
            {
                ModelState.AddModelError("Photo", "Please choose valid Image");
                return View(award);
            }
            if (Methods.CheckAward(id, ExistName))
            {
                ModelState.AddModelError("Name", "The award is already exist!");
                return View(award);
            }

            Methods.FileDelete(env.WebRootPath, "assets/Images/about", award.Image);

            context.Entry(award).CurrentValues.SetValues(NewAward);
            award.Image = await NewAward.Photo.FileCreate(env.WebRootPath, "assets/Images/about");
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Award award = await context.Awards.FindAsync(id);
            if (award is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Methods.FileDelete(env.WebRootPath, "assets/Images/about", award.Image);

            context.Awards.Remove(award);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}