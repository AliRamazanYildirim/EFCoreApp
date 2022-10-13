using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Neu_Initiale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leiter");

            migrationBuilder.CreateTable(
                name: "Kategorien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    RabattPreis = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Vorrat = table.Column<int>(type: "int", nullable: false),
                    Strichcode = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ProduktEigenschaften",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Grösse = table.Column<int>(type: "int", nullable: false),
                    Breite = table.Column<int>(type: "int", nullable: false),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktEigenschaften", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProduktEigenschaften_Produkte_ID",
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
                name: "ProduktEigenschaften");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorien");

            migrationBuilder.CreateTable(
                name: "Leiter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiter", x => x.ID);
                });
        }
    }
}
