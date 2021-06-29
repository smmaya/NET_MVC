using Microsoft.EntityFrameworkCore.Migrations;

namespace PSMan.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Exp_LName",
                table: "Expats",
                newName: "LName");

            migrationBuilder.RenameColumn(
                name: "Exp_FName",
                table: "Expats",
                newName: "FName");

            migrationBuilder.RenameColumn(
                name: "Exp_Email",
                table: "Expats",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Exp_Id",
                table: "Expats",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Expats",
                newName: "Exp_LName");

            migrationBuilder.RenameColumn(
                name: "FName",
                table: "Expats",
                newName: "Exp_FName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Expats",
                newName: "Exp_Email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Expats",
                newName: "Exp_Id");
        }
    }
}
