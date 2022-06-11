using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidation.Models;

namespace DojoSurveyValidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("process")]

    public IActionResult process(Coder newCoder)
    {
        if(ModelState.IsValid)
        {
            //Passed our validations
            return RedirectToAction("Success", newCoder);
        }
        else
        {
            //If validations fail
            return View("Index");
        }
    }

    [HttpGet("Success")]
    public IActionResult Success (Coder newCoder)
    {        
        return View(newCoder);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
