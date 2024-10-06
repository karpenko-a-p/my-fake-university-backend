using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "university_backend",
                columns: table => new
                {
                    owner_id = table.Column<long>(type: "bigint", nullable: false),
                    subject_id = table.Column<long>(type: "bigint", nullable: false),
                    permission_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => new { x.owner_id, x.subject_id, x.permission_type });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissions",
                schema: "university_backend");
        }
    }
}
