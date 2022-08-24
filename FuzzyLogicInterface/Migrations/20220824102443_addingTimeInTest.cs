using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class addingTimeInTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndSession",
                table: "ModulesData");

            migrationBuilder.AddColumn<DateTime>(
                name: "dbEntry",
                table: "TestsData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbEntry",
                table: "TestsData");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndSession",
                table: "ModulesData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
