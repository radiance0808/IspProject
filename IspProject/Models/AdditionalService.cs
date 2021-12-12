namespace IspProject.Models
{
    public class AdditionalService
    {
        public int idAdditionalService { get; set; }
        
        public string additionalService { get; set; }

        public double additionalPrice { get; set; }

        public virtual ICollection<Account_AdditionalService> Account_AdditionalServices { get; set; }

        public virtual ICollection<Script_AdditionalService> Script_AdditionalServices { get; set; }
    }
}