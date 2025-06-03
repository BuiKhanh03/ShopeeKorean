using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeKorean.Application.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "SELLER", "Seller" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "CUSTOMER", "CUSTOMER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Administrator", "ADMINISTRATOR" });
        }
    }
}
