using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class OneToOne_Datei_Hinzufügen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProduktEigenschaften",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Grösse = table.Column<int>(type: "int", nullable: false),
                    Höhe = table.Column<int>(type: "int", nullable: false),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktEigenschaften");
        }
    }
}
