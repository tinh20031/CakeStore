using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class refreshertoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(785), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(815), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(821), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(821), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(823), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(823), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(942), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(943), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(953), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(954), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(958), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(958), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(1029), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "PromotionId",
                keyValue: 1,
                columns: new[] { "Created_At", "EndDate", "StartDate", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(1002), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(2025, 10, 15), new DateOnly(2025, 9, 15), new DateTimeOffset(new DateTime(2025, 9, 15, 15, 24, 8, 947, DateTimeKind.Unspecified).AddTicks(1003), new TimeSpan(0, 7, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(888), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(893), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(893), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(895), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1183), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1185), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1193), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1194), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1197), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1197), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1213), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1214), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1216), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1216), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1218), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1219), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1323), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1326), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "PromotionId",
                keyValue: 1,
                columns: new[] { "Created_At", "EndDate", "StartDate", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(2025, 10, 12), new DateOnly(2025, 9, 12), new DateTimeOffset(new DateTime(2025, 9, 12, 23, 33, 46, 923, DateTimeKind.Unspecified).AddTicks(1284), new TimeSpan(0, 7, 0, 0, 0)) });
        }
    }
}
