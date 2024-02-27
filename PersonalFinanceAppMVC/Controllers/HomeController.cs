using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAppMVC.Data;
using PersonalFinanceAppMVC.Models;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;


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

        public IActionResult Card(int year, bool visa)
        {
            var allCardsFromDb = DbTables.Cards;
            /////////////////////////
            var filteredCards = new List<MyCard>();
            foreach (var card in allCardsFromDb)
            {
                if(card.ExpirationDate.Year == year)
                    filteredCards.Add(card);
            }

            return View(filteredCards);
        }
        public IActionResult Placanje()
        {
            var myListOfPayments = new List<MyTransaction>();

            var Transaction1 = new MyTransaction()
            {
                Id = 1,
                DateOfTransaction = DateTime.Parse("2024-01-03"),
                TypeOfTransaction = true,
                TransactionAmount = -100,
                Location = "bankomat x-y-z",
                MethodOfPayment = true,
                Description = "Isplata na bankomatu"
            };
            var Transaction2 = new MyTransaction()
            {
                Id = 2,
                DateOfTransaction = DateTime.Parse("2024-01-17"),
                TypeOfTransaction = true,
                TransactionAmount = -100,
                Location = "bankomat x-y-z",
                MethodOfPayment = true,
                Description = "Isplata na bankomatu"
            };
            var Transaction3 = new MyTransaction()
            {
                Id = 3,
                DateOfTransaction = DateTime.Parse("2024-01-23"),
                TypeOfTransaction = false,
                TransactionAmount = -100,
                Location = "Crujff d.o.o.",
                MethodOfPayment = false,
                Description = "Kupnja tenisica"
            };
            var Transaction4 = new MyTransaction()
            {
                Id = 4,
                DateOfTransaction = DateTime.Parse("2024-02-20"),
                TypeOfTransaction = false,
                TransactionAmount = -1000,
                Location = "Adidas d.o.o.",
                MethodOfPayment = false,
                Description = "Kupnja tenisica"
            };
            var Transaction5 = new MyTransaction()
            {
                Id = 5,
                DateOfTransaction = DateTime.Parse("2024-01-22"),
                TypeOfTransaction = true,
                TransactionAmount = -1000,
                Location = "bankomat x-y-z",
                MethodOfPayment = true,
                Description = "Isplata na bankomatu"
            };
            var Transaction6 = new MyTransaction()
            {
                Id = 6,
                DateOfTransaction = DateTime.Parse("2024-01-12"),
                TypeOfTransaction = false,
                TransactionAmount = -800,
                Location = "Nike d.o.o.",
                MethodOfPayment = false,
                Description = "Kupnja tenisica"
            };
            
            myListOfPayments .Add(Transaction1);
            myListOfPayments .Add(Transaction2);
            myListOfPayments .Add(Transaction3);
            myListOfPayments .Add(Transaction4);
            myListOfPayments .Add(Transaction5);
            myListOfPayments .Add(Transaction6);

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
            return View();
        }

        [HttpPost]
        public IActionResult Profil(ProfileFormData data)
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
