using Microsoft.EntityFrameworkCore.Migrations;

namespace Videoteka.Migrations.KontekstBazeMigrations
{
    public partial class Film : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Žanr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filmskižanr = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Žanr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    film = table.Column<string>(maxLength: 30, nullable: false),
                    Redatelj = table.Column<string>(maxLength: 30, nullable: true),
                    Jezik = table.Column<string>(maxLength: 30, nullable: true),
                    Opis = table.Column<string>(maxLength: 300, nullable: true),
                    ŽanrId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_Žanr_ŽanrId",
                        column: x => x.ŽanrId,
                        principalTable: "Žanr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_ŽanrId",
                table: "Film",
                column: "ŽanrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Žanr");
        }
    }
}
