using IspProject.DTOs;

namespace IspProject.Services.PotentialClient
{
    public interface IPotentialClientService
    {
        Task<CreatePotentialClientResponse> CreatePotentialClient(CreatePotentialClientRequest request);
    }
}
