using PersonalFinanceAppMVC.Models;

namespace PersonalFinanceAppMVC.Data
{
    public class DbTables
    {
        public static List<MyCard> Cards { get; set; } = new List<MyCard>() 
        {
            new MyCard() { CardNumber = 1234567890, FullName = "Eugen Deur", ExpirationDate = DateTime.Parse("2024-02-23"), Visa = true, Username = "eugen.deur" },
            new MyCard() { CardNumber = 1234567891, FullName = "Tomislav Tolj", ExpirationDate = DateTime.Parse("2024-01-25"), Visa = false, Username = "eugen.deur" },
            new MyCard() { CardNumber = 1234567892, FullName = "Luka Modrić", ExpirationDate = DateTime.Parse("2023-03-23"), Visa = false, Username = "eugen.deur" },
            new MyCard() { CardNumber = 1234567893, FullName = "Albert Einstein", ExpirationDate = DateTime.Parse("2022-01-23"), Visa = false , Username = "eugen.deur"},
        };
        public static List<MyTransaction> Transactions { get; set; }
        public static List<object> UserProfiles { get; set; }
    }
}
