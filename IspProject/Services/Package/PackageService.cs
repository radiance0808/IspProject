using IspProject.Models;

namespace IspProject.Services.Package
{
    public class PackageService : IPackageService
    {
        private readonly AccountDbContext _context;

        public PackageService(AccountDbContext context)
        {
            _context = context;
        }



    }
}
