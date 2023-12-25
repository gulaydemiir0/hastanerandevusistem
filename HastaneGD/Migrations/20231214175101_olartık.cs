using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class olartık : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anaBilimDalis_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis");

            migrationBuilder.DropTable(
                name: "doktors");

            migrationBuilder.DropIndex(
                name: "IX_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis");

            migrationBuilder.DropColumn(
                name: "AnaBilimDaliabdId",
                table: "anaBilimDalis");

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    polName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.DoctorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.AddColumn<int>(
                name: "AnaBilimDaliabdId",
                table: "anaBilimDalis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "doktors",
                columns: table => new
                {
                    doktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikpolId = table.Column<int>(type: "int", nullable: true),
                    abdID = table.Column<int>(type: "int", nullable: false),
                    doktorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    polId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doktors", x => x.doktorId);
                    table.ForeignKey(
                        name: "FK_doktors_polikliniks_PoliklinikpolId",
                        column: x => x.PoliklinikpolId,
                        principalTable: "polikliniks",
                        principalColumn: "polId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis",
                column: "AnaBilimDaliabdId");

            migrationBuilder.CreateIndex(
                name: "IX_doktors_PoliklinikpolId",
                table: "doktors",
                column: "PoliklinikpolId");

            migrationBuilder.AddForeignKey(
                name: "FK_anaBilimDalis_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis",
                column: "AnaBilimDaliabdId",
                principalTable: "anaBilimDalis",
                principalColumn: "abdId");
        }
    }
}
