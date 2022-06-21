using IspProject.DTOs;
using IspProject.Models;

namespace IspProject.Services.PotentialClient
{
    public class PotentialClientService : IPotentialClientService
    {
        private readonly AccountDbContext _context;

        public PotentialClientService(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<CreatePotentialClientResponse> CreatePotentialClient(CreatePotentialClientRequest request)
        {
            var potentialClient = new Models.PotentialClient()
            {
                name = request.name,
                phoneNumber = request.phoneNumber,
                address = request.address,
                email = request.email, 
                idPackage = request.idPackage,
                idTypeOfHouse = request.idTypeOfHouse
                
            };
            await _context.potentialClients.AddAsync(potentialClient);
            await _context.SaveChangesAsync();
            return new CreatePotentialClientResponse()
            {
                idPotentialClient = potentialClient.idPotentialClient,
                name = potentialClient.name
            };
        }
    }
}
