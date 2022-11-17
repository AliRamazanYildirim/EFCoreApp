using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class NamenÄnderung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Personal_VorName",
                table: "Manager",
                newName: "Vorname");

            migrationBuilder.RenameColumn(
                name: "Personal_NachName",
                table: "Manager",
                newName: "Nachname");

            migrationBuilder.RenameColumn(
                name: "Personal_Alter",
                table: "Manager",
                newName: "Alter");

            migrationBuilder.RenameColumn(
                name: "Personal_VorName",
                table: "Arbeiter",
                newName: "Vorname");

            migrationBuilder.RenameColumn(
                name: "Personal_NachName",
                table: "Arbeiter",
                newName: "Nachname");

            migrationBuilder.RenameColumn(
                name: "Personal_Alter",
                table: "Arbeiter",
                newName: "Alter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vorname",
                table: "Manager",
                newName: "Personal_VorName");

            migrationBuilder.RenameColumn(
                name: "Nachname",
                table: "Manager",
                newName: "Personal_NachName");

            migrationBuilder.RenameColumn(
                name: "Alter",
                table: "Manager",
                newName: "Personal_Alter");

            migrationBuilder.RenameColumn(
                name: "Vorname",
                table: "Arbeiter",
                newName: "Personal_VorName");

            migrationBuilder.RenameColumn(
                name: "Nachname",
                table: "Arbeiter",
                newName: "Personal_NachName");

            migrationBuilder.RenameColumn(
                name: "Alter",
                table: "Arbeiter",
                newName: "Personal_Alter");
        }
    }
}
