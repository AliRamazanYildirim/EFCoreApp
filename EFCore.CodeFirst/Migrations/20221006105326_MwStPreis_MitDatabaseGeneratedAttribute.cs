using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class MwStPreis_MitDatabaseGeneratedAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte");

            migrationBuilder.AddColumn<int>(
                name: "MwSt",
                table: "Produkte",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MwStPreis",
                table: "Produkte",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[MwSt]*[Preis]");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte",
                column: "KategorieID",
                principalTable: "Kategorien",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte");

            migrationBuilder.DropColumn(
                name: "MwStPreis",
                table: "Produkte");

            migrationBuilder.DropColumn(
                name: "MwSt",
                table: "Produkte");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte",
                column: "KategorieID",
                principalTable: "Kategorien",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
