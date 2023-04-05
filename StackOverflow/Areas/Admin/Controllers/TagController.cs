using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.DAL;
using StackOverflow.Models;
using StackOverflow.Utilities;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class TagController : Controller
    {
       
            private readonly AppDbContext context;
            private readonly IWebHostEnvironment env;

            public TagController(AppDbContext context, IWebHostEnvironment env)
            {
                this.context = context;
                this.env = env;
            }


            public IActionResult Index()
            {
                List<Tag> tag = context.Tags.ToList();
                return View(tag);
            }


            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [AutoValidateAntiforgeryToken]
            public async Task<IActionResult> Create(Tag tag)
            {
                if (!ModelState.IsValid) return View();

                 if (tag.Photo!=null)
                 {
                 tag.Image = await tag.Photo.FileCreate(env.WebRootPath, "assets/images/tag");

                 }
                Tag exist = context.Tags.FirstOrDefault(t=>t.Name==tag.Name);
                if (exist!=null)
                {
                ModelState.AddModelError("Name", "Already exist such tag");
                return View();
                }
                context.Tags.Add(tag);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            public IActionResult Update(int? id)
            {
                if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
                Tag tag = context.Tags.FirstOrDefault(i => i.Id == id);
                if (tag is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
                return View(tag);
            }

            [HttpPost]
            [AutoValidateAntiforgeryToken]

            public async Task<IActionResult> Update(int? id, Tag newTag)
            {
                Tag tag = context.Tags.FirstOrDefault(c => c.Id == id);
                if (tag is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
                Tag ExistName = context.Tags.FirstOrDefault(c => c.Name == newTag.Name);


                if (!ModelState.IsValid) return View(tag);

                 if (newTag.Photo != null)
                 {
                     if (tag.Image != null)
                     {
                        Methods.FileDelete(env.WebRootPath, "assets/images/tag", tag.Image);
                        tag.Image = await newTag.Photo.FileCreate(env.WebRootPath, "assets/images/tag");

                        tag.Name = newTag.Name;
                        tag.About = newTag.About;
                        context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                     }
                     tag.Image = await newTag.Photo.FileCreate(env.WebRootPath, "assets/images/tag");
                     tag.Name = newTag.Name;
                     tag.About = newTag.About;
                     context.SaveChanges();
                     return RedirectToAction(nameof(Index));
                 }

                tag.Name = newTag.Name;
                tag.About = newTag.About;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

                Tag tag = await context.Tags.FindAsync(id);
                if (tag is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

                  if (tag.Image!=null)
                  {
                   Methods.FileDelete(env.WebRootPath, "assets/images/tag", tag.Image);
                  }

                context.Tags.Remove(tag);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        
    }
}