using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicalAPI.Migrations
{
    public partial class Creating_table_LogMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appoiments",
                columns: table => new
                {
                    AppoitmentId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    AppointmentType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoiments", x => x.AppoitmentId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appoiments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
