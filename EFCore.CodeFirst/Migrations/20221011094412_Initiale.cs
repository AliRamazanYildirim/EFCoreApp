using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class Initiale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbeiter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personal_VorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_NachName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_Alter = table.Column<int>(type: "int", nullable: false),
                    Gehalt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeiter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personal_VorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_NachName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_Alter = table.Column<int>(type: "int", nullable: false),
                    Grad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbeiter");

            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
