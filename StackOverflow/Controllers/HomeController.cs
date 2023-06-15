using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAL;
using StackOverflow.Models;
using StackOverflow.ViewModels;

namespace StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;

        public HomeController(AppDbContext context,UserManager<AppUser>userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                MainCards = context.MainCards.ToList(),
                mainSentences = context.MainSentences.ToList(),
                quotes = context.Quotes.ToList(),
                settings = context.Settings.ToList(),
                statistics = context.Statistics.ToList(),
                technologists = context.Technologists.ToList(),
            };
            if (!User.Identity.IsAuthenticated)
            {
                return View(homeVM);
            }
            else
            {
                return RedirectToAction("questions", "home");
            }
            
        }

        public IActionResult About()
        {
            AboutVM about = new AboutVM
            {
                Awards = context.Awards.ToList()

            };
            return View(about);
        }

        public IActionResult Companies(string search)
        {
            List<Company> companies = context.Companies.ToList();
            return View(companies);

            //ViewData["CurrentFilter"] = search;
            //var company = from c in context.Companies select c;

            //if (!string.IsNullOrEmpty(search))
            //{
            //    company = company.Where(c => c.Name==search);
            //}
            //return View(companies);
        }

        public async Task<IActionResult> CompanyDetail(int?id)
        {
        if (id is null || id == 0) return RedirectToAction("notfound", "error");
        Company company = await context.Companies.FirstOrDefaultAsync(c=>c.Id==id);
        if(company is null) return RedirectToAction("notfound", "error");

        return View(company);
        }

        public IActionResult Contact()
        {
          
        return View();
        }

        public async Task<IActionResult> Questions(int page=1)
        {
            List<Question> questions = await context.Questions.Include(c => c.AppUser)
                .Include(q=>q.questionTags)
                .ThenInclude(qt=>qt.Tag)
                .Include(q=>q.questionTags)
                .ThenInclude(qt=>qt.Question)
                .OrderByDescending(q => q.Id)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToListAsync();

        
            ViewBag.Page = page;
            ViewBag.TotalPage = Math.Ceiling((decimal)context.Questions.Count() / 10); ;

            ViewBag.User =  context.AppUsers.FirstOrDefault();
            //ViewBag.Tags = await context.Tags.ToListAsync();


            return View(questions);
        }


        public async Task<IActionResult> QuestionDetail(int? id)
         {
            if (id is null || id == 0) return RedirectToAction("notfound", "error");
            Question question = await context.Questions.Include(q=>q.Answers).Include(q=>q.Comments).FirstOrDefaultAsync(q=>q.Id==id);
            if(question is null)return RedirectToAction("notfound", "error");

            ViewBag.User = await context.AppUsers.FirstOrDefaultAsync();


            return View(question);
         }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Answer(int id ,Answer answer)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }

            if (!ModelState.IsValid) return View();


            string userId = userManager.GetUserId(HttpContext.User);
            AppUser user = await userManager.FindByIdAsync(userId);
            if (user is null) return RedirectToAction("notfound", "error");

            Question question = await context.Questions.Include(q=>q.AppUser).Include(q=>q.Answers).FirstOrDefaultAsync(q => q.Id == id);

            answer.QuestionId = question.Id;
            answer.AppUserId = userId;
            answer.AnswerDate = DateTime.Now;
            answer.EditDate = DateTime.Now;



            context.Database.OpenConnection();
            try
            {
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Answers ON");
                //context.Add(answer);
                //context.SaveChanges();
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Answers OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

     
            await context.SaveChangesAsync();

            return RedirectToAction("questions","home");
        }

        public IActionResult Comment()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Comment(Comment comment)
        {
            if (comment is null) return NotFound();
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            Question question = await context.Questions.Include(q => q.Answers).Include(q => q.AppUser).Include(q => q.Comments).FirstOrDefaultAsync();

            if (comment.Body != null)
            {
                if (!ModelState.IsValid) return View();

                comment.QuestionId = comment.QuestionId;
                comment.AppUserId = user.Id;


                context.Comments.Add(comment);
                context.SaveChanges();

                return RedirectToAction("questiondetail", "home", new { id = comment.QuestionId });
            }

            return RedirectToAction("questiondetail", "home" ,new { id=comment.QuestionId});

        }

        public IActionResult Tags()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult HelpCenter()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> HelpCenter(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                AppUser appUser = await userManager.FindByEmailAsync(contact.email);
                if(appUser is null)
                {
                    ModelState.AddModelError("email", "Please enter the correct email");
                    return View();
                }

                ViewBag.Success = "Your message has been sent successfully,we  will contact you as soon as possible";

                context.Contacts.Add(contact);
                await context.SaveChangesAsync();
                return View();
            }  
        }
    }
}