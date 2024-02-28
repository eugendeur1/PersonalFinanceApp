using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceAppMVC.Models
{
    public class ProfileFormData
    {
        public string ime_prezime { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string lokacija { get; set; }
        public string jezik { get; set; }
    }

}
