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
    public class AnswerController : Controller
    {
        private readonly AppDbContext context;

        public AnswerController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Answer> answers = await context.Answers.ToListAsync();
            return View(answers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Answer answer)
        {
            if (!ModelState.IsValid) return View();

            answer.EditDate = DateTime.Now;
            await context.Answers.AddAsync(answer);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Answer answer = context.Answers.FirstOrDefault(q => q.Id == id);
            if (answer is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(answer);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Answer newAnswer)
        {
            Answer answer = await context.Answers.FirstOrDefaultAsync(c => c.Id == id);
            if (answer is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View(answer);

            answer.Desc = newAnswer.Desc;
            answer.IsTheBest = newAnswer.IsTheBest;
            answer.Code = newAnswer.Code;
            answer.EditDate = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Answer answer = await context.Answers.FirstOrDefaultAsync(q => q.Id == id);
            if (answer is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            context.Answers.Remove(answer);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}