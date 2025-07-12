using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeKorean.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdatecartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceAtTime",
                table: "CartItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceAtTime",
                table: "CartItem");
        }
    }
}
