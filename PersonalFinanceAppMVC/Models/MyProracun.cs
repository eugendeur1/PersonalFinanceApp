using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceAppMVC.Models
{
    public class MyProracun
    {
        public int Id { get; set; }
        public string budzet { get; set; }
        public Month Month { get; set; }
        public Department Department { get; set; }
    }

    public enum Month
    {
        January, February, March, April, May, June, July, August, September, October, November, December
    }

    public enum Department
    {
        Finance, Videogames, Program 
    }
}
