using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class ManyToManay_StudentUndLehrer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lehrer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lehrer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LehrerStudent",
                columns: table => new
                {
                    LehrerID = table.Column<int>(type: "int", nullable: false),
                    StudentenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LehrerStudent", x => new { x.LehrerID, x.StudentenID });
                    table.ForeignKey(
                        name: "FK_LehrerStudent_Lehrer_LehrerID",
                        column: x => x.LehrerID,
                        principalTable: "Lehrer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LehrerStudent_Studenten_StudentenID",
                        column: x => x.StudentenID,
                        principalTable: "Studenten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LehrerStudent_StudentenID",
                table: "LehrerStudent",
                column: "StudentenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LehrerStudent");

            migrationBuilder.DropTable(
                name: "Lehrer");

            migrationBuilder.DropTable(
                name: "Studenten");
        }
    }
}
