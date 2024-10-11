using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseRedesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_courses_bind_tags_course_entity_course_id",
                schema: "university_backend",
                table: "courses_bind_tags");

            migrationBuilder.DropForeignKey(
                name: "fk_courses_bind_tags_course_tag_entity_tag_id",
                schema: "university_backend",
                table: "courses_bind_tags");

            migrationBuilder.AddForeignKey(
                name: "fk_courses_tags_bind_course",
                schema: "university_backend",
                table: "courses_bind_tags",
                column: "course_id",
                principalSchema: "university_backend",
                principalTable: "courses_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_courses_tags_bind_tag",
                schema: "university_backend",
                table: "courses_bind_tags",
                column: "tag_id",
                principalSchema: "university_backend",
                principalTable: "courses_tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_courses_tags_bind_course",
                schema: "university_backend",
                table: "courses_bind_tags");

            migrationBuilder.DropForeignKey(
                name: "fk_courses_tags_bind_tag",
                schema: "university_backend",
                table: "courses_bind_tags");

            migrationBuilder.AddForeignKey(
                name: "fk_courses_bind_tags_course_entity_course_id",
                schema: "university_backend",
                table: "courses_bind_tags",
                column: "course_id",
                principalSchema: "university_backend",
                principalTable: "courses_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_courses_bind_tags_course_tag_entity_tag_id",
                schema: "university_backend",
                table: "courses_bind_tags",
                column: "tag_id",
                principalSchema: "university_backend",
                principalTable: "courses_tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
