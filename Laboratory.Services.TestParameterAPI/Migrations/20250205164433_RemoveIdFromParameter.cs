using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdFromParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "parameters",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "parameters",
                newName: "TestId");
        }
    }
}
