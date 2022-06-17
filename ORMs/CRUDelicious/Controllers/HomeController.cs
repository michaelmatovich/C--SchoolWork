using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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
        ViewBag.AllDishes = _context.Dishes.Take(5).ToList();
        return View();
    }
    [HttpGet("New")]
    public IActionResult New()
    {
        return View();
    }
    [HttpPost("new/process")]
    public IActionResult AddDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        else
        {
            return View("New");
        }
    }
    [HttpPost("edit/process/{dishId}")]
    public IActionResult UpdateDish(int dishId, Dish updatedDish)
    {
        Dish oldDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        oldDish.Name = updatedDish.Name;
        oldDish.Chef = updatedDish.Chef;
        oldDish.Tastiness = updatedDish.Tastiness;
        oldDish.Calories = updatedDish.Calories;
        oldDish.Description = updatedDish.Description;
        oldDish.UpdatedAt = DateTime.Now;
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet("/dish/delete/{dishId}")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish dishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        _context.Dishes.Remove(dishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet("/edit/{dishId}")]
    public IActionResult Edit(int dishId)
    {
        Dish dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);

        return View(dishToEdit);    
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
