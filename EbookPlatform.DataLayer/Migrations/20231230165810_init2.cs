using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookPlatform.DataLayer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "permissionID", "permissionTitle" },
                values: new object[,]
                {
                    { 1, "ContentManager" },
                    { 2, "UserManager" },
                    { 3, "AdminUserManager" },
                    { 4, "CommentsManager" },
                    { 5, "ReportsManager" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "roleID", "roleTitle" },
                values: new object[] { 1, "sa" });

            migrationBuilder.InsertData(
                table: "adminUsers",
                columns: new[] { "adminUserID", "adminUserEmail", "adminUserName", "adminUserPassword", "roleID" },
                values: new object[] { 1, "admin@admin.ir", "admin", "admin", 1 });

            migrationBuilder.InsertData(
                table: "rolePermissions",
                columns: new[] { "rolePermissionID", "permissionid", "roleid" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "adminUsers",
                keyColumn: "adminUserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "rolePermissions",
                keyColumn: "rolePermissionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "rolePermissions",
                keyColumn: "rolePermissionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "rolePermissions",
                keyColumn: "rolePermissionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "rolePermissions",
                keyColumn: "rolePermissionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "rolePermissions",
                keyColumn: "rolePermissionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "permissionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "permissionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "permissionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "permissionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "permissionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "roleID",
                keyValue: 1);
        }
    }
}
