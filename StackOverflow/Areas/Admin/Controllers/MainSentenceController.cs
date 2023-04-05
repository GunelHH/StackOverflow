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

    public class MainSentenceController : Controller
    {

        private readonly AppDbContext context;


        public MainSentenceController(AppDbContext context)
        {
            this.context = context;    
        }

        public IActionResult Index()
        {
            List<MainSentence> mainSentences = context.MainSentences.ToList();
            return View(mainSentences);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(MainSentence mainSentence)
        {
            if (!ModelState.IsValid) return View();


            MainSentence exist = await context.MainSentences.FirstOrDefaultAsync(m => m.ChangableWords == mainSentence.ChangableWords);
            if (exist != null)
            {
                ModelState.AddModelError("ChangableWords ", "Already has such word");
                return View();
            }

            context.MainSentences.Add(mainSentence);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            MainSentence main = context.MainSentences.FirstOrDefault(i => i.Id == id);
            if (main is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(main);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id, MainSentence newSentence)
        {
            MainSentence sentence = await context.MainSentences.FirstOrDefaultAsync(c => c.Id == id);
            if (sentence is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View(sentence);

            context.Entry(sentence).CurrentValues.SetValues(newSentence);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            MainSentence main = await context.MainSentences.FindAsync(id);
            if (main is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            context.MainSentences.Remove(main);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}