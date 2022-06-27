using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    /***********************************************************************
    *                               LOGIN/REG                              *
    ***********************************************************************/
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("/Login")]
    public IActionResult Login()
    {
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
    /***********************************************************************
    *                               DASHBOARD                              *
    ***********************************************************************/

    public IActionResult Success()
    {
        if(HttpContext.Session.GetInt32("UserId") == null){
            return RedirectToAction("Index");
        }
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        List<Wedding> Weddings = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.User).ToList();
        return View("Dashboard", Weddings);
    }


    /***********************************************************************
    *                               WEDDINGS                             *
    ***********************************************************************/

    [HttpGet("/wedding/new")]
    public IActionResult WeddingForm()
    {
        if(HttpContext.Session.GetInt32("UserId") == null){
            return RedirectToAction("Index");
        }

        return View();
    }
    [HttpPost("/wedding/new/process")]
    public IActionResult AddWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            newWedding.Creator = HttpContext.Session.GetInt32("UserId");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        return View("WeddingForm");
    }
    [HttpGet("/wedding/delete/{weddingId}")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding weddingToDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);

        _context.Remove(weddingToDelete);
        _context.SaveChanges();
        return RedirectToAction("Success");

    }
    [HttpGet("/wedding/{weddingId}")]
    public IActionResult OneWedding(int weddingId)
    {
        int? UserId = HttpContext.Session.GetInt32("UserId");
        if (UserId == null)
        {
            return RedirectToAction("Home");
        }
        
        Wedding oneWedding = _context.Weddings.Include(wed => wed.Guests).ThenInclude(guest => guest.User).FirstOrDefault(w => w.WeddingId == weddingId);
        return View("OneWedding", oneWedding);
    }

    /***********************************************************************
    *                               GUESTS                                 *
    ***********************************************************************/

    [HttpGet("/wedding/rsvp/{weddingId}")]
    public IActionResult RSVP(int weddingId)
    {
        int? UserId = HttpContext.Session.GetInt32("UserId");
        Guest newRSVP = new Guest();
        newRSVP.WeddingId = weddingId;
        newRSVP.UserId = UserId;
        _context.Guests.Add(newRSVP);
        _context.SaveChanges();
        return RedirectToAction("Success");
    }

    [HttpGet("/wedding/unrsvp/{weddingId}")]
    public IActionResult UNRSVP(int weddingId)
    {        
        int? UserId = HttpContext.Session.GetInt32("UserId");        
        Guest removeRSVP = _context.Guests.Where(wed => wed.WeddingId == weddingId).FirstOrDefault(guest => guest.UserId == UserId);

        _context.Remove(removeRSVP);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
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
