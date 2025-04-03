using LanguageTrainer.Data;
using LanguageTrainer.Models;
using Microsoft.AspNetCore.Mvc;
namespace LanguageTrainer.Controllers;

public class AdminController(ApplicationDbContext context) : Controller
{
    public IActionResult PendingUsers()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            return RedirectToAction("Login", "User");
        }

        var user = context.Users.FirstOrDefault(u => u.Id == userId);
        if (user is not { IsAdmin: true })
        {
            return Unauthorized();
        }

        var pendingUsers = context.Users.Where(u => !u.IsApproved).ToList();
        return View(pendingUsers);
    }
    
    public IActionResult ApproveUser(int id)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return RedirectToAction("PendingUsers");
        user.IsApproved = true;
        context.SaveChanges();

        return RedirectToAction("PendingUsers");
    }


    public IActionResult AdministrationPanel()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            return RedirectToAction("Login", "User");
        }

        var user = context.Users.FirstOrDefault(u => u.Id == userId);
        if (user is not { IsAdmin: true })
        {
            return Unauthorized();
        }
        return View(user);
    }
    
    public IActionResult WordManagement()
    {
        var categories = context.Categories.ToList();
        ViewBag.Categories = categories;
        return View();
    }
    
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            context.Categories.Add(category);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Kategoria została dodana pomyślnie!";
            return RedirectToAction("WordManagement");
        }

        return View(category);
    }

}