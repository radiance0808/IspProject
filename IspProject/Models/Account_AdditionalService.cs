namespace IspProject.Models
{
    public class Account_AdditionalService
    {
        public int idAccount { get; set; }

        public int idAdditionalService { get; set; }


        public AdditionalService AdditionalService { get; set; }
        public Account account { get; set; }


    }
}