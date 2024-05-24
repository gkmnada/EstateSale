using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationAPI.Migrations
{
    /// <inheritdoc />
    public partial class update_table_estate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sales_type",
                table: "estate",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sales_type",
                table: "estate");
        }
    }
}
