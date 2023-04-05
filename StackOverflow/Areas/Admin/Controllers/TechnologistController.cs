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

    public class TechnologistController : Controller
    {
        private readonly AppDbContext context;

        public TechnologistController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Technologist> technologists = context.Technologists.ToList();
            return View(technologists);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Technologist technologist)
        {
            if (!ModelState.IsValid) return View();

            Technologist exist = context.Technologists.FirstOrDefault(t => t.Name == technologist.Name);
            if (exist!=null)
            {
                ModelState.AddModelError("Name", "Already has such name");
                return View();
            }

            context.Technologists.Add(technologist);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Technologist technologist = context.Technologists.FirstOrDefault(i => i.Id == id);
            if (technologist is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(technologist);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, Technologist newTechnologist)
        {
            Technologist exist = context.Technologists.FirstOrDefault(i => i.Id == id);
            if (exist is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            if (!ModelState.IsValid) return View(exist);
            Technologist technologist = context.Technologists.FirstOrDefault(t => t.Name == newTechnologist.Name);
            if (technologist != null)
            {
                ModelState.AddModelError("Name", "Already has such name");
                return View();
            }

            context.Entry(exist).CurrentValues.SetValues(newTechnologist);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Technologist technologist = context.Technologists.FirstOrDefault(i => i.Id == id);
            if (technologist is null) return RedirectToAction("notfound", "error", new { area = string.Empty });


            context.Technologists.Remove(technologist);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}