using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.DAL;
using StackOverflow.Models;

namespace StackOverflow.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext context;

        public ContactController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            Contact contact = context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact is null) return NotFound();

            context.Contacts.Remove(contact);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}