using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenBasedAuthentication.Migrations
{
    public partial class changingProgramAndVucutInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetSayisi",
                table: "uyePrograms");

            migrationBuilder.DropColumn(
                name: "TekrarSayisi",
                table: "uyePrograms");

            migrationBuilder.AddColumn<DateTime>(
                name: "eklemeTarihi",
                table: "uyeVucutInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SetSayisi",
                table: "antrenmen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TekrarSayisi",
                table: "antrenmen",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eklemeTarihi",
                table: "uyeVucutInfos");

            migrationBuilder.DropColumn(
                name: "SetSayisi",
                table: "antrenmen");

            migrationBuilder.DropColumn(
                name: "TekrarSayisi",
                table: "antrenmen");

            migrationBuilder.AddColumn<int>(
                name: "SetSayisi",
                table: "uyePrograms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TekrarSayisi",
                table: "uyePrograms",
                nullable: false,
                defaultValue: 0);
        }
    }
}
