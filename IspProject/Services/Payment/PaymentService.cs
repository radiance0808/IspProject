using IspProject.DTOs.Payment;
using IspProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IspProject.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly AccountDbContext _context;

        public PaymentService(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request, int idUser)
        {
            var account = await _context.accounts.FirstOrDefaultAsync(e => e.idUser == idUser);

            var payment = new Models.Payment()
            {
                idAccount = account.idAccount,
                amount = request.amount,
                date = request.date
            };

            
            account.balance += request.amount;

            await _context.payments.AddAsync(payment);
            await _context.SaveChangesAsync();


            return new CreatePaymentResponse()
            {
                idPayment = payment.idPayment,
                idAccount = account.idAccount,
                newBalance = account.balance
            };
        }
    }
}
