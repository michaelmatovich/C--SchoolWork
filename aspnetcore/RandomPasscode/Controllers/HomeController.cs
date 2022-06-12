using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public string GeneratePasscode()
    {
        Random rdm = new Random();

        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string passcode = "";

        for (int i = 0; i < 14; i++)
        {
            passcode = passcode + chars[rdm.Next(0, 36)].ToString();
        }
        return passcode;
    }
    public IActionResult Index()
    {

        int counter = (HttpContext.Session.GetInt32("Count") ?? 0) + 1;
        string passcode = GeneratePasscode();

        HttpContext.Session.SetString("Passcode", passcode);
        HttpContext.Session.SetInt32("Count", counter);

        return View();
    }

    [HttpGet("GetPassword")]
    public ActionResult<PasswordResult> GetPassword()
    {
        int counter = (HttpContext.Session.GetInt32("Count") ?? 0) + 1;
        string passcode = GeneratePasscode();

        HttpContext.Session.SetString("Passcode", passcode);
        HttpContext.Session.SetInt32("Count", counter);

        return new PasswordResult { Password = passcode, Counter = counter };
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
public class PasswordResult
{
    public string? Password { get; set; }
    public int Counter { get; set; }
}
