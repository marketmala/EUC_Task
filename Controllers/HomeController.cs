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
using EUCTask.Interfaces;

namespace EUCTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IRegistrationService registrationService;

        private List<Country> countries;

        public HomeController(ILogger<HomeController> logger, IRegistrationService registrationService)
        {
            this.logger = logger;
            this.registrationService = registrationService;

            countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(x => new RegionInfo(x.LCID))
                .Distinct()
                .OrderBy(x => x.EnglishName)
                .Select(x => new Country { Code = x.Name, Name = x.EnglishName }).ToList();
        }

        public async Task<IActionResult> Registration()
        {
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration r)
        {
            ViewBag.Countries = countries;
            if (ModelState.IsValid)
            {
                var registrationData = await registrationService.CreateRegistrationAsync(r);
                if(registrationData != null)
                {
                    
                }
                else
                {

                }
                return View(r);
            }
            else
            {
                return View(r);
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
