using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class ÄndereNameDerProduktTabelle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produkte",
                table: "Produkte");

            migrationBuilder.EnsureSchema(
                name: "produkte");

            migrationBuilder.RenameTable(
                name: "Produkte",
                newName: "ProduktTb",
                newSchema: "produkte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProduktTb",
                schema: "produkte",
                table: "ProduktTb",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProduktTb",
                schema: "produkte",
                table: "ProduktTb");

            migrationBuilder.RenameTable(
                name: "ProduktTb",
                schema: "produkte",
                newName: "Produkte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produkte",
                table: "Produkte",
                column: "ID");
        }
    }
}
