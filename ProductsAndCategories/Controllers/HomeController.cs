using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    /*******************************************************
    *                   PRODUCTS
    ********************************************************/
    [HttpGet("products")]
    public IActionResult ProductForm()
    {
        ViewBag.Products = _context.Products.ToList();
        return View();
    }

    [HttpGet("products/{productId}")]
    public IActionResult OneProduct(int productId)
    {
        ViewBag.oneProduct = _context.Products.Include(p => p.Categories).ThenInclude(c => c.Category).FirstOrDefault(p => p.ProductId == productId);

        ViewBag.otherCategories = _context.Categories.Include(c => c.Products).ThenInclude(p => p.Product).Where(c => !(c.Products.Any(p => p.ProductId == productId)));

        return View("OneProduct");
    }
    
    
    [HttpPost("product/process")]
    public IActionResult AddProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("ProductForm");
        }

        ViewBag.Products = _context.Products.ToList();
        return View("ProductForm");
    }
    

    /*******************************************************
    *                   Categories
    ********************************************************/
    [HttpGet("categories")]
    public IActionResult CategoryForm()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost("category/process")]
    public IActionResult AddCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("CategoryForm");
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View("CategoryForm");
    }

    [HttpGet("category/{categoryId}")]
    public IActionResult OneCategory(int categoryId)
    {
        ViewBag.oneCategory = _context.Categories.Include(cat => cat.Products).ThenInclude(prod => prod.Product).FirstOrDefault(cat => cat.CategoryId == categoryId);

        ViewBag.otherProducts = _context.Products.Include(prod => prod.Categories).ThenInclude(cat => cat.Category).Where(prod => !(prod.Categories.Any(cat => cat.CategoryId == categoryId)));

        return View("OneCategory");
    }
    /*******************************************************
    *                   Association
    ********************************************************/

    [HttpPost("product/update/{productId}")]
    public IActionResult UpdateProduct(int productId, Association newAssociation)
    {
        newAssociation.ProductId = productId;
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return Redirect($"/products/{newAssociation.ProductId}");
    }
    [HttpPost("category/update/{categoryId}")]
    public IActionResult UpdateCategory(int categoryId, Association newAssociation)
    {
        newAssociation.CategoryId = categoryId;
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return Redirect($"/category/{newAssociation.CategoryId}");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
