using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTestDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SgptALT",
                table: "parameters",
                newName: "VLDL");

            migrationBuilder.RenameColumn(
                name: "SgotAST",
                table: "parameters",
                newName: "TotalBilirubin");

            migrationBuilder.RenameColumn(
                name: "SalmonellaTyphlH",
                table: "parameters",
                newName: "YeastCells");

            migrationBuilder.RenameColumn(
                name: "SalmonellaTyphl",
                table: "parameters",
                newName: "UrineProtein");

            migrationBuilder.RenameColumn(
                name: "SalmonellaParaTyphlI",
                table: "parameters",
                newName: "UrineColor");

            migrationBuilder.RenameColumn(
                name: "SCreningSltdeMethod",
                table: "parameters",
                newName: "SerumCreatinine");

            migrationBuilder.RenameColumn(
                name: "SCreatinine",
                table: "parameters",
                newName: "SerumCalcium");

            migrationBuilder.RenameColumn(
                name: "RheumatoidFactor",
                table: "parameters",
                newName: "UrineBilirubin");

            migrationBuilder.RenameColumn(
                name: "RhematoidFactor",
                table: "parameters",
                newName: "Transparency");

            migrationBuilder.RenameColumn(
                name: "RedBloodCells",
                table: "parameters",
                newName: "ReducingSubstances");

            migrationBuilder.RenameColumn(
                name: "RandomBloodSugar",
                table: "parameters",
                newName: "SGPT");

            migrationBuilder.RenameColumn(
                name: "Protien",
                table: "parameters",
                newName: "RedCells");

            migrationBuilder.RenameColumn(
                name: "PostPrandialBloodSugar",
                table: "parameters",
                newName: "SGOT");

            migrationBuilder.RenameColumn(
                name: "PH",
                table: "parameters",
                newName: "Reaction");

            migrationBuilder.RenameColumn(
                name: "Nitrite",
                table: "parameters",
                newName: "PPBG");

            migrationBuilder.RenameColumn(
                name: "LunchSample",
                table: "parameters",
                newName: "RDW_SD");

            migrationBuilder.RenameColumn(
                name: "LD",
                table: "parameters",
                newName: "RDW_CV");

            migrationBuilder.RenameColumn(
                name: "Ketones",
                table: "parameters",
                newName: "Organisms");

            migrationBuilder.RenameColumn(
                name: "Hb",
                table: "parameters",
                newName: "RBS");

            migrationBuilder.RenameColumn(
                name: "Haemoglobin",
                table: "parameters",
                newName: "ProthrombinTime");

            migrationBuilder.RenameColumn(
                name: "Glucose",
                table: "parameters",
                newName: "PostLunch");

            migrationBuilder.RenameColumn(
                name: "FastingBloodGlucose",
                table: "parameters",
                newName: "PostDinner");

            migrationBuilder.RenameColumn(
                name: "EstimateGfr",
                table: "parameters",
                newName: "PostBreakfast");

            migrationBuilder.RenameColumn(
                name: "Esr1stHour",
                table: "parameters",
                newName: "PPBS");

            migrationBuilder.RenameColumn(
                name: "DinnerSample",
                table: "parameters",
                newName: "PLT");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "parameters",
                newName: "Mucous");

            migrationBuilder.RenameColumn(
                name: "BreakFastSample",
                table: "parameters",
                newName: "PDW");

            migrationBuilder.RenameColumn(
                name: "Bilirubin",
                table: "parameters",
                newName: "KetoneBodies");

            migrationBuilder.RenameColumn(
                name: "BileSalt",
                table: "parameters",
                newName: "HGB");

            migrationBuilder.RenameColumn(
                name: "Bacteria",
                table: "parameters",
                newName: "FBSADGW");

            migrationBuilder.RenameColumn(
                name: "Appearance",
                table: "parameters",
                newName: "FBS2");

            migrationBuilder.RenameColumn(
                name: "AST",
                table: "parameters",
                newName: "PCV");

            migrationBuilder.RenameColumn(
                name: "ALT",
                table: "parameters",
                newName: "PCT");

            migrationBuilder.RenameColumn(
                name: "ALP",
                table: "parameters",
                newName: "Monocytes");

            migrationBuilder.AddColumn<double>(
                name: "AlkalinePhosphatase",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Basophils",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ControlTime",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DirectBilirubin",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ESR",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FBG",
                table: "parameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FBS",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FBS1",
                table: "parameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GFR",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GTT_1stHour",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GTT_2ndHour",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GranAbsolute",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GranPercent",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Hemoglobin",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "INR",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IndirectBilirubin",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPregnant",
                table: "parameters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LymphAbsolute",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LymphPercent",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MCHC",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MIDAbsolute",
                table: "parameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MIDPercent",
                table: "parameters",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlkalinePhosphatase",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Basophils",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "ControlTime",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "DirectBilirubin",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "ESR",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "FBG",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "FBS",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "FBS1",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "GFR",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "GTT_1stHour",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "GTT_2ndHour",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "GranAbsolute",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "GranPercent",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Hemoglobin",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "INR",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "IndirectBilirubin",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "IsPregnant",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "LymphAbsolute",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "LymphPercent",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "MCHC",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "MIDAbsolute",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "MIDPercent",
                table: "parameters");

            migrationBuilder.RenameColumn(
                name: "YeastCells",
                table: "parameters",
                newName: "SalmonellaTyphlH");

            migrationBuilder.RenameColumn(
                name: "VLDL",
                table: "parameters",
                newName: "SgptALT");

            migrationBuilder.RenameColumn(
                name: "UrineProtein",
                table: "parameters",
                newName: "SalmonellaTyphl");

            migrationBuilder.RenameColumn(
                name: "UrineColor",
                table: "parameters",
                newName: "SalmonellaParaTyphlI");

            migrationBuilder.RenameColumn(
                name: "UrineBilirubin",
                table: "parameters",
                newName: "RheumatoidFactor");

            migrationBuilder.RenameColumn(
                name: "Transparency",
                table: "parameters",
                newName: "RhematoidFactor");

            migrationBuilder.RenameColumn(
                name: "TotalBilirubin",
                table: "parameters",
                newName: "SgotAST");

            migrationBuilder.RenameColumn(
                name: "SerumCreatinine",
                table: "parameters",
                newName: "SCreningSltdeMethod");

            migrationBuilder.RenameColumn(
                name: "SerumCalcium",
                table: "parameters",
                newName: "SCreatinine");

            migrationBuilder.RenameColumn(
                name: "SGPT",
                table: "parameters",
                newName: "RandomBloodSugar");

            migrationBuilder.RenameColumn(
                name: "SGOT",
                table: "parameters",
                newName: "PostPrandialBloodSugar");

            migrationBuilder.RenameColumn(
                name: "ReducingSubstances",
                table: "parameters",
                newName: "RedBloodCells");

            migrationBuilder.RenameColumn(
                name: "RedCells",
                table: "parameters",
                newName: "Protien");

            migrationBuilder.RenameColumn(
                name: "Reaction",
                table: "parameters",
                newName: "PH");

            migrationBuilder.RenameColumn(
                name: "RDW_SD",
                table: "parameters",
                newName: "LunchSample");

            migrationBuilder.RenameColumn(
                name: "RDW_CV",
                table: "parameters",
                newName: "LD");

            migrationBuilder.RenameColumn(
                name: "RBS",
                table: "parameters",
                newName: "Hb");

            migrationBuilder.RenameColumn(
                name: "ProthrombinTime",
                table: "parameters",
                newName: "Haemoglobin");

            migrationBuilder.RenameColumn(
                name: "PostLunch",
                table: "parameters",
                newName: "Glucose");

            migrationBuilder.RenameColumn(
                name: "PostDinner",
                table: "parameters",
                newName: "FastingBloodGlucose");

            migrationBuilder.RenameColumn(
                name: "PostBreakfast",
                table: "parameters",
                newName: "EstimateGfr");

            migrationBuilder.RenameColumn(
                name: "PPBS",
                table: "parameters",
                newName: "Esr1stHour");

            migrationBuilder.RenameColumn(
                name: "PPBG",
                table: "parameters",
                newName: "Nitrite");

            migrationBuilder.RenameColumn(
                name: "PLT",
                table: "parameters",
                newName: "DinnerSample");

            migrationBuilder.RenameColumn(
                name: "PDW",
                table: "parameters",
                newName: "BreakFastSample");

            migrationBuilder.RenameColumn(
                name: "PCV",
                table: "parameters",
                newName: "AST");

            migrationBuilder.RenameColumn(
                name: "PCT",
                table: "parameters",
                newName: "ALT");

            migrationBuilder.RenameColumn(
                name: "Organisms",
                table: "parameters",
                newName: "Ketones");

            migrationBuilder.RenameColumn(
                name: "Mucous",
                table: "parameters",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "Monocytes",
                table: "parameters",
                newName: "ALP");

            migrationBuilder.RenameColumn(
                name: "KetoneBodies",
                table: "parameters",
                newName: "Bilirubin");

            migrationBuilder.RenameColumn(
                name: "HGB",
                table: "parameters",
                newName: "BileSalt");

            migrationBuilder.RenameColumn(
                name: "FBSADGW",
                table: "parameters",
                newName: "Bacteria");

            migrationBuilder.RenameColumn(
                name: "FBS2",
                table: "parameters",
                newName: "Appearance");
        }
    }
}
