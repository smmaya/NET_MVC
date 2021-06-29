using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSMan.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Flight = table.Column<string>(type: "TEXT", nullable: true),
                    FromCity = table.Column<string>(type: "TEXT", nullable: true),
                    FromDepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToCity = table.Column<string>(type: "TEXT", nullable: true),
                    ToLandingTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelModel");
        }
    }
}
