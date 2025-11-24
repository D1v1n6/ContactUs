using Microsoft.AspNetCore.Mvc;
using SolidCoreMvc.Models;
using SolidCoreMvc.Services;

namespace SolidCoreMvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactStorageService _storage;

        public ContactController()
        {
            _storage = new ContactStorageService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                _storage.SaveMessage(model);

                TempData["Success"] = "Your message has been sent!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // ⭐ ADMIN PAGE — SHOW ALL MESSAGES
        public IActionResult Admin()
        {
            var messages = _storage.GetMessages();
            return View(messages);
        }
    }
}
