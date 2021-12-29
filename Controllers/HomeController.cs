using EUCTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IRegistrationService registrationService;

        private List<Country> countries;

        public HomeController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;

            countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(x => new RegionInfo(x.LCID))
                .Distinct()
                .OrderBy(x => x.EnglishName)
                .Select(x => new Country { Code = x.Name, Name = x.EnglishName }).ToList();
        }

        public IActionResult Registration()
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
                    await registrationService.SaveToFile(registrationData);
                    ViewBag.Success = true;
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ViewBag.Success = false;
                    return View();
                }
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
