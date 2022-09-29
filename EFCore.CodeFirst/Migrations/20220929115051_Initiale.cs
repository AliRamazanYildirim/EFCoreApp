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
                    KategorieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produkte_Kategorien_KategorieID",
                        column: x => x.KategorieID,
                        principalTable: "Kategorien",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProduktEigenschaften",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grösse = table.Column<int>(type: "int", nullable: false),
                    Höhe = table.Column<int>(type: "int", nullable: false),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProduktID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktEigenschaften", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProduktEigenschaften_Produkte_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_KategorieID",
                table: "Produkte",
                column: "KategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktEigenschaften_ProduktID",
                table: "ProduktEigenschaften",
                column: "ProduktID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktEigenschaften");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorien");
        }
    }
}
