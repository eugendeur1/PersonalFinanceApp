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

        public IActionResult Tomo() { 
            return View();
        }

        public IActionResult Card()
        {
            return View();
        }
        public IActionResult Placanje()
        {
            return View();
        }
        public IActionResult Statistika() {
            return View();
        }
        public IActionResult Izvjesce()
        {
            return View();
        }
        public IActionResult Proracun()
        {
            return View();
        }
        public IActionResult Profil()
        {
            return View();
        }
        public IActionResult Prihod()
        {
            return View();
        }
        public IActionResult Dugovi()
        {
            return View();
        }
        public IActionResult Racuni()
        {
            return View();
        }
        public IActionResult Ulaganja()
        {
            return View();
        }
        public IActionResult Postavke()
        {
            return View();
        }
        public IActionResult Info()
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
