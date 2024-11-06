using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karpenko.University.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderPaymentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "payment_time",
                schema: "university_backend",
                table: "orders_data",
                newName: "create_date");

            migrationBuilder.AddColumn<string>(
                name: "payment_status",
                schema: "university_backend",
                table: "orders_data",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment_status",
                schema: "university_backend",
                table: "orders_data");

            migrationBuilder.RenameColumn(
                name: "create_date",
                schema: "university_backend",
                table: "orders_data",
                newName: "payment_time");
        }
    }
}
