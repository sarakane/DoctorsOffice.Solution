using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsOffice.Migrations
{
    public partial class DoctorSpecialtyContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialty_Specialty_SpecialtyId",
                table: "DoctorSpecialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialty_Specialties_SpecialtyId",
                table: "DoctorSpecialty",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialty_Specialties_SpecialtyId",
                table: "DoctorSpecialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialty_Specialty_SpecialtyId",
                table: "DoctorSpecialty",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
