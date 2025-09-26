using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class verifyemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8173), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8183), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8184), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8185), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8185), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8472), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8480), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8480), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8483), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8487), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8487), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "PromotionId",
                keyValue: 1,
                columns: new[] { "Created_At", "EndDate", "StartDate", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2025, 10, 26), new DateOnly(2025, 9, 26), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "OrderDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5026), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5031), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5193), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5193), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5202), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5202), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5204), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5274), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "PromotionId",
                keyValue: 1,
                columns: new[] { "Created_At", "EndDate", "StartDate", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5255), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2025, 10, 22), new DateOnly(2025, 9, 22), new DateTimeOffset(new DateTime(2025, 9, 22, 9, 59, 34, 427, DateTimeKind.Unspecified).AddTicks(5255), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
