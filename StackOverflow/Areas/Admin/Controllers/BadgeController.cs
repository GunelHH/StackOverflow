using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAL;
using StackOverflow.Models;

namespace StackOverflow.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BadgeController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public BadgeController(AppDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }


        public IActionResult Index()
        {
            List<Badge> badges = context.Badges.ToList();
            return View(badges);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Badge badge)
        {
            if (!ModelState.IsValid) return View();
            Badge exist = await context.Badges.FirstOrDefaultAsync(b=>b.Icon==badge.Icon || b.Name==badge.Name);
            if (exist!=null)
            {
                ModelState.AddModelError("", "This Icon or Name already exist");
                return View();
            }

            context.Badges.Add(badge);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Badge badge = context.Badges.FirstOrDefault(i => i.Id == id);
            if (badge is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(badge);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id, Badge newBadge)
        {
            Badge badge = context.Badges.FirstOrDefault(c => c.Id == id);
            if (badge is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View(badge);

            Badge ExistName =await context.Badges.FirstOrDefaultAsync(b => b.Name == newBadge.Name || b.Icon ==newBadge.Icon);
            if (ExistName != null)
            {
                ModelState.AddModelError("", "This Icon or Name already exist");
                return View();
            }
            context.Entry(badge).CurrentValues.SetValues(newBadge);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Badge badge = await context.Badges.FindAsync(id);
            if (badge is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            context.Badges.Remove(badge);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}