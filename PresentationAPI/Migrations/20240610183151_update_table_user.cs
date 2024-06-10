using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationAPI.Migrations
{
    /// <inheritdoc />
    public partial class update_table_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "app_user",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "app_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "app_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "app_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "AppRoleID",
                table: "app_user",
                newName: "app_role_id");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "app_user",
                newName: "app_user_id");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "app_role",
                newName: "role_name");

            migrationBuilder.RenameColumn(
                name: "AppRoleID",
                table: "app_role",
                newName: "app_role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "app_user",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "app_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "app_user",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "app_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "app_role_id",
                table: "app_user",
                newName: "AppRoleID");

            migrationBuilder.RenameColumn(
                name: "app_user_id",
                table: "app_user",
                newName: "AppUserID");

            migrationBuilder.RenameColumn(
                name: "role_name",
                table: "app_role",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "app_role_id",
                table: "app_role",
                newName: "AppRoleID");
        }
    }
}
