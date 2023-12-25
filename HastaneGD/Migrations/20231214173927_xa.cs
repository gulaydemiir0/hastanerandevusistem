using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class xa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorPoliklinik");

            migrationBuilder.DropColumn(
                name: "polName",
                table: "doktors");

            migrationBuilder.AddColumn<int>(
                name: "poliklinikpolId",
                table: "doktors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_doktors_poliklinikpolId",
                table: "doktors",
                column: "poliklinikpolId");

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_polikliniks_poliklinikpolId",
                table: "doktors",
                column: "poliklinikpolId",
                principalTable: "polikliniks",
                principalColumn: "polId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_polikliniks_poliklinikpolId",
                table: "doktors");

            migrationBuilder.DropIndex(
                name: "IX_doktors_poliklinikpolId",
                table: "doktors");

            migrationBuilder.DropColumn(
                name: "poliklinikpolId",
                table: "doktors");

            migrationBuilder.AddColumn<string>(
                name: "polName",
                table: "doktors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DoktorPoliklinik",
                columns: table => new
                {
                    PoliklinikspolId = table.Column<int>(type: "int", nullable: false),
                    doktorsdoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorPoliklinik", x => new { x.PoliklinikspolId, x.doktorsdoktorId });
                    table.ForeignKey(
                        name: "FK_DoktorPoliklinik_doktors_doktorsdoktorId",
                        column: x => x.doktorsdoktorId,
                        principalTable: "doktors",
                        principalColumn: "doktorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorPoliklinik_polikliniks_PoliklinikspolId",
                        column: x => x.PoliklinikspolId,
                        principalTable: "polikliniks",
                        principalColumn: "polId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorPoliklinik_doktorsdoktorId",
                table: "DoktorPoliklinik",
                column: "doktorsdoktorId");
        }
    }
}
