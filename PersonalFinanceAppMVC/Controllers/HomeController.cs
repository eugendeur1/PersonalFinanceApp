using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAppMVC.Data;
using PersonalFinanceAppMVC.Models;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
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

            ViewBag.SelectedYear = year;
            ViewBag.SelectedVisa = Visa;

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
            

            return View( );
        }
        [HttpGet]
        public IActionResult Proracun()
        {
            var myListOfProracuni = DbTables.Proracuni;
            return View(myListOfProracuni);
        }
        [HttpPost]
        public IActionResult Proracun(MyProracun data)
        {
            if (!Regex.IsMatch(data.budzet, @"^[1-9][0-9]+$"))
            {
                return RedirectToAction("Error", new { message = "Phone number must contain only numeric characters." });
            }
            List<MyProracun> existingMonths = DbTables.Proracuni.ToList();

            foreach (var item in existingMonths)
            {
                if (item.Month == data.Month)
                {
                    return RedirectToAction("Error", new { message = "You cannot choose a month that is already taken." });
                }
            }
            DbTables.Proracuni.Add(data);
            return RedirectToAction("Proracun");
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
            if (string.IsNullOrWhiteSpace(data.ime_prezime))
            {
                return RedirectToAction("Error", new { message = "Full name is required." });
            }
            if (!Regex.IsMatch(data.ime_prezime, @"^[a-zA-Z\s]+$"))
            {
                return RedirectToAction("Error", new { message = "Full name must contain only letters and spaces." });
            }
            if (data.ime_prezime.Length > 30)
            {
                return RedirectToAction("Error", new { message = "Full name cannot contain more than 30 letters and spaces." });
            }
            if (string.IsNullOrWhiteSpace(data.email) || !Regex.IsMatch(data.email, @"^[^@\s]+@[^@\s]+$"))
            {
                return RedirectToAction("Error", new { message = "Email must contain text on both sides of '@'." });
            }
            if (!Regex.IsMatch(data.telefon, @"^[0-9]+$"))
            {
                return RedirectToAction("Error", new { message = "Phone number must contain only numeric characters." });
            }
            if (data.lokacija == "Croatia")
            {
                if (string.IsNullOrWhiteSpace(data.telefon) || !int.TryParse(data.telefon, out _) || data.telefon[0] != '0')
                {
                    return RedirectToAction("Error", new { message = "Phone number for Croatia must be a number and start with '0' and cant contain more than 10 numbers." });
                }
                if (data.telefon.Length > 10)
                {
                    return RedirectToAction("Error", new { message = "Phone number for Croatia must contain exactly 10 digits." });
                }

            }
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            DbTables.UserProfiles.Clear();
            DbTables.UserProfiles.Add(data);

            return RedirectToAction("Profil");
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
        public IActionResult Error(string message)
        {
            ViewData["ErrorMessage"] = message ?? "An error occurred.";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
