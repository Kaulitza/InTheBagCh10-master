using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InTheBag.Controllers
{
    public class GenieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult Create(string GenieName, int Age, int WishesGranted)
        {
            if (WishesGranted > 5000 || Age > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }*/
        [HttpPost]
        public IActionResult Create(string GenieName)
        {
            int numberGranted = Int32.Parse(Request.Form["WishesGranted"]);
            int Years = Int32.Parse(Request.Form["Age"]);
            if (numberGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
        // type Genie/Create2/name/age/yearsExperience
        // example: /Genie/Create2/Ayew/25/483
        public IActionResult Create2()
        {
            var Name = RouteData.Values["GenieName"];
            int Years = Int32.Parse((string)RouteData.Values["Age"]);
            int numberGranted = Int32.Parse((string)RouteData.Values["WishesGranted"]);

            if (numberGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
        public IActionResult Perks()
        {
            ViewBag.Posted = false;
            return View();
        }
        [HttpPost]
        public IActionResult Perks(string[] perk)
        {
            ViewBag.Posted = true;
            //ViewBag.Perks = Request.Form["perk"];
            ViewBag.Perks = perk;
            return View();
        }
    }
}
