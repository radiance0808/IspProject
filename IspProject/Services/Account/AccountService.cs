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

        public async Task ChangeNotificationType(int idUser, NotificationType newNotificationType)
        {
            var account = await _context.accounts.FirstOrDefaultAsync(e => e.idUser == idUser);
            account.NotificationType = newNotificationType;

            await _context.SaveChangesAsync();
        }

        public async Task ChangePackage(int idUser, int newPackage)
        {
            var account = await _context.accounts.FirstOrDefaultAsync(e => e.idUser == idUser);
            account.idPackage = newPackage;

            await _context.SaveChangesAsync();
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

        public async Task<List<SearchAccountsByPackageResponse>> SearchAccountsByPackage(int idPackage)
        {
            var package = await _context.packages.FirstOrDefaultAsync(p => p.idPackage == idPackage);
            var accounts = await _context.accounts.Where(e => e.idPackage == idPackage).Select(e => new SearchAccountsByPackageResponse
            {
                idAccount = e.idAccount,
                firstName = e.user.firstName,
                lastName = e.user.lastName,
                packageName = package.nameOfPackage
            }).OrderBy(e => e.idAccount).ToListAsync();
            return accounts;
        }
    }
}
