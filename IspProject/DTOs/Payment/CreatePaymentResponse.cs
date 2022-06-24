namespace IspProject.DTOs.Payment
{
    public class CreatePaymentResponse
    {
        public int idPayment { get; set; }
        public int idAccount { get; set; }

        public double newBalance { get; set; }


    }
}
