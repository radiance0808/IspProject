using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IspProject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "additionalServices",
                columns: table => new
                {
                    idAdditionalService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    additionalService = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    additionalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additionalServices", x => x.idAdditionalService);
                });

            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    idEqupment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    routerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.idEqupment);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    idPackage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameOfPackage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.idPackage);
                });

            migrationBuilder.CreateTable(
                name: "scripts",
                columns: table => new
                {
                    idScript = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameOfScript = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    scriptFile = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scripts", x => x.idScript);
                });

            migrationBuilder.CreateTable(
                name: "typeHouses",
                columns: table => new
                {
                    idTypeOfHouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeOfHouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeHouses", x => x.idTypeOfHouse);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    emailAdress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    passportId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "script_additionalServices",
                columns: table => new
                {
                    idScript = table.Column<int>(type: "int", nullable: false),
                    idAdditionalService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_script_additionalServices", x => new { x.idScript, x.idAdditionalService });
                    table.ForeignKey(
                        name: "FK_script_additionalServices_additionalServices_idAdditionalService",
                        column: x => x.idAdditionalService,
                        principalTable: "additionalServices",
                        principalColumn: "idAdditionalService",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_script_additionalServices_scripts_idScript",
                        column: x => x.idScript,
                        principalTable: "scripts",
                        principalColumn: "idScript",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    idAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    houseNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    apartmentNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    idTypeOfHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.idAddress);
                    table.ForeignKey(
                        name: "FK_addresses_typeHouses_idTypeOfHouse",
                        column: x => x.idTypeOfHouse,
                        principalTable: "typeHouses",
                        principalColumn: "idTypeOfHouse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "potentialClients",
                columns: table => new
                {
                    idPotentialClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idPackage = table.Column<int>(type: "int", nullable: false),
                    idTypeOfHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_potentialClients", x => x.idPotentialClient);
                    table.ForeignKey(
                        name: "FK_potentialClients_packages_idPackage",
                        column: x => x.idPackage,
                        principalTable: "packages",
                        principalColumn: "idPackage",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_potentialClients_typeHouses_idTypeOfHouse",
                        column: x => x.idTypeOfHouse,
                        principalTable: "typeHouses",
                        principalColumn: "idTypeOfHouse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supportTickets",
                columns: table => new
                {
                    idSupportTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    answer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    isFinished = table.Column<bool>(type: "bit", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supportTickets", x => x.idSupportTicket);
                    table.ForeignKey(
                        name: "FK_supportTickets_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    idAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPackage = table.Column<int>(type: "int", nullable: false),
                    idAddress = table.Column<int>(type: "int", nullable: false),
                    idEquipment = table.Column<int>(type: "int", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.idAccount);
                    table.ForeignKey(
                        name: "FK_accounts_addresses_idAddress",
                        column: x => x.idAddress,
                        principalTable: "addresses",
                        principalColumn: "idAddress",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_equipments_idEquipment",
                        column: x => x.idEquipment,
                        principalTable: "equipments",
                        principalColumn: "idEqupment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_packages_idPackage",
                        column: x => x.idPackage,
                        principalTable: "packages",
                        principalColumn: "idPackage",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_AdditionalServices",
                columns: table => new
                {
                    idAccount = table.Column<int>(type: "int", nullable: false),
                    idAdditionalService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_AdditionalServices", x => new { x.idAccount, x.idAdditionalService });
                    table.ForeignKey(
                        name: "FK_account_AdditionalServices_accounts_idAccount",
                        column: x => x.idAccount,
                        principalTable: "accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_AdditionalServices_additionalServices_idAdditionalService",
                        column: x => x.idAdditionalService,
                        principalTable: "additionalServices",
                        principalColumn: "idAdditionalService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    idPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<double>(type: "float", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.idPayment);
                    table.ForeignKey(
                        name: "FK_payments_accounts_idAccount",
                        column: x => x.idAccount,
                        principalTable: "accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "traffics",
                columns: table => new
                {
                    idTraffic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    application = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    consumptedTraffic = table.Column<double>(type: "float", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traffics", x => x.idTraffic);
                    table.ForeignKey(
                        name: "FK_traffics_accounts_idAccount",
                        column: x => x.idAccount,
                        principalTable: "accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_AdditionalServices_idAdditionalService",
                table: "account_AdditionalServices",
                column: "idAdditionalService");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_idAddress",
                table: "accounts",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_idEquipment",
                table: "accounts",
                column: "idEquipment");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_idPackage",
                table: "accounts",
                column: "idPackage");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_idUser",
                table: "accounts",
                column: "idUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresses_idTypeOfHouse",
                table: "addresses",
                column: "idTypeOfHouse");

            migrationBuilder.CreateIndex(
                name: "IX_payments_idAccount",
                table: "payments",
                column: "idAccount");

            migrationBuilder.CreateIndex(
                name: "IX_potentialClients_idPackage",
                table: "potentialClients",
                column: "idPackage");

            migrationBuilder.CreateIndex(
                name: "IX_potentialClients_idTypeOfHouse",
                table: "potentialClients",
                column: "idTypeOfHouse");

            migrationBuilder.CreateIndex(
                name: "IX_script_additionalServices_idAdditionalService",
                table: "script_additionalServices",
                column: "idAdditionalService");

            migrationBuilder.CreateIndex(
                name: "IX_supportTickets_idUser",
                table: "supportTickets",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_traffics_idAccount",
                table: "traffics",
                column: "idAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_AdditionalServices");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "potentialClients");

            migrationBuilder.DropTable(
                name: "script_additionalServices");

            migrationBuilder.DropTable(
                name: "supportTickets");

            migrationBuilder.DropTable(
                name: "traffics");

            migrationBuilder.DropTable(
                name: "additionalServices");

            migrationBuilder.DropTable(
                name: "scripts");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "equipments");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "typeHouses");
        }
    }
}
