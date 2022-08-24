using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class someEDIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TestCodeLines",
                table: "TestsData",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TestCodeLines",
                table: "TestsData",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
