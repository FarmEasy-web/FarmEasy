using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmEasy.Data.Migrations
{
    public partial class Add_Table_Crop_Soli_And_Mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CropDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature_Min = table.Column<float>(nullable: false),
                    Temperature_Max = table.Column<float>(nullable: false),
                    CropName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropSoilMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropId = table.Column<int>(nullable: false),
                    SoilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropSoilMappings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoilTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoilName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CropDetails");

            migrationBuilder.DropTable(
                name: "CropSoilMappings");

            migrationBuilder.DropTable(
                name: "SoilTypes");
        }
    }
}
