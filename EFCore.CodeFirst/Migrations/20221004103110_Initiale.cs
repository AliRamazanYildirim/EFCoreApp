using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Initiale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vorrat = table.Column<int>(type: "int", nullable: false),
                    Strichcode = table.Column<int>(type: "int", nullable: false),
                    KategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produkte_Kategorien_KategorieID",
                        column: x => x.KategorieID,
                        principalTable: "Kategorien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_KategorieID",
                table: "Produkte",
                column: "KategorieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorien");
        }
    }
}
