namespace IspProject.Models
{
    public class Payment
    {
        public int idPayment { get; set; }

        public double amount { get; set; }

        public DateTime date { get; set; }
        

        public int idAccount;

        public Account account;
    }
}
