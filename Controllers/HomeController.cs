using EUCTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace EUCTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private List<Country> countries;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(x => new RegionInfo(x.LCID))
                .Distinct()
                .OrderBy(x => x.EnglishName)
                .Select(x => new Country { Code = x.Name, Name = x.EnglishName }).ToList();
        }

        public IActionResult Index()
        {
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Registration r)
        {
            ViewBag.Countries = countries;
            if (ModelState.IsValid)
            {
                return View(r);
            }
            else
            {
                return View();
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
}
