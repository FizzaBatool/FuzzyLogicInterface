using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class addNewCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestCodeLines",
                table: "TestsData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCodeLines",
                table: "TestsData");
        }
    }
}
