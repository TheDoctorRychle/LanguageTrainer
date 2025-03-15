using LanguageTrainer.Data;
using LanguageTrainer.Models;
using Microsoft.AspNetCore.Mvc;


namespace LanguageTrainer.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }


    //////////////////Rejestracja////////////////////

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [HttpPost]
    public IActionResult Register(string username, string email, string password)
    {
        var pendingUsersCount = _context.Users.Count(u => !u.IsApproved);
        if (pendingUsersCount >= 20)
        {
            ViewBag.ErrorMessage = "Nie możemy przyjąć nowych użytkowników, ponieważ lista oczekujących jest pełna.";
            return View();
        }
        
        if (_context.Users.Any(u => u.Username == username || u.Email == email))
        {
            ViewBag.ErrorMessage = "Nazwa użytkownika lub email jest już zajęta.";
            return View();
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = hashedPassword,
            IsApproved = false,
            IsAdmin = false 
        };
        
        if (username == "Admin")
        {
            user.IsAdmin = true;
        }

        _context.Users.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    
    //////////////////Logowanie////////////////////
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
    
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) || !user.IsApproved)
        {
            ViewBag.ErrorMessage = "Niepoprawny login, hasło lub konto nie zostało zatwierdzone.";
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        return RedirectToAction("Index", "Home");
    }


    //////////////////Wylogowanie////////////////////
    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserId");
        return RedirectToAction("Index", "Home");
    }

}