using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class adding2Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputData");

            migrationBuilder.CreateTable(
                name: "ModulesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCodeLines = table.Column<int>(type: "int", nullable: false),
                    StartSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndSession = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCodeLinesEntered = table.Column<int>(type: "int", nullable: false),
                    CriticalityOfRequirement = table.Column<float>(type: "real", nullable: false),
                    CodeCoverage = table.Column<int>(type: "int", nullable: false),
                    FaultCoverage = table.Column<float>(type: "real", nullable: false),
                    PriorityValue = table.Column<float>(type: "real", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulesData");

            migrationBuilder.DropTable(
                name: "TestRecord");

            migrationBuilder.CreateTable(
                name: "InputData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeCoverage = table.Column<int>(type: "int", nullable: false),
                    CriticalityOfRequirement = table.Column<float>(type: "real", nullable: false),
                    FaultCoverage = table.Column<float>(type: "real", nullable: false),
                    ModuleCodeLines = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityValue = table.Column<float>(type: "real", nullable: false),
                    RecordNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputData", x => x.Id);
                });
        }
    }
}
