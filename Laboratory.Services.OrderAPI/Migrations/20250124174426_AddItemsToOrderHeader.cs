using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsToOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CholHDLRatio",
                table: "OrderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HDL",
                table: "OrderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LDL",
                table: "OrderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NonHDLChol",
                table: "OrderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Triglycerides",
                table: "OrderHeaders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CholHDLRatio",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "HDL",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "LDL",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "NonHDLChol",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Triglycerides",
                table: "OrderHeaders");
        }
    }
}
