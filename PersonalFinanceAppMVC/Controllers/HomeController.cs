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
            var myListOfCards = new List<MyCard>();

            var brownCard = new MyCard()
            {
                CardNumber = 1234567890,
                FullName = "Eugen Deur",
                ExpirationDate = DateTime.Parse("2024-02-23"),
                Visa = true
            };
            var redCard = new MyCard()
            {
                CardNumber = 1234567891,
                FullName = "Tomislav Tolj ",
                ExpirationDate = DateTime.Parse("2024-04-23"),
                Visa = false
            };
            var greenCard = new MyCard()
            {
                CardNumber = 1234567892,
                FullName = "Luka Modri",
                ExpirationDate = DateTime.Parse("2024-05-23"),
                Visa = false
            };
            var whiteCard = new MyCard()
            {
                CardNumber = 1234567893,
                FullName = "Albert Einstein",
                ExpirationDate = DateTime.Parse("2024-06-23"),
                Visa = true
            };
            myListOfCards.Add(brownCard);
            myListOfCards.Add(redCard);
            myListOfCards.Add(greenCard);
            myListOfCards.Add(whiteCard);

            if (myListOfCards.Count > 8)
            {
                myListOfCards = myListOfCards.Take(8).ToList();
            }

            return View(myListOfCards);
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
