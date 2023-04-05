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

    public class ProductController : Controller
    {

        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            List<Product> products = context.Products.ToList();
            return View(products);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View();

            if(product.LogoPhoto is null)
            {
                ModelState.AddModelError("LogoPhoto", "Please choose Logo image");
                return View();
            }

            if(product.PhotoImage is null)
            {
                ModelState.AddModelError("PhotoImage", "Please choose Image");
                return View();
            }
            if (!product.PhotoImage.ImageIsOkay(2))
            {
                ModelState.AddModelError("PhotoImage", "Please choose valid Image");
                return View();
            }

            Product exist = await context.Products.FirstOrDefaultAsync(p=>p.Desc==product.Desc);
            if (exist != null)
            {
                ModelState.AddModelError("Desc", "Already has such product");
                return View();
            }

            product.Image = await product.PhotoImage.FileCreate(env.WebRootPath, "assets/images/about");
            product.Logo = await product.LogoPhoto.FileCreate(env.WebRootPath, "assets/images/Logo");

            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });
            Product product = context.Products.FirstOrDefault(i => i.Id == id);
            if (product is null) return RedirectToAction("notfound", "error", new { area = string.Empty });
            return View(product);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id, Product newProduct)
        {
            Product product = await context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (product is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            if (!ModelState.IsValid) return View(product);

            if (newProduct.LogoPhoto is null)
            {
                if (newProduct.PhotoImage is null)
                {
                    string LogoImage = product.Logo;
                    string Image = product.Image;
                    context.Entry(product).CurrentValues.SetValues(newProduct);
                    product.Logo = LogoImage;
                    product.Image = Image;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Methods.FileDelete(env.WebRootPath, "assets/images/about", product.Image);

                    product.Image = await newProduct.PhotoImage.FileCreate(env.WebRootPath, "assets/images/about");

                    string LogoImage = product.Logo;
                    context.Entry(product).CurrentValues.SetValues(newProduct);
                    product.Logo = LogoImage;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            if(newProduct.PhotoImage is null)
            {
                //Methods.FileDelete(env.WebRootPath, "assets/images/Logo", product.Logo);

                product.Logo = await newProduct.LogoPhoto.FileCreate(env.WebRootPath, "assets/images/Logo");

                string Image = product.Image;
                context.Entry(product).CurrentValues.SetValues(newProduct);
                product.Image = Image;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            Methods.FileDelete(env.WebRootPath, "assets/images/about", product.Image);
            Methods.FileDelete(env.WebRootPath, "assets/images/Logo", product.Logo);

            context.Entry(product).CurrentValues.SetValues(newProduct);
            product.Image = await newProduct.PhotoImage.FileCreate(env.WebRootPath, "assets/images/about");
            product.Logo = await newProduct.LogoPhoto.FileCreate(env.WebRootPath, "assets/images/Logo");
            context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Product product = await context.Products.FindAsync(id);
            if (product is null) return RedirectToAction("notfound", "error", new { area = string.Empty });

            Methods.FileDelete(env.WebRootPath, "assets/images/about", product.Image);
            Methods.FileDelete(env.WebRootPath, "assets/images/Logo", product.Logo);

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}