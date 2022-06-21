using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IspProject.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "addresses",
                newName: "street");

            migrationBuilder.AddColumn<string>(
                name: "apartmentNumber",
                table: "addresses",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "addresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "houseNumber",
                table: "addresses",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apartmentNumber",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "city",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "houseNumber",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "addresses",
                newName: "address");
        }
    }
}
