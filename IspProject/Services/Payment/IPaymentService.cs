using IspProject.DTOs.Payment;

namespace IspProject.Services.Payment
{
    public interface IPaymentService
    {
        Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request, int idAccount);
    }
}
