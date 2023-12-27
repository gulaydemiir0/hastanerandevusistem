using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class iliskideneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anaBilimDalis_doktors_doktorId",
                table: "anaBilimDalis");

            migrationBuilder.DropIndex(
                name: "IX_anaBilimDalis_doktorId",
                table: "anaBilimDalis");

            migrationBuilder.DropColumn(
                name: "doktorId",
                table: "anaBilimDalis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doktorId",
                table: "anaBilimDalis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_anaBilimDalis_doktorId",
                table: "anaBilimDalis",
                column: "doktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_anaBilimDalis_doktors_doktorId",
                table: "anaBilimDalis",
                column: "doktorId",
                principalTable: "doktors",
                principalColumn: "doktorId");
        }
    }
}
