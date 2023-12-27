using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class deneme5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "polId",
                table: "doktors",
                newName: "polName");

            migrationBuilder.AddColumn<int>(
                name: "AnaBilimDaliabdId",
                table: "anaBilimDalis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "doktorId",
                table: "anaBilimDalis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis",
                column: "AnaBilimDaliabdId");

            migrationBuilder.CreateIndex(
                name: "IX_anaBilimDalis_doktorId",
                table: "anaBilimDalis",
                column: "doktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_anaBilimDalis_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis",
                column: "AnaBilimDaliabdId",
                principalTable: "anaBilimDalis",
                principalColumn: "abdId");

            migrationBuilder.AddForeignKey(
                name: "FK_anaBilimDalis_doktors_doktorId",
                table: "anaBilimDalis",
                column: "doktorId",
                principalTable: "doktors",
                principalColumn: "doktorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anaBilimDalis_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis");

            migrationBuilder.DropForeignKey(
                name: "FK_anaBilimDalis_doktors_doktorId",
                table: "anaBilimDalis");

            migrationBuilder.DropIndex(
                name: "IX_anaBilimDalis_AnaBilimDaliabdId",
                table: "anaBilimDalis");

            migrationBuilder.DropIndex(
                name: "IX_anaBilimDalis_doktorId",
                table: "anaBilimDalis");

            migrationBuilder.DropColumn(
                name: "AnaBilimDaliabdId",
                table: "anaBilimDalis");

            migrationBuilder.DropColumn(
                name: "doktorId",
                table: "anaBilimDalis");

            migrationBuilder.RenameColumn(
                name: "polName",
                table: "doktors",
                newName: "polId");
        }
    }
}
