﻿namespace PersonalFinanceAppMVC.Models
{
    public class MyCard
    {
        public int CardNumber { get; set; }
        public string FullName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Visa { get; set; }
        public string username { get; set; }
        public string cvv { get; set; }
        public DateTime CardIssuanceDate { get; set; }
    }
   
}
