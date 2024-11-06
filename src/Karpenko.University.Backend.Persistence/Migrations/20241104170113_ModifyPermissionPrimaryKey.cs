using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPermissionPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_permissions",
                schema: "university_backend",
                table: "permissions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_permissions",
                schema: "university_backend",
                table: "permissions",
                columns: new[] { "owner_id", "subject_id", "permission_type", "permission_subject" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_permissions",
                schema: "university_backend",
                table: "permissions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_permissions",
                schema: "university_backend",
                table: "permissions",
                columns: new[] { "owner_id", "subject_id", "permission_type" });
        }
    }
}
