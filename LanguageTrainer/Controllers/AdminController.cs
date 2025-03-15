using LanguageTrainer.Data;
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


}