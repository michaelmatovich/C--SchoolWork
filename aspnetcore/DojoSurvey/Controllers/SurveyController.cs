using Microsoft.AspNetCore.Mvc; // service that brings in mvc functionality

namespace DojoSurvey.Controllers;    
    public class SurveyController : Controller  
    {   

        
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(string Name, string Location, string FavLanguage, string Comment)
        {   
            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.FavLanguage = FavLanguage;
            ViewBag.Comment = Comment;
            return View("Success");
        }

        [HttpGet("Success")]
        public ViewResult Success()
        {
            return View();
        }

        
    }

