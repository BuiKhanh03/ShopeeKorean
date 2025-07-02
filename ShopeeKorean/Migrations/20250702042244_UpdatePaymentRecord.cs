using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeKorean.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                table: "paymentrecord",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "paymentrecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderDescription",
                table: "paymentrecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "paymentrecord",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "paymentrecord");

            migrationBuilder.DropColumn(
                name: "OrderDescription",
                table: "paymentrecord");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "paymentrecord");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "paymentrecord",
                newName: "AmountPaid");
        }
    }
}
