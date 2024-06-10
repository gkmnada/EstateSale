using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationAPI.Migrations
{
    /// <inheritdoc />
    public partial class update_estate_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "employee_id",
                table: "estate",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "estate");
        }
    }
}
