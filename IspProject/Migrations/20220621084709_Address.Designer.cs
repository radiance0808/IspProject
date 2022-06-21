﻿// <auto-generated />
using System;
using IspProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IspProject.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    [Migration("20220621084709_Address")]
    partial class Address
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IspProject.Models.Account", b =>
                {
                    b.Property<int>("idAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAccount"), 1L, 1);

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("idAddress")
                        .HasColumnType("int");

                    b.Property<int>("idEquipment")
                        .HasColumnType("int");

                    b.Property<int>("idPackage")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("idAccount");

                    b.HasIndex("idAddress");

                    b.HasIndex("idEquipment");

                    b.HasIndex("idPackage");

                    b.HasIndex("idUser")
                        .IsUnique();

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("IspProject.Models.Account_AdditionalService", b =>
                {
                    b.Property<int>("idAccount")
                        .HasColumnType("int");

                    b.Property<int>("idAdditionalService")
                        .HasColumnType("int");

                    b.HasKey("idAccount", "idAdditionalService");

                    b.HasIndex("idAdditionalService");

                    b.ToTable("account_AdditionalServices");
                });

            modelBuilder.Entity("IspProject.Models.AdditionalService", b =>
                {
                    b.Property<int>("idAdditionalService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAdditionalService"), 1L, 1);

                    b.Property<double>("additionalPrice")
                        .HasColumnType("float");

                    b.Property<string>("additionalService")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("idAdditionalService");

                    b.ToTable("additionalServices");
                });

            modelBuilder.Entity("IspProject.Models.Address", b =>
                {
                    b.Property<int>("idAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("apartmentNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("houseNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("idTypeOfHouse")
                        .HasColumnType("int");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idAddress");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("IspProject.Models.Equipment", b =>
                {
                    b.Property<int>("idEqupment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEqupment"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("routerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("idEqupment");

                    b.ToTable("equipments");
                });

            modelBuilder.Entity("IspProject.Models.Package", b =>
                {
                    b.Property<int>("idPackage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPackage"), 1L, 1);

                    b.Property<string>("nameOfPackage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("idPackage");

                    b.ToTable("packages");
                });

            modelBuilder.Entity("IspProject.Models.Payment", b =>
                {
                    b.Property<int>("idPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPayment"), 1L, 1);

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("idAccount")
                        .HasColumnType("int");

                    b.HasKey("idPayment");

                    b.HasIndex("idAccount");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("IspProject.Models.PotentialClient", b =>
                {
                    b.Property<int>("idPotentialClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPotentialClient"), 1L, 1);

                    b.Property<int>("idAddress")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("idPotentialClient");

                    b.HasIndex("idAddress");

                    b.ToTable("potentialClients");
                });

            modelBuilder.Entity("IspProject.Models.Script", b =>
                {
                    b.Property<int>("idScript")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idScript"), 1L, 1);

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("nameOfScript")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("scriptFile")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("idScript");

                    b.ToTable("scripts");
                });

            modelBuilder.Entity("IspProject.Models.Script_AdditionalService", b =>
                {
                    b.Property<int>("idScript")
                        .HasColumnType("int");

                    b.Property<int>("idAdditionalService")
                        .HasColumnType("int");

                    b.HasKey("idScript", "idAdditionalService");

                    b.HasIndex("idAdditionalService");

                    b.ToTable("script_additionalServices");
                });

            modelBuilder.Entity("IspProject.Models.SupportTicket", b =>
                {
                    b.Property<int>("idSupportTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSupportTicket"), 1L, 1);

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("dateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("idUser")
                        .HasColumnType("int");

                    b.Property<bool>("isFinished")
                        .HasColumnType("bit");

                    b.Property<string>("question")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("topic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("idSupportTicket");

                    b.HasIndex("idUser");

                    b.ToTable("supportTickets");
                });

            modelBuilder.Entity("IspProject.Models.Traffic", b =>
                {
                    b.Property<int>("idTraffic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTraffic"), 1L, 1);

                    b.Property<string>("application")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("consumptedTraffic")
                        .HasColumnType("float");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("idAccount")
                        .HasColumnType("int");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.HasKey("idTraffic");

                    b.HasIndex("idAccount");

                    b.ToTable("traffics");
                });

            modelBuilder.Entity("IspProject.Models.TypeOfHouse", b =>
                {
                    b.Property<int>("idTypeOfHouse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTypeOfHouse"), 1L, 1);

                    b.Property<string>("typeOfHouse")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idTypeOfHouse");

                    b.ToTable("typeHouses");
                });

            modelBuilder.Entity("IspProject.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"), 1L, 1);

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("emailAdress")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("passportId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("idUser");

                    b.ToTable("users");
                });

            modelBuilder.Entity("IspProject.Models.Account", b =>
                {
                    b.HasOne("IspProject.Models.Address", "Address")
                        .WithMany("Accounts")
                        .HasForeignKey("idAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IspProject.Models.Equipment", "Equipment")
                        .WithMany("Accounts")
                        .HasForeignKey("idEquipment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IspProject.Models.Package", "Package")
                        .WithMany("Accounts")
                        .HasForeignKey("idPackage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IspProject.Models.User", "user")
                        .WithOne("account")
                        .HasForeignKey("IspProject.Models.Account", "idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Equipment");

                    b.Navigation("Package");

                    b.Navigation("user");
                });

            modelBuilder.Entity("IspProject.Models.Account_AdditionalService", b =>
                {
                    b.HasOne("IspProject.Models.Account", "account")
                        .WithMany("Account_AdditionalServices")
                        .HasForeignKey("idAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IspProject.Models.AdditionalService", "AdditionalService")
                        .WithMany("Account_AdditionalServices")
                        .HasForeignKey("idAdditionalService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("account");
                });

            modelBuilder.Entity("IspProject.Models.Address", b =>
                {
                    b.HasOne("IspProject.Models.TypeOfHouse", "typeOfHouse")
                        .WithMany("Addresses")
                        .HasForeignKey("idAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typeOfHouse");
                });

            modelBuilder.Entity("IspProject.Models.Payment", b =>
                {
                    b.HasOne("IspProject.Models.Account", "account")
                        .WithMany("Payments")
                        .HasForeignKey("idAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("IspProject.Models.PotentialClient", b =>
                {
                    b.HasOne("IspProject.Models.Address", "address")
                        .WithMany("PotentialClients")
                        .HasForeignKey("idAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");
                });

            modelBuilder.Entity("IspProject.Models.Script_AdditionalService", b =>
                {
                    b.HasOne("IspProject.Models.AdditionalService", "additionalService")
                        .WithMany("Script_AdditionalServices")
                        .HasForeignKey("idAdditionalService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IspProject.Models.Script", "script")
                        .WithMany("Script_AdditionalServices")
                        .HasForeignKey("idScript")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("additionalService");

                    b.Navigation("script");
                });

            modelBuilder.Entity("IspProject.Models.SupportTicket", b =>
                {
                    b.HasOne("IspProject.Models.User", "user")
                        .WithMany("SupportTickets")
                        .HasForeignKey("idUser");

                    b.Navigation("user");
                });

            modelBuilder.Entity("IspProject.Models.Traffic", b =>
                {
                    b.HasOne("IspProject.Models.Account", "account")
                        .WithMany("Traffics")
                        .HasForeignKey("idAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("IspProject.Models.Account", b =>
                {
                    b.Navigation("Account_AdditionalServices");

                    b.Navigation("Payments");

                    b.Navigation("Traffics");
                });

            modelBuilder.Entity("IspProject.Models.AdditionalService", b =>
                {
                    b.Navigation("Account_AdditionalServices");

                    b.Navigation("Script_AdditionalServices");
                });

            modelBuilder.Entity("IspProject.Models.Address", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("PotentialClients");
                });

            modelBuilder.Entity("IspProject.Models.Equipment", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("IspProject.Models.Package", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("IspProject.Models.Script", b =>
                {
                    b.Navigation("Script_AdditionalServices");
                });

            modelBuilder.Entity("IspProject.Models.TypeOfHouse", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("IspProject.Models.User", b =>
                {
                    b.Navigation("SupportTickets");

                    b.Navigation("account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
