using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeKorean.Application.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "Shipping");

            migrationBuilder.AlterColumn<int>(
                name: "Carrier",
                table: "Shipping",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Carrier",
                table: "Shipping",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "Shipping",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
