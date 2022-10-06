using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Delete_Restrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte",
                column: "KategorieID",
                principalTable: "Kategorien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte",
                column: "KategorieID",
                principalTable: "Kategorien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
