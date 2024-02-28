using PersonalFinanceAppMVC.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonalFinanceAppMVC.Data
{
    public class DbTables
    {
        public static List<MyCard> Cards { get; set; } = new List<MyCard>() 
        {
            new MyCard() { CardNumber = 1234567890, FullName = "Eugen Deur", ExpirationDate = DateTime.Parse("2024-02-23"), Visa = true, Username = "eugen.deur" },
            new MyCard() { CardNumber = 1234567891, FullName = "Tomislav Tolj", ExpirationDate = DateTime.Parse("2024-01-25"), Visa = true, Username = "eugen.deur" },
            new MyCard() { CardNumber = 1234567892, FullName = "Luka Modrić", ExpirationDate = DateTime.Parse("2023-03-23"), Visa = false, Username = "eugen.deur" },
            new MyCard() { CardNumber = 1234567893, FullName = "Albert Einstein", ExpirationDate = DateTime.Parse("2022-01-23"), Visa = false , Username = "eugen.deur"},
        };
        public static List<MyTransaction> Transactions { get; set; } = new List<MyTransaction>()
        {
            new MyTransaction() { Id = 1,DateOfTransaction = DateTime.Parse("2024-01-03"), TypeOfTransaction = true,TransactionAmount = -100, Location = "bankomat x-y-z", MethodOfPayment = true,Description = "Isplata na bankomatu" },
            new MyTransaction() { Id = 2,DateOfTransaction = DateTime.Parse("2024-01-03"), TypeOfTransaction = true,TransactionAmount = -100, Location = "bankomat x-y-z", MethodOfPayment = true,Description = "Isplata na bankomatu"},
            new MyTransaction() { Id = 3,DateOfTransaction = DateTime.Parse("2024-01-03"), TypeOfTransaction = true,TransactionAmount = -300, Location = "bankomat x-y-z", MethodOfPayment = true,Description = "Isplata na bankomatu"},
            new MyTransaction() { Id = 4,DateOfTransaction = DateTime.Parse("2024-01-03"), TypeOfTransaction = true,TransactionAmount = -400, Location = "bankomat x-y-z", MethodOfPayment = true,Description = "Isplata na bankomatu"},
            new MyTransaction() { Id = 5,DateOfTransaction = DateTime.Parse("2024-01-03"), TypeOfTransaction = true,TransactionAmount = -100, Location = "bankomat x-y-z", MethodOfPayment = true,Description = "Isplata na bankomatu"},
            new MyTransaction() { Id = 6,DateOfTransaction = DateTime.Parse("2024-01-03"), TypeOfTransaction = true,TransactionAmount = -900, Location = "bankomat x-y-z", MethodOfPayment = true,Description = "Isplata na bankomatu"},
        };

        public static List<ProfileFormData> UserProfiles { get; set; } = new List<ProfileFormData>()
        {
            new ProfileFormData() { ime_prezime = "", email = "", telefon = "", lokacija = "", jezik = "" }
        };
    }
    
}
