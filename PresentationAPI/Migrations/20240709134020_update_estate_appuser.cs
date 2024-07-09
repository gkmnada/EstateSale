using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationAPI.Migrations
{
    /// <inheritdoc />
    public partial class update_estate_appuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "app_user_id",
                table: "estate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "app_user_id",
                table: "estate",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
