using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAL;
using StackOverflow.Models;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class QuoteController : Controller
    {
        private readonly AppDbContext context;


        public QuoteController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Quote> quotes = context.Quotes.ToList();
            return View(quotes);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Quote quote)
        {
            if (!ModelState.IsValid) return View();


            Quote exist = await context.Quotes.FirstOrDefaultAsync(m => m.Company == quote.Company);
            if (exist != null)
            {
                ModelState.AddModelError("Company", "Already has quote from this company");
                return View();
            }

            context.Quotes.Add(quote);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Quote quote = context.Quotes.FirstOrDefault(i => i.Id == id);
            if (quote is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(quote);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id, Quote newQuote)
        {
            Quote quote = await context.Quotes.FirstOrDefaultAsync(c => c.Id == id);
            if (quote is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View(quote);

            context.Entry(quote).CurrentValues.SetValues(newQuote);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Quote quote = await context.Quotes.FindAsync(id);
            if (quote is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            context.Quotes.Remove(quote);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}