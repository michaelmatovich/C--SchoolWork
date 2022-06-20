using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    /****************************************************
                        INDEX/CHEF ROUTE
    *****************************************************/
    public IActionResult Index()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }
    /****************************************************
                        CHEF FORM
    *****************************************************/
    [HttpGet("/chef/add")]
    public IActionResult ChefForm()
    {
        return View();
    }
    /****************************************************
                        CHEF POST
    *****************************************************/
    [HttpPost("/chef/add/process")]
    public IActionResult AddChef(Chef newChef)
    {
        if(ModelState.IsValid){
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        else
        {
            return View("ChefForm");
        }
    }   
    /****************************************************
                        DISH ROUTE
    *****************************************************/    
    [HttpGet("Dishes")]
    public IActionResult Dishes()
    {
        ViewBag.AllDishes = _context.Dishes.ToList();
        return View();
    }
    /****************************************************
                        DISH FORM
    *****************************************************/
    [HttpGet("/dish/add")]
    public IActionResult DishForm()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }
    /****************************************************
                        DISH POST
    *****************************************************/
    [HttpPost("/dish/add/process")]
    public IActionResult AddDish(Dish newDish)
    {
        
        if(ModelState.IsValid){
            _context.Add(newDish);
            _context.SaveChanges();
            
            return RedirectToAction("Dishes");
        } 
        else
        {     
            
            return View("DishForm");
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
