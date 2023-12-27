using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class deneme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_anaBilimDalis_AnaBilimDaliabdId",
                table: "doktors");

            migrationBuilder.DropIndex(
                name: "IX_doktors_AnaBilimDaliabdId",
                table: "doktors");

            migrationBuilder.DropColumn(
                name: "AnaBilimDaliabdId",
                table: "doktors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnaBilimDaliabdId",
                table: "doktors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_doktors_AnaBilimDaliabdId",
                table: "doktors",
                column: "AnaBilimDaliabdId");

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_anaBilimDalis_AnaBilimDaliabdId",
                table: "doktors",
                column: "AnaBilimDaliabdId",
                principalTable: "anaBilimDalis",
                principalColumn: "abdId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
