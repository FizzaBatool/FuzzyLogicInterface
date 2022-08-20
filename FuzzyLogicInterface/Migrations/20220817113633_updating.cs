using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InputData",
                table: "InputData");

            migrationBuilder.RenameTable(
                name: "InputData",
                newName: "TestsData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestsData",
                table: "TestsData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestsData",
                table: "TestsData");

            migrationBuilder.RenameTable(
                name: "TestsData",
                newName: "InputData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InputData",
                table: "InputData",
                column: "Id");
        }
    }
}
