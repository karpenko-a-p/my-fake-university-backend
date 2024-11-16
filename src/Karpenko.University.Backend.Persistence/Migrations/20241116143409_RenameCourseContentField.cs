using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameCourseContentField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "video_path",
                schema: "university_backend",
                table: "course_content",
                newName: "video_filename");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "video_filename",
                schema: "university_backend",
                table: "course_content",
                newName: "video_path");
        }
    }
}
