using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Fluent_Owned_Benennen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Personal_VorName",
                table: "Manager",
                newName: "VorName");

            migrationBuilder.RenameColumn(
                name: "Personal_NachName",
                table: "Manager",
                newName: "NachName");

            migrationBuilder.RenameColumn(
                name: "Personal_Alter",
                table: "Manager",
                newName: "Alter");

            migrationBuilder.RenameColumn(
                name: "Personal_VorName",
                table: "Arbeiter",
                newName: "VorName");

            migrationBuilder.RenameColumn(
                name: "Personal_NachName",
                table: "Arbeiter",
                newName: "NachName");

            migrationBuilder.RenameColumn(
                name: "Personal_Alter",
                table: "Arbeiter",
                newName: "Alter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VorName",
                table: "Manager",
                newName: "Personal_VorName");

            migrationBuilder.RenameColumn(
                name: "NachName",
                table: "Manager",
                newName: "Personal_NachName");

            migrationBuilder.RenameColumn(
                name: "Alter",
                table: "Manager",
                newName: "Personal_Alter");

            migrationBuilder.RenameColumn(
                name: "VorName",
                table: "Arbeiter",
                newName: "Personal_VorName");

            migrationBuilder.RenameColumn(
                name: "NachName",
                table: "Arbeiter",
                newName: "Personal_NachName");

            migrationBuilder.RenameColumn(
                name: "Alter",
                table: "Arbeiter",
                newName: "Personal_Alter");
        }
    }
}
