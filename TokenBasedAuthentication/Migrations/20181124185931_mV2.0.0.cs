using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenBasedAuthentication.Migrations
{
    public partial class mV200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gelirs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GelirAdi = table.Column<string>(nullable: true),
                    GelirMiktari = table.Column<double>(nullable: false),
                    tarih = table.Column<DateTime>(nullable: false),
                    uyeOdemeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gelirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gelirs_uyeOdemes_uyeOdemeId",
                        column: x => x.uyeOdemeId,
                        principalTable: "uyeOdemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "giders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GiderAciklama = table.Column<string>(nullable: true),
                    GiderMiktari = table.Column<double>(nullable: false),
                    tarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uruns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunAdi = table.Column<string>(nullable: true),
                    UrunFiyati = table.Column<double>(nullable: false),
                    UrunMiktari = table.Column<int>(nullable: false),
                    UrunAdedi = table.Column<int>(nullable: false),
                    GelirId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uruns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uruns_gelirs_GelirId",
                        column: x => x.GelirId,
                        principalTable: "gelirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stoks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(nullable: false),
                    StokMiktari = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stoks_uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "uruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gelirs_uyeOdemeId",
                table: "gelirs",
                column: "uyeOdemeId");

            migrationBuilder.CreateIndex(
                name: "IX_stoks_UrunId",
                table: "stoks",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_uruns_GelirId",
                table: "uruns",
                column: "GelirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "giders");

            migrationBuilder.DropTable(
                name: "stoks");

            migrationBuilder.DropTable(
                name: "uruns");

            migrationBuilder.DropTable(
                name: "gelirs");
        }
    }
}
