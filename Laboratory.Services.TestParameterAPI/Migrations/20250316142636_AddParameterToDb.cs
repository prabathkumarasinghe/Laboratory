using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddParameterToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RefNumber",
                table: "parameters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "parameters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LabNumber",
                table: "parameters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Eosinophils",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HCT",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hb",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lymphocytes",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MCH",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MCV",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MPV",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Neutrophils",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlateletCount",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RBC",
                table: "parameters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WBC",
                table: "parameters",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eosinophils",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "HCT",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Hb",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Lymphocytes",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "MCH",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "MCV",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "MPV",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "Neutrophils",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "PlateletCount",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "RBC",
                table: "parameters");

            migrationBuilder.DropColumn(
                name: "WBC",
                table: "parameters");

            migrationBuilder.AlterColumn<int>(
                name: "RefNumber",
                table: "parameters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "parameters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LabNumber",
                table: "parameters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
