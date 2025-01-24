using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Services.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalCholesterolToOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalCholesterol",
                table: "OrderHeaders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCholesterol",
                table: "OrderHeaders");
        }
    }
}
