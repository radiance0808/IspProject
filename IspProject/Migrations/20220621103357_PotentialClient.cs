using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IspProject.Migrations
{
    public partial class PotentialClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_potentialClients_addresses_idAddress",
                table: "potentialClients");

            migrationBuilder.RenameColumn(
                name: "idAddress",
                table: "potentialClients",
                newName: "idTypeOfHouse");

            migrationBuilder.RenameIndex(
                name: "IX_potentialClients_idAddress",
                table: "potentialClients",
                newName: "IX_potentialClients_idTypeOfHouse");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "potentialClients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "potentialClients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "idPackage",
                table: "potentialClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_potentialClients_idPackage",
                table: "potentialClients",
                column: "idPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_potentialClients_packages_idPackage",
                table: "potentialClients",
                column: "idPackage",
                principalTable: "packages",
                principalColumn: "idPackage",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_potentialClients_typeHouses_idTypeOfHouse",
                table: "potentialClients",
                column: "idTypeOfHouse",
                principalTable: "typeHouses",
                principalColumn: "idTypeOfHouse",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_potentialClients_packages_idPackage",
                table: "potentialClients");

            migrationBuilder.DropForeignKey(
                name: "FK_potentialClients_typeHouses_idTypeOfHouse",
                table: "potentialClients");

            migrationBuilder.DropIndex(
                name: "IX_potentialClients_idPackage",
                table: "potentialClients");

            migrationBuilder.DropColumn(
                name: "address",
                table: "potentialClients");

            migrationBuilder.DropColumn(
                name: "email",
                table: "potentialClients");

            migrationBuilder.DropColumn(
                name: "idPackage",
                table: "potentialClients");

            migrationBuilder.RenameColumn(
                name: "idTypeOfHouse",
                table: "potentialClients",
                newName: "idAddress");

            migrationBuilder.RenameIndex(
                name: "IX_potentialClients_idTypeOfHouse",
                table: "potentialClients",
                newName: "IX_potentialClients_idAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_potentialClients_addresses_idAddress",
                table: "potentialClients",
                column: "idAddress",
                principalTable: "addresses",
                principalColumn: "idAddress",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
