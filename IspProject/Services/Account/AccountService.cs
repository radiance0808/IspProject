using IspProject.DTOs.Account;
using IspProject.JWT;
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

        public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request)
        {
            var exists = await _context.users.AnyAsync(e => e.login == request.login);
            if (exists) throw new Exception("Such login exists!");

            var phoneExists = await _context.users.AnyAsync(e => e.phoneNumber == request.phoneNumber);
            if (phoneExists) throw new Exception("Such phone number exists!");

            var emailExists = await _context.users.AnyAsync(e => e.emailAdress == request.emailAddress);
            if (emailExists) throw new Exception("Such email address exists!");

            var passportExists = await _context.users.AnyAsync(e => e.passportId == request.passportId);
            if (passportExists) throw new Exception("Such email address exists!");

            var user = new User()
            {
                firstName = request.firstName,
                lastName = request.lastName,
                login = request.login,
                password = request.password,
                phoneNumber = request.phoneNumber,
                emailAdress = request.emailAddress,
                passportId = request.passportId,
                Role = Roles.client,
                RefreshToken = ""
            };

            await _context.users.AddAsync(user);

            var address = new Address()
            {
                city = request.city,
                street = request.street,
                houseNumber = request.houseNumber,
                apartmentNumber = request.apartmentNumber,
                idTypeOfHouse = request.idTypeOfHouse
            };

            await _context.addresses.AddAsync(address);

            var account = new Models.Account()
            {
                user = user,
                idPackage = request.idPackage,
                Address = address,
                balance = 0.0,
                idEquipment = request.idEquipment,
                NotificationType = request.notificationType

            };

            await _context.accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return new CreateAccountResponse()
            {
                login = user.login,
                password = user.password
            };

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
                equipment = account.Equipment.routerName,
                package = account.Package.nameOfPackage,
                isActive = account.isActive
            };
        }

        public async Task<List<SearchAccountsByPackageResponse>> SearchAccountsByPackage(int idPackage)
        {
            
            var accounts = await _context.accounts.Where(e => e.idPackage == idPackage).Select(e => new SearchAccountsByPackageResponse
            {
                idAccount = e.idAccount,
                firstName = e.user.firstName,
                lastName = e.user.lastName,
                packageName = e.Package.nameOfPackage,
            }).OrderBy(e => e.idAccount).ToListAsync();
            return accounts;
        }
    }
}
