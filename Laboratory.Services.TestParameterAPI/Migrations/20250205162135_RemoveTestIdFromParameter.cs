using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTestIdFromParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "parameters",
                newName: "PatientName");

            migrationBuilder.AddColumn<int>(
                name: "Glucose",
                table: "parameters",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Glucose",
                table: "parameters");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "parameters",
                newName: "Name");
        }
    }
}
