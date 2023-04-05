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
using StackOverflow.Utilities;

namespace StackOverflow.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class QuestionController : Controller
    {
        private readonly AppDbContext context;

        public QuestionController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Question> questions =await context.Questions.ToListAsync();
            return View(questions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Question question)
        {
            if (!ModelState.IsValid) return View();

            Question existTitle = await context.Questions.FirstOrDefaultAsync(q => q.Title == question.Title);
            if (existTitle!=null)
            {
                ModelState.AddModelError("Title", "Already exist such question title");
                return View();
            }
            question.EditDate = DateTime.Now;
            await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null || id==0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Question question = context.Questions.FirstOrDefault(q => q.Id == id);
            if(question is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(question);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id,Question newQuestion)
        {
            Question question = context.Questions.FirstOrDefault(c => c.Id == id);
            if (question is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Question ExistTitle =await context.Questions.FirstOrDefaultAsync(c => c.Title == newQuestion.Title);

            if (!ModelState.IsValid) return View(question);

            question.Title = newQuestion.Title;
            question.Desc = newQuestion.Desc;
            question.Code = newQuestion.Code;
            question.EditDate = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Question question = await context.Questions.FirstOrDefaultAsync(q=>q.Id==id);
            if (question is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            context.Questions.Remove(question);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}