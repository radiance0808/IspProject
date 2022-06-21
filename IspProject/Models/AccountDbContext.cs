using Microsoft.EntityFrameworkCore;

namespace IspProject.Models
{
    public class AccountDbContext : DbContext
    {

        public AccountDbContext() { }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {

        }
        public DbSet<Account> accounts { get; set; }

        public DbSet<Account_AdditionalService> account_AdditionalServices { get; set; }

        public DbSet<AdditionalService> additionalServices { get; set; }

        

        public DbSet<Address> addresses { get; set; }

        public DbSet<Package> packages { get; set; }

        public DbSet<Script> scripts { get; set; }

        public DbSet<Script_AdditionalService> script_additionalServices { get; set; }

        public DbSet<SupportTicket> supportTickets { get; set; }

        public DbSet<Traffic> traffics { get; set; }

        public DbSet<TypeOfHouse> typeHouses { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Equipment> equipments { get; set; }

        public DbSet<PotentialClient> potentialClients { get; set; }
        public DbSet<Payment> payments { get; set; }

        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Script>(opt =>
            {
                opt.HasKey(e => e.idScript);
                opt.Property(e => e.idScript).ValueGeneratedOnAdd();
                opt.Property(e => e.nameOfScript).HasMaxLength(50);
                opt.Property(e => e.scriptFile).HasMaxLength(40);
                opt.Property(e => e.createdAt).HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Package>(opt =>
            {
                opt.HasKey(e => e.idPackage);
                opt.Property(e => e.idPackage).ValueGeneratedOnAdd();
                opt.Property(e => e.nameOfPackage).HasMaxLength(50);
                opt.Property(e => e.price);
            });

            modelBuilder.Entity<TypeOfHouse>(opt =>
            {
                opt.HasKey(e => e.idTypeOfHouse);
                opt.Property(e => e.idTypeOfHouse).ValueGeneratedOnAdd();
                opt.Property(e => e.typeOfHouse).HasMaxLength(50);

            });

            modelBuilder.Entity<Traffic>(opt =>
            {
                opt.HasKey(e => e.idTraffic);
                opt.Property(e => e.idTraffic).ValueGeneratedOnAdd();
                opt.Property(e => e.application).HasMaxLength(40);
                opt.Property(e => e.consumptedTraffic);
                opt.Property(e => e.startTime);
                opt.Property(e => e.endTime);
                opt.HasOne(e => e.account).WithMany(e => e.Traffics).HasForeignKey(e => e.idAccount);


            });

            modelBuilder.Entity<Payment>(opt =>
            {
                opt.HasKey(e => e.idPayment);
                opt.Property(e => e.idPayment).ValueGeneratedOnAdd();
                opt.Property(e => e.amount);
                opt.Property(e => e.date);
                opt.HasOne(e => e.account).WithMany(e => e.Payments).HasForeignKey(e => e.idAccount);


            });

            modelBuilder.Entity<Address>(opt =>
            {
                opt.HasKey(e => e.idAddress);
                opt.Property(e => e.idAddress).ValueGeneratedOnAdd();
                opt.Property(e => e.address).HasMaxLength(50);
                opt.HasOne(e => e.typeOfHouse).WithMany(e => e.Addresses).HasForeignKey(e => e.idAddress);

            });

            modelBuilder.Entity<Equipment>(opt =>
            {
                opt.HasKey(e => e.idEqupment);
                opt.Property(e => e.idEqupment).ValueGeneratedOnAdd();
                opt.Property(e => e.routerName).HasMaxLength(30);
                opt.Property(e => e.description).HasMaxLength(200);
                
            });

            modelBuilder.Entity<PotentialClient>(opt =>
            {
                opt.HasKey(e => e.idPotentialClient);
                opt.Property(e => e.idPotentialClient).ValueGeneratedOnAdd();
                opt.Property(e => e.name).HasMaxLength(20);
                opt.Property(e => e.phoneNumber).HasMaxLength(20);
                opt.HasOne(e => e.address).WithMany(e => e.PotentialClients).HasForeignKey(e => e.idAddress);

            });

            modelBuilder.Entity<AdditionalService>(opt =>
            {
                opt.HasKey(e => e.idAdditionalService);
                opt.Property(e => e.idAdditionalService).ValueGeneratedOnAdd();
                opt.Property(e => e.additionalService).HasMaxLength(60);
                opt.Property(e => e.additionalPrice);

            });

            modelBuilder.Entity<Script_AdditionalService>(opt =>
            {
                opt.HasKey(e => new { e.idScript, e.idAdditionalService });
                opt.HasOne(e => e.script).WithMany(e => e.Script_AdditionalServices).HasForeignKey(e => e.idScript);
                opt.HasOne(e => e.additionalService).WithMany(e => e.Script_AdditionalServices).HasForeignKey(e => e.idAdditionalService);

            });

            modelBuilder.Entity<User>(opt =>
            {
                opt.HasKey(e => e.idUser);
                opt.Property(e => e.idUser).ValueGeneratedOnAdd();
                opt.Property(e => e.firstName).HasMaxLength(30);
                opt.Property(e => e.lastName).HasMaxLength(30);
                opt.Property(e => e.login).HasMaxLength(20);
                opt.Property(e => e.password).HasMaxLength(50);
                opt.Property(e => e.phoneNumber).HasMaxLength(10);
                opt.Property(e => e.emailAdress).HasMaxLength(20);
                opt.Property(e => e.passportId).HasMaxLength(10);
                opt.Property(e => e.Role).HasMaxLength(10);
                opt.Property(e => e.RefreshToken).HasMaxLength(300);
                opt.Property(e => e.RefreshTokenExpiry);

                opt.HasOne(a => a.account).WithOne(b => b.user).HasForeignKey<Account>(e => e.idUser);
                

            });

            modelBuilder.Entity<Account>(opt =>
            {
                opt.HasKey(e => e.idAccount);
                opt.Property(e => e.idAccount).ValueGeneratedOnAdd();
                opt.Property(e => e.idUser);
                
                opt.Property(e => e.balance);
                opt.Property(e => e.createdAt).HasDefaultValueSql("getdate()");
                opt.Property(e => e.updatedAt);
                opt.Property(e => e.NotificationType).HasConversion<string>().HasMaxLength(50);

                opt.HasOne(e => e.Package).WithMany(e => e.Accounts).HasForeignKey(e => e.idPackage);
                opt.HasOne(e => e.Address).WithMany(e => e.Accounts).HasForeignKey(e => e.idAddress);
                opt.HasOne(e => e.Equipment).WithMany(e => e.Accounts).HasForeignKey(e => e.idEquipment);
                



            });

            modelBuilder.Entity<Account_AdditionalService>(opt =>
            {
                opt.HasKey(e => new { e.idAccount, e.idAdditionalService });
                opt.HasOne(e => e.account).WithMany(e => e.Account_AdditionalServices).HasForeignKey(e => e.idAccount);
                opt.HasOne(e => e.AdditionalService).WithMany(e => e.Account_AdditionalServices).HasForeignKey(e => e.idAdditionalService);

            });

            
            modelBuilder.Entity<SupportTicket>(opt =>
            {
                opt.HasKey(e => e.idSupportTicket);
                opt.Property(e => e.idSupportTicket).ValueGeneratedOnAdd();
                opt.Property(e => e.topic).HasMaxLength(50);
                opt.Property(e => e.question).HasMaxLength(200);
                opt.Property(e => e.answer).HasMaxLength(200);
                opt.Property(e => e.dateOfCreation).HasDefaultValueSql("getdate()");
                opt.Property(e => e.status).HasMaxLength(30);
                opt.Property(e => e.isFinished);
                opt.Property(e => e.updatedAt);
                
                opt.HasOne(e => e.user).WithMany(e => e.SupportTickets).HasForeignKey(e => e. idUser);

            });

        }
    }
}
