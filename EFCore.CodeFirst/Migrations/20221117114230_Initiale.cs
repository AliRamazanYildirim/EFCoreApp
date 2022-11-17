using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Initiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbeiter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalVorName = table.Column<string>(name: "Personal_VorName", type: "nvarchar(max)", nullable: true),
                    PersonalNachName = table.Column<string>(name: "Personal_NachName", type: "nvarchar(max)", nullable: true),
                    PersonalAlter = table.Column<int>(name: "Personal_Alter", type: "int", nullable: true),
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
                    PersonalVorName = table.Column<string>(name: "Personal_VorName", type: "nvarchar(max)", nullable: true),
                    PersonalNachName = table.Column<string>(name: "Personal_NachName", type: "nvarchar(max)", nullable: true),
                    PersonalAlter = table.Column<int>(name: "Personal_Alter", type: "int", nullable: true),
                    Grad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbeiter");

            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
