using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "university_backend",
                table: "products_prices");

            migrationBuilder.AddColumn<long>(
                name: "course_id",
                schema: "university_backend",
                table: "courses_steps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "author_id",
                schema: "university_backend",
                table: "courses_comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "course_id",
                schema: "university_backend",
                table: "courses_comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "courses_data",
                schema: "university_backend",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    creation_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    bought_count = table.Column<long>(type: "bigint", nullable: false),
                    price_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses_data", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_price",
                        column: x => x.price_id,
                        principalSchema: "university_backend",
                        principalTable: "products_prices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses_bind_tags",
                schema: "university_backend",
                columns: table => new
                {
                    course_id = table.Column<long>(type: "bigint", nullable: false),
                    tag_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses_bind_tags", x => new { x.course_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_courses_bind_tags_course_entity_course_id",
                        column: x => x.course_id,
                        principalSchema: "university_backend",
                        principalTable: "courses_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_courses_bind_tags_course_tag_entity_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "university_backend",
                        principalTable: "courses_tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_courses_steps_course_id",
                schema: "university_backend",
                table: "courses_steps",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_courses_comments_course_id",
                schema: "university_backend",
                table: "courses_comments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_courses_bind_tags_tag_id",
                schema: "university_backend",
                table: "courses_bind_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_courses_data_price_id",
                schema: "university_backend",
                table: "courses_data",
                column: "price_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_course_comments_course",
                schema: "university_backend",
                table: "courses_comments",
                column: "course_id",
                principalSchema: "university_backend",
                principalTable: "courses_data",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_course_steps",
                schema: "university_backend",
                table: "courses_steps",
                column: "course_id",
                principalSchema: "university_backend",
                principalTable: "courses_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_course_comments_course",
                schema: "university_backend",
                table: "courses_comments");

            migrationBuilder.DropForeignKey(
                name: "fk_course_steps",
                schema: "university_backend",
                table: "courses_steps");

            migrationBuilder.DropTable(
                name: "courses_bind_tags",
                schema: "university_backend");

            migrationBuilder.DropTable(
                name: "courses_data",
                schema: "university_backend");

            migrationBuilder.DropIndex(
                name: "ix_courses_steps_course_id",
                schema: "university_backend",
                table: "courses_steps");

            migrationBuilder.DropIndex(
                name: "ix_courses_comments_course_id",
                schema: "university_backend",
                table: "courses_comments");

            migrationBuilder.DropColumn(
                name: "course_id",
                schema: "university_backend",
                table: "courses_steps");

            migrationBuilder.DropColumn(
                name: "course_id",
                schema: "university_backend",
                table: "courses_comments");

            migrationBuilder.AddColumn<long>(
                name: "product_id",
                schema: "university_backend",
                table: "products_prices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "author_id",
                schema: "university_backend",
                table: "courses_comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
