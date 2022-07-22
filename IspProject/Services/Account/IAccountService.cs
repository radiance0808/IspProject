using IspProject.DTOs.Account;
using IspProject.Models;

namespace IspProject.Services.Account
{
    public interface IAccountService
    {
        Task<GetAccountInfoResponse> GetAccountInfo(int idUser);

        Task ChangePackage(int idUser, int newPackage); 
        Task ChangeNotificationType(int idUser, NotificationType newNotificationType);

        Task<List<SearchAccountsByPackageResponse>> SearchAccountsByPackage(int idPackage);

        Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request);

        Task<List<string>> GetNotificationTypes();
    }
}
