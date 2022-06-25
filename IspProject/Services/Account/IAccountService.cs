using IspProject.DTOs.Account;

namespace IspProject.Services.Account
{
    public interface IAccountService
    {
        Task<GetAccountInfoResponse> GetAccountInfo(int idUser);
    }
}
