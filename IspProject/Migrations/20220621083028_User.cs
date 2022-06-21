using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IspProject.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Refreshtoken",
                table: "users",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "Refreshtokenexp",
                table: "users",
                newName: "RefreshTokenExpiry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "users",
                newName: "Refreshtoken");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiry",
                table: "users",
                newName: "Refreshtokenexp");
        }
    }
}
