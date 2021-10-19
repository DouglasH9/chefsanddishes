using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using chefsanddishes.Models;
using Microsoft.EntityFrameworkCore;
namespace chefsanddishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllChefs = _context.Chefs
                .OrderBy(chef => chef.LName)
                .ToList();
            return View();
        }

        [HttpGet("addchef")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("PushChef")]
        public IActionResult PushChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet("Dishes")]
        public IActionResult MakeDish()
        {
            ViewBag.AllDishes = _context.Dishes
                .OrderBy(dish => dish.Tastiness)
                .ToList();
            return View("Dishes");
        }

        [HttpGet("addDish")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = _context.Chefs
                .OrderByDescending(chef => chef.LName)
                .ToList();
            return View("AddDish");
        }

        [HttpPost("pushdish")]
        public IActionResult PushDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }


// =============================================================================================================
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
}
