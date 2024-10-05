using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "university_backend");

            migrationBuilder.CreateTable(
                name: "students_data",
                schema: "university_backend",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    avatar_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    registration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "timezone('utc', now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students_passwords",
                schema: "university_backend",
                columns: table => new
                {
                    student_id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students_passwords", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_student_password",
                        column: x => x.student_id,
                        principalSchema: "university_backend",
                        principalTable: "students_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students_passwords",
                schema: "university_backend");

            migrationBuilder.DropTable(
                name: "students_data",
                schema: "university_backend");
        }
    }
}
