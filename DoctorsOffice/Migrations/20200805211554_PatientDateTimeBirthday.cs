using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsOffice.Migrations
{
    public partial class PatientDateTimeBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Birthday",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
