using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTestParameterTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNumber = table.Column<int>(type: "int", nullable: false),
                    LabNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCholesterol = table.Column<int>(type: "int", nullable: true),
                    Triglycerides = table.Column<int>(type: "int", nullable: true),
                    HDL = table.Column<int>(type: "int", nullable: true),
                    LDL = table.Column<int>(type: "int", nullable: true),
                    CholHDLRatio = table.Column<int>(type: "int", nullable: true),
                    NonHDLChol = table.Column<int>(type: "int", nullable: true),
                    ALP = table.Column<int>(type: "int", nullable: true),
                    GGT = table.Column<int>(type: "int", nullable: true),
                    LD = table.Column<int>(type: "int", nullable: true),
                    AST = table.Column<int>(type: "int", nullable: true),
                    ALT = table.Column<int>(type: "int", nullable: true),
                    TotalProtein = table.Column<int>(type: "int", nullable: true),
                    Albumin = table.Column<int>(type: "int", nullable: true),
                    Globulin = table.Column<int>(type: "int", nullable: true),
                    Sodium = table.Column<int>(type: "int", nullable: true),
                    Potassium = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.TestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parameters");
        }
    }
}
