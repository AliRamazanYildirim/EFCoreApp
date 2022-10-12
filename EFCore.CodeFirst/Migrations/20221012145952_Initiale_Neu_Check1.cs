using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Initiale_Neu_Check1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkte_Kategorien_KategorieID",
                table: "Produkte");

            migrationBuilder.DropIndex(
                name: "IX_Produkte_Name",
                table: "Produkte");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produkte",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "KategorieID",
                table: "Produkte",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produkte",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "KategorieID",
                table: "Produkte",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_Name",
                table: "Produkte",
                column: "Name")
                .Annotation("SqlServer:Include", new[] { "Preis", "Vorrat", "Strichcode" });

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
