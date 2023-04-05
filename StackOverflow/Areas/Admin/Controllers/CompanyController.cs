using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.DAL;
using StackOverflow.Models;
using StackOverflow.Utilities;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public CompanyController(AppDbContext context,IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            List<Company> companies = context.Companies.ToList();
            return View(companies);
        }

        public IActionResult Create()
        {
       
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid) return View();

            Company ExistName = context.Companies.FirstOrDefault(c => c.Name == company.Name);

            if (ExistName != null)
            {
                ModelState.AddModelError("Name", "The Company Name already exist");
                return View();
            }

            if (company.CompanyPhoto is null || company.AboutPhoto is null || company.VideoPhoto is null)
            {
                ModelState.AddModelError("", "Company image ,about image,and video image cannot be empty");
                return View();
            }

            if (!company.AboutPhoto.ImageIsOkay(3))
            {
                ModelState.AddModelError("AboutPhoto", "Please choose valid image");
                return View();
            }

            if (!company.VideoPhoto.ImageIsOkay(2))
            {
                ModelState.AddModelError("VideoPhoto", "Please choose valid image");
                return View();
            }

            if (!company.WebSiteLink.StartsWith("https://www."))
            {
                ModelState.AddModelError("WebSiteLink", "Please add valid link");
                return View();
            }

            if (!company.VideoLink.StartsWith("https://www."))
            {
                ModelState.AddModelError("WebSiteLink", "Please add valid video link");
                return View();
            }
            if(company.PostPhoto != null)
            {
              company.PostImage = await company.PostPhoto.FileCreate(env.WebRootPath, "assets/images/Companies");

            }

            company.Image = await company.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/Companies");
            company.AboutImage = await company.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/Companies");
            company.VideoImage = await company.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/Companies");


            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int?id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Company company = context.Companies.FirstOrDefault(i => i.Id == id);
            if (company is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(company);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int?id,Company newCompany)
        {
            Company company = context.Companies.FirstOrDefault(c => c.Id == id);
            if (company is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View();
            Company ExistName = context.Companies.FirstOrDefault(c => c.Name == newCompany.Name && c.Id!=id);

            if (ExistName != null)
            {
                ModelState.AddModelError("Name", "The Company Name already exist");
                return View();
            }

            if (!newCompany.WebSiteLink.StartsWith("https://www.") || !newCompany.VideoLink.StartsWith("https://www."))
            {
                ModelState.AddModelError("", "Please enter the valid links");
                return View();
            }

            if (CheckCompanyImage(newCompany))
            {
                string ImageFile = company.Image;
                if (CheckPostImage(newCompany))
                {
                    string PostFile = company.PostImage;
                    if (CheckAboutImage(newCompany))
                    {
                        string AboutFile = company.AboutImage;
                        if (CheckVideoImage(newCompany))
                        {
                            string VideoFile = company.VideoImage;
                            context.Entry(company).CurrentValues.SetValues(newCompany);
                            company.Image = ImageFile;
                            company.AboutImage = AboutFile;
                            company.VideoImage = VideoFile;
                            company.PostImage = PostFile;

                            await context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

                        context.Entry(company).CurrentValues.SetValues(newCompany);

                        company.VideoImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                        company.Image = ImageFile;
                        company.AboutImage = AboutFile;
                        company.PostImage = PostFile;

                        await context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    if (CheckVideoImage(newCompany))
                    {
                        string VideoFile = company.VideoImage;

                        Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);

                        context.Entry(company).CurrentValues.SetValues(newCompany);

                        company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                        company.Image = ImageFile;
                        company.PostImage = PostFile;
                        company.VideoImage = VideoFile;

                        await context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

                    context.Entry(company).CurrentValues.SetValues(newCompany);

                    company.VideoImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                    company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                    company.Image = ImageFile;
                    company.PostImage = PostFile;

                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                if (CheckAboutImage(newCompany))
                {
                    string AboutFile = company.AboutImage;

                    if (CheckVideoImage(newCompany))
                    {
                        string VideoFile = company.VideoImage;

                        Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);

                        context.Entry(company).CurrentValues.SetValues(newCompany);

                        company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                        company.Image = ImageFile;
                        company.AboutImage = AboutFile;
                        company.VideoImage = VideoFile;

                        await context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

                    context.Entry(company).CurrentValues.SetValues(newCompany);

                    company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                    company.VideoImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                    company.Image = ImageFile;
                    company.AboutImage = AboutFile;

                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                if (CheckVideoImage(newCompany))
                {
                    string VideoFile = company.VideoImage;
                    if (CheckPostImage(newCompany))
                    {
                        string PostFile = company.PostImage;

                        Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);

                        context.Entry(company).CurrentValues.SetValues(newCompany);

                        company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                        company.PostImage = PostFile;
                        company.Image = ImageFile;
                        company.VideoImage = VideoFile;

                        await context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);

                    context.Entry(company).CurrentValues.SetValues(newCompany);

                    company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                    company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                    company.Image = ImageFile;
                    company.VideoImage = VideoFile;

                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

                context.Entry(company).CurrentValues.SetValues(newCompany);

                company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                company.VideoImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

                company.Image = ImageFile;

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            if (CheckAboutImage(newCompany))
            {
                string AboutFile = company.AboutImage;
                if (CheckVideoImage(newCompany))
                {
                    string VideoFile = company.VideoImage;
                    if (CheckPostImage(newCompany))
                    {
                        string PostFile = company.PostImage;

                        Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);

                        context.Entry(company).CurrentValues.SetValues(newCompany);

                        company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");


                        company.AboutImage = AboutFile;
                        company.VideoImage = VideoFile;
                        company.PostImage = PostFile;

                        await context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);

                    context.Entry(company).CurrentValues.SetValues(newCompany);

                    company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                    company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");


                    company.AboutImage = AboutFile;
                    company.VideoImage = VideoFile;

                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                if (CheckPostImage(newCompany))
                {
                    string PostFile = company.PostImage;

                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

                    context.Entry(company).CurrentValues.SetValues(newCompany);

                    company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                    company.PostImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");


                    company.AboutImage = AboutFile;
                    company.PostImage = PostFile;

                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            if (CheckVideoImage(newCompany))
            {
                string VideoFile = company.VideoImage;
                if (CheckPostImage(newCompany))
                {
                    string PostFile = company.PostImage;

                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);
                    Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);

                    context.Entry(company).CurrentValues.SetValues(newCompany);

                    company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                    company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");


                    company.VideoImage = VideoFile;
                    company.PostImage = PostFile;

                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);

                context.Entry(company).CurrentValues.SetValues(newCompany);

                company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");


                company.VideoImage = VideoFile;

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (CheckPostImage(newCompany))
            {

                string PostFile = company.PostImage;

                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

                context.Entry(company).CurrentValues.SetValues(newCompany);

                company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
                company.VideoImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");


                company.PostImage = PostFile;

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);
            Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
            Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);
            Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);

            context.Entry(company).CurrentValues.SetValues(newCompany);

            company.Image = await newCompany.CompanyPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
            company.AboutImage = await newCompany.AboutPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
            company.VideoImage = await newCompany.VideoPhoto.FileCreate(env.WebRootPath, "assets/images/companies");
            company.PostImage = await newCompany.PostPhoto.FileCreate(env.WebRootPath, "assets/images/companies");

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public bool CheckCompanyImage(Company company)
        {
            if (company.CompanyPhoto is null)
            {
                return true;
            }
            return false; ;
        }

        public bool CheckVideoImage(Company company)
        {
            if (company.VideoPhoto is null)
            {
                return true;
            }
            return false; ;
        }  public bool CheckPostImage(Company company)
        {
            if (company.PostPhoto is null)
            {
                return true;
            }
            return false; ;
        }  public bool CheckAboutImage(Company company)
        {
            if (company.AboutPhoto is null)
            {
                return true;
            }
            return false; ;
        }


        public async Task<IActionResult> Delete(int? id)
        {

            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Company company = await context.Companies.FindAsync(id);
            if (company is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (company.Image !=null)
            {
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.Image);

            }
            if (company.AboutImage!=null)
            {
              Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.AboutImage);
            }
            if (company.PostImage !=null)
            {
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.PostImage);

            }
            if (company.VideoPhoto !=null)
            {
                Methods.FileDelete(env.WebRootPath, "assets/images/companies", company.VideoImage);

            }
    
          
            context.Companies.Remove(company);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}