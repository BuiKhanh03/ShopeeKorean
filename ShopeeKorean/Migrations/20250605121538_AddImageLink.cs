using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeKorean.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddImageLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "ProductImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Coupon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Coupon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb711"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb712"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb721"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb723"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb724"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb725"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb727"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb728"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb729"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb730"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb731"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb732"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb733"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb734"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb735"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb736"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb737"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb738"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "N/A", "N/A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
