using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuzzyLogicInterface.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordNo = table.Column<int>(type: "int", nullable: false),
                    ModuleCodeLines = table.Column<int>(type: "int", nullable: false),
                    CriticalityOfRequirement = table.Column<float>(type: "real", nullable: false),
                    CodeCoverage = table.Column<int>(type: "int", nullable: false),
                    FaultCoverage = table.Column<float>(type: "real", nullable: false),
                    PriorityValue = table.Column<float>(type: "real", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputData");
        }
    }
}
