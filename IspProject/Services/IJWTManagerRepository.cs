using IspProject.Models;

namespace IspProject.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Administrator administrators);
    }
}
