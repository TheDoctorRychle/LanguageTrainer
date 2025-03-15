using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LanguageTrainer.Data;

namespace LanguageTrainer.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null) return View();
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            Debug.Assert(user != null, nameof(user) + " != null");
            ViewBag.User = user;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}