using Microsoft.EntityFrameworkCore;

namespace IspProject.Models
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }

        public DbSet<Account_AdditionalService> account_AdditionalServices { get; set; }
        
        public DbSet<AdditionalService> additionalServices { get; set; }

        public DbSet<Administrator> administrators { get; set; }

        public DbSet<Adress> adresses { get; set; }

        public DbSet<Package> packages { get; set; }

        public DbSet<Script> scripts { get; set; }

        public DbSet<Script_AdditionalService> script_additionalServices { get; set;}

        public DbSet<SupportTicket> supportTickets { get; set; }

        public DbSet<Traffic> traffics { get; set; }

        public DbSet<TypeOfHouse> typeHouses { get; set; }

        public DbSet<User> users { get; set; }

        public AccountDbContext() { }

        public AccountDbContext(DbContextOptions options)
            : base(options)
        {

        }




    }
}
