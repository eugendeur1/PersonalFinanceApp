using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAppMVC.Models;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace PersonalFinanceAppMVC.Controllers
{
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

        public IActionResult Tomo(int showReportForMonth)
        {
            var monthText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(showReportForMonth);
            Console.WriteLine(monthText);
            ViewBag.ImeReporta = monthText;

            int[] poljeBrojevaZaTjedan = { 1, 22, 3, 44, 5, 66, 7 };
            ViewBag.PoljeBrojeva = poljeBrojevaZaTjedan;
            return View("Tomo");
            //if (allow)
            //    return View("Tomo");
            //else
            //    return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
