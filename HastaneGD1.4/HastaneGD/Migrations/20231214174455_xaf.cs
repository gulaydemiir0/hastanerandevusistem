using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD.Migrations
{
    public partial class xaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_polikliniks_poliklinikpolId",
                table: "doktors");

            migrationBuilder.RenameColumn(
                name: "poliklinikpolId",
                table: "doktors",
                newName: "PoliklinikpolId");

            migrationBuilder.RenameIndex(
                name: "IX_doktors_poliklinikpolId",
                table: "doktors",
                newName: "IX_doktors_PoliklinikpolId");

            migrationBuilder.AlterColumn<int>(
                name: "PoliklinikpolId",
                table: "doktors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikpolId",
                table: "doktors",
                column: "PoliklinikpolId",
                principalTable: "polikliniks",
                principalColumn: "polId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktors_polikliniks_PoliklinikpolId",
                table: "doktors");

            migrationBuilder.RenameColumn(
                name: "PoliklinikpolId",
                table: "doktors",
                newName: "poliklinikpolId");

            migrationBuilder.RenameIndex(
                name: "IX_doktors_PoliklinikpolId",
                table: "doktors",
                newName: "IX_doktors_poliklinikpolId");

            migrationBuilder.AlterColumn<int>(
                name: "poliklinikpolId",
                table: "doktors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_doktors_polikliniks_poliklinikpolId",
                table: "doktors",
                column: "poliklinikpolId",
                principalTable: "polikliniks",
                principalColumn: "polId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
