using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenBasedAuthentication.Migrations
{
    public partial class v201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "antrenmen",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "antrenmen");
        }
    }
}
