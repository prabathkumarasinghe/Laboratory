using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDateOfBirthToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Appearance",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bacteria",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BileSalt",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bilirubin",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreakFastSample",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CReactiveProtein",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Casts",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "parameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Crystals",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DinnerSample",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpithelialCells",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Esr1stHour",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimateGfr",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FastingBloodGlucose",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Haemoglobin",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ketones",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LunchSample",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nitrite",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PH",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostPrandialBloodSugar",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Protien",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PusCells",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RandomBloodSugar",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RedBloodCells",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RhematoidFactor",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RheumatoidFactor",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SCreatinine",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SCreningSltdeMethod",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalmonellaParaTyphlI",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalmonellaTyphl",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalmonellaTyphlH",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SgotAST",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SgptALT",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecificGravity",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Urobilinogen",
                table: "parameters",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appearance",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Bacteria",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "BileSalt",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Bilirubin",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "BreakFastSample",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "CReactiveProtein",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Casts",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Crystals",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "DinnerSample",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "EpithelialCells",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Esr1stHour",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "EstimateGfr",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "FastingBloodGlucose",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Haemoglobin",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Ketones",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "LunchSample",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Nitrite",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "PH",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "PostPrandialBloodSugar",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Protien",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "PusCells",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "RandomBloodSugar",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "RedBloodCells",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "RhematoidFactor",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "RheumatoidFactor",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SCreatinine",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SCreningSltdeMethod",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SalmonellaParaTyphlI",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SalmonellaTyphl",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SalmonellaTyphlH",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SgotAST",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SgptALT",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "SpecificGravity",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Urobilinogen",
                table: "parameters");
        }
    }
}
