using Microsoft.EntityFrameworkCore.Migrations;

namespace PSMan.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expats",
                columns: table => new
                {
                    Exp_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Exp_FName = table.Column<string>(type: "TEXT", nullable: true),
                    Exp_LName = table.Column<string>(type: "TEXT", nullable: true),
                    Exp_Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expats", x => x.Exp_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expats");
        }
    }
}
