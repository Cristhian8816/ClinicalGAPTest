using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicalAPI.Migrations
{
    public partial class Creating_LogMigrationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MigrationsHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    ProductVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationsHistory", x => x.MigrationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MigrationsHistory");
        }
    }
}
