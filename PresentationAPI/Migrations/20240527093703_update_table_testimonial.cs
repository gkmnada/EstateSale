using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationAPI.Migrations
{
    /// <inheritdoc />
    public partial class update_table_testimonial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "testimonial",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "testimonial",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "testimonial",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "testimonial",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "TestimonialID",
                table: "testimonial",
                newName: "testimonial_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "testimonial",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "testimonial",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "testimonial",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "testimonial",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "testimonial_id",
                table: "testimonial",
                newName: "TestimonialID");
        }
    }
}
