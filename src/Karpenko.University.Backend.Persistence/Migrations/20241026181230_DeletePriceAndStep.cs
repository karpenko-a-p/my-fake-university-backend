using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeletePriceAndStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_course_price",
                schema: "university_backend",
                table: "courses_data");

            migrationBuilder.DropTable(
                name: "courses_steps",
                schema: "university_backend");

            migrationBuilder.DropTable(
                name: "products_prices",
                schema: "university_backend");

            migrationBuilder.DropIndex(
                name: "ix_courses_data_price_id",
                schema: "university_backend",
                table: "courses_data");

            migrationBuilder.DropColumn(
                name: "price_id",
                schema: "university_backend",
                table: "courses_data");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                schema: "university_backend",
                table: "courses_data",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                schema: "university_backend",
                table: "courses_data");

            migrationBuilder.AddColumn<long>(
                name: "price_id",
                schema: "university_backend",
                table: "courses_data",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "courses_steps",
                schema: "university_backend",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    passage_time = table.Column<int>(type: "integer", nullable: false),
                    position_index = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses_steps", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_steps",
                        column: x => x.course_id,
                        principalSchema: "university_backend",
                        principalTable: "courses_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products_prices",
                schema: "university_backend",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discount_percent = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    sale_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    sales_until = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products_prices", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_courses_data_price_id",
                schema: "university_backend",
                table: "courses_data",
                column: "price_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_courses_steps_course_id",
                schema: "university_backend",
                table: "courses_steps",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "fk_course_price",
                schema: "university_backend",
                table: "courses_data",
                column: "price_id",
                principalSchema: "university_backend",
                principalTable: "products_prices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
