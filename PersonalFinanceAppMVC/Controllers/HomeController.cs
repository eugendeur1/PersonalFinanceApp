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

        public IActionResult Card(string searchText, int year, bool? Visa)
        {
            var allCardsFromDb = DbTables.Cards;

            if (!string.IsNullOrEmpty(searchText))
            {
                allCardsFromDb = allCardsFromDb.Where(card =>
                    card.FullName.Contains(searchText) ||
                    card.CardNumber.ToString().Contains(searchText) ||
                    card.ExpirationDate.ToString().Contains(searchText)
                ).ToList();
            }


            var filteredCards = allCardsFromDb.Where(card =>
                (year == 0 || card.ExpirationDate.Year == year) &&
                (!Visa.HasValue || card.Visa == Visa.Value)
            ).ToList();

            ViewBag.SelectedYear = year;
            ViewBag.SelectedVisa = Visa;
            ViewBag.SearchText = searchText;


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
            myListOfProracuni = myListOfProracuni.OrderByDescending(x => x.Month).ToList();
            return View(myListOfProracuni);
        }
        [HttpPost]
        public IActionResult Proracun(MyProracun data)
        {
            //dodavanje +1 na najveci Id a to je broj 3, i to vrijedi za svaik idući!!!
            int maxId = DbTables.Proracuni.Max(p => p.Id);

            data.Id = maxId + 1;
            
            if (!Regex.IsMatch(data.budzet, @"^[1-9][0-9]+$"))
            {
                return RedirectToAction("Error", new { message = "The input can only be positive number that cant start with 0" });
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
        public IActionResult Detalji(int id)
        {
            var proracun = DbTables.Proracuni.FirstOrDefault(p => p.Id == id);
            if (proracun == null)
            {
                return RedirectToAction("Error", new { message = "Budget item not found." });
            }
            return View(proracun);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var proracun = DbTables.Proracuni.FirstOrDefault(p => p.Id == id);
            if (proracun != null)
            {
                DbTables.Proracuni.Remove(proracun);
            }
            return RedirectToAction("Proracun");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var proracun = DbTables.Proracuni.FirstOrDefault(p => p.Id == id);
            if (proracun == null)
            {
                return RedirectToAction("Error", new { message = "Budget item not found." });
            }
            return View(proracun); // Prikazujemo view za uređivanje s postojećim proračunom
        }

        [HttpPost]
        public IActionResult Edit(MyProracun updatedProracun)
        {
            if (!Regex.IsMatch(updatedProracun.budzet, @"^[1-9][0-9]+$"))
            {
                return RedirectToAction("Error", new { message = "Budget must be a positive integer." });
            }

            var proracun = DbTables.Proracuni.FirstOrDefault(p => p.Id == updatedProracun.Id);
            if (proracun == null)
            {
                return RedirectToAction("Error", new { message = "Budget item not found." });
            }

            var existingMonths = DbTables.Proracuni.Where(p => p.Month == updatedProracun.Month && p.Id != updatedProracun.Id).ToList();
            if (existingMonths.Any())
            {
                return RedirectToAction("Error", new { message = "You cannot choose a month that is already taken." });
            }

            // Ažuriramo svojstva proračuna na temelju unesenih vrijednosti
            proracun.budzet = updatedProracun.budzet;
            proracun.Month = updatedProracun.Month;
            proracun.Department = updatedProracun.Department;

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
            if (string.IsNullOrEmpty(data.telefon))
            {
                return RedirectToAction("Error", new { message = "Phone number cant be empty" });
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
