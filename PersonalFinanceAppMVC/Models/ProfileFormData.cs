using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceAppMVC.Models
{
    public class ProfileFormData
    {
        public string ime_prezime { get; set; }
        public string? email { get; set; }

       
        //[StringLength(10, MinimumLength = 9)]
        //[RegularExpression(@"[0-9]*")]
        public string telefon { get; set; }
        public string lokacija { get; set; }
        public string jezik { get; set; }
    }

}
