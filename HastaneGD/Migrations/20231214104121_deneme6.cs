using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class deneme6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorPoliklinik");

            migrationBuilder.AddColumn<int>(
                name: "PoliklinikspolId",
                table: "doktors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_doktors_PoliklinikspolId",
                table: "doktors",
                column: "PoliklinikspolId");

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikspolId",
                table: "doktors",
                column: "PoliklinikspolId",
                principalTable: "polikliniks",
                principalColumn: "polId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikspolId",
                table: "doktors");

            migrationBuilder.DropIndex(
                name: "IX_doktors_PoliklinikspolId",
                table: "doktors");

            migrationBuilder.DropColumn(
                name: "PoliklinikspolId",
                table: "doktors");

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
