using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAppMVC.Data;
using PersonalFinanceAppMVC.Models;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PersonalFinanceAppMVC.Controllers
{
    public class HomeController : Controller
    {
        static string MyUsername = "eugen.deur";
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

        public IActionResult Card(int year, bool? Visa)
        {
            var allCardsFromDb = DbTables.Cards;

           
            var filteredCards = allCardsFromDb.Where(card =>
                (year == 0 || card.ExpirationDate.Year == year) && 
                (!Visa.HasValue || card.Visa == Visa.Value)       
            ).ToList();

            return View(filteredCards);
        }
        public IActionResult Placanje()
        {
            var myListOfPayments = DbTables.Transactions;

            int sumaTransakcija = myListOfPayments.Sum(t => t.TransactionAmount);
            int brojTransakcija = myListOfPayments.Count;
            ViewBag.BrojTransakcija = brojTransakcija;
            ViewBag.SumaTransakcija = sumaTransakcija;
            
            return View(myListOfPayments);  
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
        [HttpGet]
        public IActionResult Profil()
        {
            var lastProfile = DbTables.UserProfiles.LastOrDefault();
            return View(lastProfile);
           
        }

        [HttpPost]
        public IActionResult Profil(ProfileFormData data)
        {
            //if (data.telefon == "")
            //    return View(data);
            if (ModelState.IsValid)
            {
               
                DbTables.UserProfiles.Clear();
                DbTables.UserProfiles.Add(data);

                return RedirectToAction("Profil");
            }


            return RedirectToAction("Error");
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
