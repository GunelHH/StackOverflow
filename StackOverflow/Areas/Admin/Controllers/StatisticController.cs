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

    public class StatisticController : Controller
    {
        private readonly AppDbContext context;

        public StatisticController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Statistic> statistics = context.Statistics.ToList();
            return View(statistics);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Statistic stat)
        {
            if (!ModelState.IsValid) return View();

            context.Statistics.Add(stat);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Statistic statistic = context.Statistics.FirstOrDefault(i => i.Id == id);
            if (statistic is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(statistic);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, Statistic statistic)
        {
            Statistic exist = context.Statistics.FirstOrDefault(i => i.Id == id);
            if (exist is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            if (!ModelState.IsValid) return View(exist);


            context.Entry(exist).CurrentValues.SetValues(statistic);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Statistic statistic = context.Statistics.FirstOrDefault(i => i.Id == id);
            if (statistic is null) return RedirectToAction("notfound", "error", new { area = string.Empty });


            context.Statistics.Remove(statistic);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}