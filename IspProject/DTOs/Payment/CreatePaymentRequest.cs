using System.ComponentModel.DataAnnotations;

namespace IspProject.DTOs.Payment
{
    public class CreatePaymentRequest
    {
        [Required]
        public double amount { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
