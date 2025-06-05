using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopeeKorean.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb711"), "Thiết bị gia dụng" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb712"), "Pet - Đồ dùng thú cưng" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb721"), "Đồng hồ & Trang sức" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb723"), "Thể thao & Dã ngoại" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb724"), "Sách & Văn phòng phẩm" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb725"), "Thực phẩm & Đồ uống" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb727"), "Game & Console" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb728"), "Sức khỏe & Làm đẹp" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb729"), "Ô tô - Xe máy - Xe đạp" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb730"), "Túi xách / Balo" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb731"), "Giày dép Nam / Nữ" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb732"), "Nhà cửa & Đời sống" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb733"), "Mẹ & Bé" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb734"), "Thời trang Nữ" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb735"), "Thời trang Nam" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb736"), "Máy ảnh & Máy quay phim" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb737"), "Thiết bị điện tử" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb738"), "Máy tính & Laptop" },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), "Điện thoại & Phụ kiện" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb711"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb712"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb721"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb723"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb724"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb725"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb727"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb728"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb729"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb730"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb731"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb732"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb733"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb734"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb735"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb736"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb737"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb738"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"));

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Product");
        }
    }
}
