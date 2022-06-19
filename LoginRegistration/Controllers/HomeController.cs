using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegistration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("/Login")]
    public IActionResult Login()
    {
        return View();
    }
    [HttpGet("Success")]
    public IActionResult Success()
    {
        if(HttpContext.Session.GetInt32("UserId") == null){
            return RedirectToAction("Index");
        }

        return View();
    }
    
    [HttpPost("new/process")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(_context.Users.Any(a => a.Email == newUser.Email)){
                // Already in the db
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            
                _context.Add(newUser);
                _context.SaveChanges();
            return RedirectToAction("Success");
            
            
        } 
        else 
        {
            return View("Index");
        }
    }
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("/login/process")]
    public IActionResult LoginUser(LogUser loginUser)
    {
        if(ModelState.IsValid)
        {
            // Find email
            User userInDb = _context.Users.FirstOrDefault(a => a.Email == loginUser.Email);
            if(userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Login Attempt!");
                return View("Login");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();

            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);

            if(result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Login Attempt!");
                return View("Login");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);

            return RedirectToAction("Success");

        }
        else
        {
            return View("Login");
        }
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
