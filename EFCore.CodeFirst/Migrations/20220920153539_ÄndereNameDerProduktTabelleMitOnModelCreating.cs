using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class ÄndereNameDerProduktTabelleMitOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProduktTb",
                schema: "produkte",
                table: "ProduktTb");

            migrationBuilder.RenameTable(
                name: "ProduktTb",
                schema: "produkte",
                newName: "ProduktTbl",
                newSchema: "produkte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProduktTbl",
                schema: "produkte",
                table: "ProduktTbl",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProduktTbl",
                schema: "produkte",
                table: "ProduktTbl");

            migrationBuilder.RenameTable(
                name: "ProduktTbl",
                schema: "produkte",
                newName: "ProduktTb",
                newSchema: "produkte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProduktTb",
                schema: "produkte",
                table: "ProduktTb",
                column: "ID");
        }
    }
}
