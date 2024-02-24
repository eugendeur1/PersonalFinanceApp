namespace PersonalFinanceAppMVC.Models
{
    public class MyTransaction
    {
        public int Id { get; set; } 
        public DateTime DateOfTransaction { get; set; }    
        public bool TypeOfTransaction { get; set; } 
        public int TransactionAmount { get; set; } 
        public string Location { get; set; }    
        public bool MethodOfPayment { get; set; }
        public string Description {  get; set; }

    }
}
