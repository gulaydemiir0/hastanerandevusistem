using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneGD1.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anaBilimDali",
                columns: table => new
                {
                    abdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abdName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anaBilimDali", x => x.abdId);
                });

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
                name: "randevus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliklinikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anaBilimDali");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "polikliniks");

            migrationBuilder.DropTable(
                name: "randevus");
        }
    }
}
