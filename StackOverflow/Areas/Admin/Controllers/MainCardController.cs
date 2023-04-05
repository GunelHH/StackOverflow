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
using StackOverflow.Utilities;

namespace StackOverflow.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class MainCardController : Controller
    {

        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public MainCardController(AppDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            List<MainCard> mainCards = context.MainCards.ToList();
            return View(mainCards);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(MainCard card)
        {
            if (!ModelState.IsValid) return View();


            if (context.MainCards.Count()>=2)
            {
                ModelState.AddModelError("Icon", "You already have 2 cards,please delete at least one to create a new card");
                return View();
            }

            MainCard exist = await context.MainCards.FirstOrDefaultAsync(m => m.Icon == card.Icon || m.Sentence==card.Sentence);
            if (exist != null)
            {
                ModelState.AddModelError("Name", "Already has such card");
                return View();
            }

            context.MainCards.Add(card);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            MainCard main = context.MainCards.FirstOrDefault(i => i.Id == id);
            if (main is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(main);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id, MainCard NewCard)
        {
            MainCard card =await context.MainCards.FirstOrDefaultAsync(c => c.Id == id);
            if (card is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View(card);

            if (context.MainCards.Count() > 2)
            {
                ModelState.AddModelError("Sentence", "To create card, you must delete one existed  card at least");
                return View();
            }

            context.Entry(card).CurrentValues.SetValues(NewCard);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            MainCard card = await context.MainCards.FindAsync(id);
            if (card is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            context.MainCards.Remove(card);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}