using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class ruleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestRecord",
                table: "TestRecord");

            migrationBuilder.RenameTable(
                name: "TestRecord",
                newName: "InputData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InputData",
                table: "InputData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InputData",
                table: "InputData");

            migrationBuilder.RenameTable(
                name: "InputData",
                newName: "TestRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestRecord",
                table: "TestRecord",
                column: "Id");
        }
    }
}
