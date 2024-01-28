using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("5a49862e-9f5e-413f-acc5-10257cba195e"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f563a999-f5ec-4b42-b9b1-606ef9eb7e1e"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("8c442f17-8310-4744-9d27-9bc841eae44f"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f02883cc-4715-477a-9b87-7ccd28a90d52"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(4232),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 636, DateTimeKind.Utc).AddTicks(357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(3511),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 635, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(5181),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(4803),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(8440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6422),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6643),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6177),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(9738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2622),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2293),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(6766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(6755),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 625, DateTimeKind.Utc).AddTicks(812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(4626),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(5202),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(4754),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(1359),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(981),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Id", "Feature", "Name" },
                values: new object[,]
                {
                    { new Guid("0a7e085c-f639-47db-afa0-fbd273e0fd1b"), "WeatherForecast", "WeatherForecast:Set" },
                    { new Guid("eee04d2f-7eed-48b6-ad10-32c36aa51e06"), "WeatherForecast", "WeatherForecast:Get" }
                });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Policy",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5add906c-b0f7-4da4-a257-388cb1095a56"), "SelfOrAdmin" });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("113f2a57-4b41-42b1-9e0f-95db56ef4fc9"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("0a7e085c-f639-47db-afa0-fbd273e0fd1b"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("eee04d2f-7eed-48b6-ad10-32c36aa51e06"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("5add906c-b0f7-4da4-a257-388cb1095a56"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("113f2a57-4b41-42b1-9e0f-95db56ef4fc9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 636, DateTimeKind.Utc).AddTicks(357),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 635, DateTimeKind.Utc).AddTicks(9671),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(4048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(3526),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(8440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(7761),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(106),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(9738),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(7046),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(6766),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 625, DateTimeKind.Utc).AddTicks(812),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(8874),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1649),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(2135),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(1782),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Id", "Feature", "Name" },
                values: new object[,]
                {
                    { new Guid("5a49862e-9f5e-413f-acc5-10257cba195e"), "Example", "Example:Set" },
                    { new Guid("f563a999-f5ec-4b42-b9b1-606ef9eb7e1e"), "Example", "Example:Get" }
                });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Policy",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8c442f17-8310-4744-9d27-9bc841eae44f"), "SelfOrAdmin" });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f02883cc-4715-477a-9b87-7ccd28a90d52"), "Admin" });
        }
    }
}
