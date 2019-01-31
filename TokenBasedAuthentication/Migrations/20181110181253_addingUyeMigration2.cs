using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenBasedAuthentication.Migrations
{
    public partial class addingUyeMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uyes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uyeOdemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UyeId = table.Column<int>(nullable: false),
                    UyelikTipi = table.Column<string>(nullable: true),
                    UyelikSuresi = table.Column<int>(nullable: false),
                    KayitTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyeOdemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uyeOdemes_uyes_UyeId",
                        column: x => x.UyeId,
                        principalTable: "uyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uyePrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UyeId = table.Column<int>(nullable: false),
                    SetSayisi = table.Column<int>(nullable: false),
                    TekrarSayisi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyePrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uyePrograms_uyes_UyeId",
                        column: x => x.UyeId,
                        principalTable: "uyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uyeVucutInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UyeId = table.Column<int>(nullable: false),
                    Boy = table.Column<double>(nullable: false),
                    Kilo = table.Column<double>(nullable: false),
                    SolKol = table.Column<double>(nullable: false),
                    SagKol = table.Column<double>(nullable: false),
                    Omuz = table.Column<double>(nullable: false),
                    Gogus = table.Column<double>(nullable: false),
                    Bel = table.Column<double>(nullable: false),
                    SolBacak = table.Column<double>(nullable: false),
                    SagBacak = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyeVucutInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uyeVucutInfos_uyes_UyeId",
                        column: x => x.UyeId,
                        principalTable: "uyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "antrenmen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AntrenmanAdi = table.Column<string>(nullable: true),
                    UyeProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_antrenmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_antrenmen_uyePrograms_UyeProgramId",
                        column: x => x.UyeProgramId,
                        principalTable: "uyePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_antrenmen_UyeProgramId",
                table: "antrenmen",
                column: "UyeProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_uyeOdemes_UyeId",
                table: "uyeOdemes",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_uyePrograms_UyeId",
                table: "uyePrograms",
                column: "UyeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uyeVucutInfos_UyeId",
                table: "uyeVucutInfos",
                column: "UyeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "antrenmen");

            migrationBuilder.DropTable(
                name: "uyeOdemes");

            migrationBuilder.DropTable(
                name: "uyeVucutInfos");

            migrationBuilder.DropTable(
                name: "uyePrograms");

            migrationBuilder.DropTable(
                name: "uyes");
        }
    }
}
