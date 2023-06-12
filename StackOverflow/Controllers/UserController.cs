using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackOverflow.DAL;
using StackOverflow.Models;
using StackOverflow.Utilities;
using StackOverflow.ViewModels;

namespace StackOverflow.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;
        private readonly UserManager<AppUser> userManager;

        public UserController(AppDbContext context,IWebHostEnvironment env,UserManager<AppUser>userManager)
        {
            this.context = context;
            this.env = env;
            this.userManager = userManager;
        }

        public IActionResult Activity()
        {
            string UserId = userManager.GetUserId(HttpContext.User);
            AppUser appUser = context.AppUsers.Include(u=>u.Answers).FirstOrDefault(u => u.Id == UserId);
            if (appUser is null) return RedirectToAction("notfound", "error");
            return View(appUser);
        }

        public IActionResult AskQuestion()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.User = context.AppUsers.FirstOrDefault();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AskQuestion(Question question)
        {
            ViewBag.User = context.AppUsers.FirstOrDefault();

            string userId = userManager.GetUserId(HttpContext.User);
            AppUser user = await userManager.FindByIdAsync(userId);
            if (user is null) return RedirectToAction("notfound", "error");


            if (!ModelState.IsValid) return View();

            if (question.Tags == null)
            {
                ModelState.AddModelError("Tags", "Tag is required!");
                return View();

            }

            Question exist = await context.Questions
                .Include(q=>q.questionTags)
                .ThenInclude(q=>q.Tag).FirstOrDefaultAsync(q=>q.Title==question.Title);

            if (exist!=null)
            {
                ModelState.AddModelError("Title", "This Title is already exist,you may check existed question");
                return View();
            }

            question.AppUserId = userId;


            context.Questions.Add(question);
            //await context.SaveChangesAsync();

            QuestionTag questionTag = new QuestionTag();
            foreach (var tag in question.Tags)
            {

                string[] tags = tag.Split(" ");

                foreach (var item in tags)
                {

                    Tag existTag = await context.Tags.FirstOrDefaultAsync(t => t.Name == item);

                    if (existTag != null)
                    {
                        questionTag = new QuestionTag
                        {
                            TagId=existTag.Id,
                            QuestionId=question.Id
                        };
                        context.questionTags.Add(questionTag);

                    }
                }
            }
            await context.SaveChangesAsync();

            return RedirectToAction("questions","home");
        }

        public async Task<IActionResult> UpdateQuestion(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("login", "account");

            if (id is null || id == 0) return RedirectToAction("notfound", "error");
            Question exist = await context.Questions.FirstOrDefaultAsync(q=>q.Id==id);
            if (exist is null)return RedirectToAction("notfound", "error");
            return View(exist);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateQuestion(int? id, Question newQuestion)
        {
            Question exist = await context.Questions.FirstOrDefaultAsync(q => q.Id == id);
            if (exist is null) return RedirectToAction("notfound", "error");

            if (!ModelState.IsValid) return View(exist);

            if (newQuestion.Tags == null)
            {
                ModelState.AddModelError("Tags", "Tag's required!");
                return View();

            }
            if (exist.Tags!=newQuestion.Tags)
            {
                foreach (QuestionTag tag in context.questionTags)
                {
                    if (tag.QuestionId==exist.Id)
                    {
                        context.questionTags.Remove(tag);
                    }
                }
            }

            QuestionTag questionTag = new QuestionTag();
            foreach (var tag in newQuestion.Tags)
            {

                string[] tags = tag.Split(" ");

                foreach (var item in tags)
                {

                    Tag existTag = await context.Tags.FirstOrDefaultAsync(t => t.Name == item);

                    if (existTag != null)
                    {
                        questionTag = new QuestionTag
                        {
                            TagId = existTag.Id,
                            QuestionId = newQuestion.Id
                        };
                        context.questionTags.Add(questionTag);

                    }
                }
            }
            if (newQuestion.Code!=null)
            {
                exist.Code = newQuestion.Code;
            }
            exist.Title = newQuestion.Title;
            exist.Desc = newQuestion.Desc;
            exist.EditDate = DateTime.Now;       
            exist.Title = newQuestion.Title;

            await context.SaveChangesAsync();

            return RedirectToAction("questions", "home");

        }

        public IActionResult DeleteQuestion(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error");
            Question exist = context.Questions.FirstOrDefault(q => q.Id == id);
            if(exist==null)return RedirectToAction("notfound", "error");

            context.Questions.Remove(exist);
            context.SaveChanges();
            return RedirectToAction("profile", "user");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Follow(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error");
            Company company = await context.Companies.FirstOrDefaultAsync(c=>c.Id==id);
            if(company is null)return RedirectToAction("notfound", "error");
            string userId = userManager.GetUserId(HttpContext.User);
            AppUser appUser = await userManager.FindByIdAsync(userId);
            if(appUser is null)return RedirectToAction("notfound", "error");


            CompanyUserFollow companyUserFollow = new CompanyUserFollow
            {
                CompanyId=company.Id,
                AppUserId=userId
            };

            context.Add(companyUserFollow);
            await context.SaveChangesAsync();

            return RedirectToAction("company", "home");
        }




        [HttpPost]
        public JsonResult Get(string searchString)        {
            TempData["searchstring"] = searchString;

            var tag = from name in context.Tags select name;

            if (!string.IsNullOrEmpty(searchString))
            {
                tag = tag.Where(t => t.Name.Trim().ToLower() == searchString.ToLower().Trim());
            }

            return Json(tag.Select(t=>t.Name));
        }

        public IActionResult Delete()
        {
            return View();
        }

        public async Task<IActionResult> EditProfile()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            AppUser user = await userManager.FindByIdAsync(userId);
            return View(user);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditProfile(AppUser newInfo)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            AppUser user = await userManager.FindByIdAsync(userId);

            if (newInfo.ProfileImg != null)
            {
                user.ProfilePhoto = await newInfo.ProfileImg.FileCreate(env.WebRootPath, "assets/images/User-card");
                Methods.FileDelete(env.WebRootPath, "assets/images/User-card", user.ProfilePhoto);


                user.About = newInfo.About;
                user.Location = newInfo.Location;
                user.Reputation = newInfo.Reputation;
                user.UserName = newInfo.UserName;


                user.ProfilePhoto = await newInfo.ProfileImg.FileCreate(env.WebRootPath, "assets/images/User-card");

                await context.SaveChangesAsync();


                return RedirectToAction("profile", "user");

            }
            string ImageFile = user.ProfilePhoto;
            user.About = newInfo.About;
            user.Location = newInfo.Location;
            user.Reputation = newInfo.Reputation;
            user.UserName = newInfo.UserName;
            user.ProfilePhoto = ImageFile;
            
            await context.SaveChangesAsync();


            return RedirectToAction("profile","user");
        }

        public async Task<IActionResult> Profile()
        {
            var userId= userManager.GetUserId(HttpContext.User);
            AppUser user = await userManager.FindByIdAsync(userId);
            return View(user);
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}