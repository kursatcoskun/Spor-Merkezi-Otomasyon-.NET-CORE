using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenBasedAuthentication.Migrations
{
    public partial class v210 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrunAdedi",
                table: "uruns");

            migrationBuilder.RenameColumn(
                name: "UrunMiktari",
                table: "uruns",
                newName: "ToplamUrunAdedi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToplamUrunAdedi",
                table: "uruns",
                newName: "UrunMiktari");

            migrationBuilder.AddColumn<int>(
                name: "UrunAdedi",
                table: "uruns",
                nullable: false,
                defaultValue: 0);
        }
    }
}
