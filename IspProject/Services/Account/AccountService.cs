using IspProject.DTOs.Account;
using IspProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IspProject.Services.Account
{
    public class AccountService : IAccountService
    {

        private readonly AccountDbContext _context;
        public AccountService(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<GetAccountInfoResponse> GetAccountInfo(int idUser)
        {
            var account = await _context.accounts.FirstOrDefaultAsync(e => e.idUser == idUser);
            var equipment = await _context.equipments.FirstOrDefaultAsync(e => e.idEqupment == account.idEquipment);
            var package = await _context.packages.FirstOrDefaultAsync(e => e.idPackage == account.idPackage);

            return new GetAccountInfoResponse()
            {
                balance = account.balance,
                notificationType = account.NotificationType.ToString(),
                equipment = equipment.routerName,
                package = package.nameOfPackage,
                isActive = account.isActive
            };
        }
    }
}
