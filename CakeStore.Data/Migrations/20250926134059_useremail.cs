using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class useremail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailVerificationToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmailVerificationTokenExpiry",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4431), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4435), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4441), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4441), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4921), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4921), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4930), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4930), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4950), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4950), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4954), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(4954), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(5057), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PromotionProducts",
                keyColumn: "PromotionProductsId",
                keyValue: 2,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(5058), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(5059), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "PromotionId",
                keyValue: 1,
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(5022), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 40, 59, 526, DateTimeKind.Unspecified).AddTicks(5022), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailVerificationToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailVerificationTokenExpiry",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                table: "Users");

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
                columns: new[] { "Created_At", "Updated_At" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 9, 26, 13, 20, 14, 101, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
