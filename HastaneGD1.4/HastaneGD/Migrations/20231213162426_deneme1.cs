using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class deneme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anaBilimDalis",
                columns: table => new
                {
                    abdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abdName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anaBilimDalis", x => x.abdId);
                });

            migrationBuilder.CreateTable(
                name: "polikliniks",
                columns: table => new
                {
                    polId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    polName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polikliniks", x => x.polId);
                });

            migrationBuilder.CreateTable(
                name: "doktors",
                columns: table => new
                {
                    doktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doktorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    abdID = table.Column<int>(type: "int", nullable: false),
                    AnaBilimDaliabdId = table.Column<int>(type: "int", nullable: false),
                    polId = table.Column<int>(type: "int", nullable: false),
                    PoliklinikpolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doktors", x => x.doktorId);
                    table.ForeignKey(
                        name: "FK_doktors_anaBilimDalis_AnaBilimDaliabdId",
                        column: x => x.AnaBilimDaliabdId,
                        principalTable: "anaBilimDalis",
                        principalColumn: "abdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doktors_polikliniks_PoliklinikpolId",
                        column: x => x.PoliklinikpolId,
                        principalTable: "polikliniks",
                        principalColumn: "polId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doktors_AnaBilimDaliabdId",
                table: "doktors",
                column: "AnaBilimDaliabdId");

            migrationBuilder.CreateIndex(
                name: "IX_doktors_PoliklinikpolId",
                table: "doktors",
                column: "PoliklinikpolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doktors");

            migrationBuilder.DropTable(
                name: "anaBilimDalis");

            migrationBuilder.DropTable(
                name: "polikliniks");
        }
    }
}
