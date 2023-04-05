using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.DAL;
using StackOverflow.Models;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class SettingsController : Controller
    {
        private readonly AppDbContext context;

        public SettingsController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Settings> settings = context.Settings.ToList();
            return View(settings);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Settings set)
        {
            if (!ModelState.IsValid) return View();

            context.Settings.Add(set);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Settings settings = context.Settings.FirstOrDefault(i => i.Id == id);
            if (settings is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(settings);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, Settings set)
        {
            Settings exist = context.Settings.FirstOrDefault(i => i.Id == id);
            if (exist is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            if (!ModelState.IsValid) return View(exist);


            context.Entry(exist).CurrentValues.SetValues(set);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Settings set = context.Settings.FirstOrDefault(i => i.Id == id);
            if (set is null) return RedirectToAction("notfound", "error", new { area = string.Empty });


            context.Settings.Remove(set);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}