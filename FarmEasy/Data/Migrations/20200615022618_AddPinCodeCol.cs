using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmEasy.Data.Migrations
{
    public partial class AddPinCodeCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "Cities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Cities");
        }
    }
}
