using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Initiale_Neu_Produkt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    UrlName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vorrat = table.Column<int>(type: "int", nullable: false),
                    KategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produkte_Kategorie_KategorieID",
                        column: x => x.KategorieID,
                        principalTable: "Kategorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktEigenschaft",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Grösse = table.Column<int>(type: "int", nullable: false),
                    Breite = table.Column<int>(type: "int", nullable: false),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktEigenschaft", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProduktEigenschaft_Produkte_ID",
                        column: x => x.ID,
                        principalTable: "Produkte",
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
                name: "ProduktEigenschaft");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
