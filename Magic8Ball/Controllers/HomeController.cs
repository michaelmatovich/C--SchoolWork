using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Magic8Ball.Models;
using Microsoft.AspNetCore.Http;


namespace Magic8Ball.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string GenerateFortune()
    {
        Random rdm = new Random();

        string[] fortuneList = {
            "Yes",
            "No",
            "Maybe",
            "Why Not",
            "Absolute Not",
            "Of Course!",
            "You got this",
            "You dont got this",
            "Its possible",
            "Its not possible",
            "Dont even try it"
        };

        string result = fortuneList[rdm.Next(0,11)];

        return result;
    }

    public IActionResult Index()
    {
        int counter = (HttpContext.Session.GetInt32("Count") ?? 0);
        HttpContext.Session.SetInt32("Count", counter);             
        
        return View();
    }

    [HttpGet("GetFortune")]
    public ActionResult<Fortune> GetFortune()
    {
        int count = (HttpContext.Session.GetInt32("Count") ?? 0) + 1;
        string fort = GenerateFortune();
        HttpContext.Session.SetInt32("Count", count);

        return new Fortune {fortune = fort, counter = count};
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

public class Fortune 
{
    public string? fortune {get;set;}
    public int counter {get;set;}
}
