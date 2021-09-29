using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmEasy.Data.Migrations
{
    public partial class Soil_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoilDetails",
                table: "SoilTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoilDetails",
                table: "SoilTypes");
        }
    }
}
