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

        public DbSet<Script_AdditionalService> script_additionalServices { get; set; }

        public DbSet<SupportTicket> supportTickets { get; set; }

        public DbSet<Traffic> traffics { get; set; }

        public DbSet<TypeOfHouse> typeHouses { get; set; }

        public DbSet<User> users { get; set; }

        public AccountDbContext() { }

        public AccountDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Script>(opt =>
            {
                opt.HasKey(e => e.idScript);
                opt.Property(e => e.idScript).ValueGeneratedOnAdd();
                opt.Property(e => e.nameOfScript).HasMaxLength(50).IsRequired();
                opt.Property(e => e.scriptFile).HasMaxLength(40).IsRequired();
                opt.Property(e => e.createdAt).HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Package>(opt =>
            {
                opt.HasKey(e => e.idPackage);
                opt.Property(e => e.idPackage).ValueGeneratedOnAdd();
                opt.Property(e => e.nameOfPackage).HasMaxLength(50).IsRequired();
                opt.Property(e => e.price).IsRequired();
            });

            modelBuilder.Entity<TypeOfHouse>(opt =>
            {
                opt.HasKey(e => e.idTypeOfHouse);
                opt.Property(e => e.idTypeOfHouse).ValueGeneratedOnAdd();
                opt.Property(e => e.typeOfHouse).HasMaxLength(50).IsRequired();

            });

            modelBuilder.Entity<Traffic>(opt =>
            {
                opt.HasKey(e => e.idTraffic);
                opt.Property(e => e.idTraffic).ValueGeneratedOnAdd();
                opt.Property(e => e.application).HasMaxLength(40).IsRequired();
                opt.Property(e => e.consumptedTraffic).IsRequired();
                opt.Property(e => e.startTime).IsRequired();
                opt.Property(e => e.endTime).IsRequired();
                opt.HasOne(e => e.account).WithMany(e => e.Traffics).HasForeignKey(e => e.idUser);


            });

            modelBuilder.Entity<Adress>(opt =>
            {
                opt.HasKey(e => e.idAdress);
                opt.Property(e => e.idAdress).ValueGeneratedOnAdd();
                opt.Property(e => e.adress).HasMaxLength(50).IsRequired();
                opt.HasOne(e => e.typeOfHouse).WithMany(e => e.Adresses).HasForeignKey(e => e.idAdress);

            });


            modelBuilder.Entity<AdditionalService>(opt =>
            {
                opt.HasKey(e => e.idAdditionalService);
                opt.Property(e => e.idAdditionalService).ValueGeneratedOnAdd();
                opt.Property(e => e.additionalService).HasMaxLength(60).IsRequired();
                opt.Property(e => e.additionalPrice).IsRequired();

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
                opt.Property(e => e.firstName).HasMaxLength(30).IsRequired();
                opt.Property(e => e.lastName).HasMaxLength(30).IsRequired();
                opt.Property(e => e.phoneNumber).HasMaxLength(10).IsRequired();
                opt.Property(e => e.emailAdress).HasMaxLength(20).IsRequired();
                opt.Property(e => e.passportId).HasMaxLength(10).IsRequired();


            });

            modelBuilder.Entity<Account>(opt =>
            {
                opt.HasKey(e => e.idUser);
                opt.Property(e => e.idUser).ValueGeneratedOnAdd();
                opt.Property(e => e.login).HasMaxLength(20).IsRequired();
                opt.Property(e => e.password).HasMaxLength(30).IsRequired();
                opt.Property(e => e.balance).IsRequired();
                opt.Property(e => e.createdAt).HasDefaultValueSql("getdate()");
                opt.Property(e => e.updatedAt);
                opt.HasOne(e => e.Package).WithMany(e => e.Accounts).HasForeignKey(e => e.idPackage);
                opt.HasOne(e => e.Adress).WithMany(e => e.Accounts).HasForeignKey(e => e.idAdress);
                opt.HasOne(e => e.user).WithOne(e => e.account).HasForeignKey<User>(e => e.idUser);



            });

            modelBuilder.Entity<Administrator>(opt =>
            {
                opt.HasKey(e => e.idUser);
                opt.HasOne(e => e.User).WithOne(e => e.administrator).HasForeignKey<User>(e => e.idUser);


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
                opt.Property(e => e.topic).HasMaxLength(50).IsRequired();
                opt.Property(e => e.message).HasMaxLength(200).IsRequired();
                opt.Property(e => e.dateOfCreation).HasDefaultValueSql("getdate()");
                opt.Property(e => e.status).HasMaxLength(30).IsRequired();
                opt.Property(e => e.isFinished).IsRequired();
                opt.Property(e => e.updatedAt);
                opt.HasOne(e => e.Administrator).WithMany(e => e.SupportTickets).HasForeignKey(e => e.idAdministrator);
                opt.HasOne(e => e.account).WithMany(e => e.SupportTickets).HasForeignKey(e => e.idUser);

            });

        }
    }
}
