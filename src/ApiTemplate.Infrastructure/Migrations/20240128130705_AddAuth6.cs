using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 289, DateTimeKind.Utc).AddTicks(3683),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 289, DateTimeKind.Utc).AddTicks(3153),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 287, DateTimeKind.Utc).AddTicks(5637),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 287, DateTimeKind.Utc).AddTicks(5136),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 285, DateTimeKind.Utc).AddTicks(7090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 285, DateTimeKind.Utc).AddTicks(6360),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 284, DateTimeKind.Utc).AddTicks(3511),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 284, DateTimeKind.Utc).AddTicks(2860),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 283, DateTimeKind.Utc).AddTicks(9183),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 283, DateTimeKind.Utc).AddTicks(8663),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 275, DateTimeKind.Utc).AddTicks(9826),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 275, DateTimeKind.Utc).AddTicks(7658),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 274, DateTimeKind.Utc).AddTicks(9545),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 274, DateTimeKind.Utc).AddTicks(9223),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 273, DateTimeKind.Utc).AddTicks(8757),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 273, DateTimeKind.Utc).AddTicks(8366),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Id", "Feature", "Name" },
                values: new object[,]
                {
                    { new Guid("9dbe241f-884a-485d-8dc6-4d183b5e701a"), "WeatherForecast", "WeatherForecast:Set" },
                    { new Guid("d1dbccbf-56d5-4698-b2ff-c5df8b88358f"), "WeatherForecast", "WeatherForecast:Get" },
                    { new Guid("ee51430f-4c62-4013-8c67-8c4faf4710ba"), "WeatherForecast", "WeatherForecast:Delete" }
                });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Policy",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("22b96710-484c-4df9-86da-d62f30a689d2"), "SelfOrAdmin" });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d6717309-622e-4577-98ae-1fc68fd157c3"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9dbe241f-884a-485d-8dc6-4d183b5e701a"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d1dbccbf-56d5-4698-b2ff-c5df8b88358f"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ee51430f-4c62-4013-8c67-8c4faf4710ba"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("22b96710-484c-4df9-86da-d62f30a689d2"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d6717309-622e-4577-98ae-1fc68fd157c3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(4232),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 289, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 792, DateTimeKind.Utc).AddTicks(3511),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 289, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(5181),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 287, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 789, DateTimeKind.Utc).AddTicks(4803),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 287, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 285, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 787, DateTimeKind.Utc).AddTicks(6422),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 285, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6643),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 284, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(6177),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 284, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2622),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 283, DateTimeKind.Utc).AddTicks(9183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 786, DateTimeKind.Utc).AddTicks(2293),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 283, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(6755),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 275, DateTimeKind.Utc).AddTicks(9826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 779, DateTimeKind.Utc).AddTicks(4626),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 275, DateTimeKind.Utc).AddTicks(7658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(5202),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 274, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 778, DateTimeKind.Utc).AddTicks(4754),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 274, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(1359),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 273, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 13, 5, 45, 777, DateTimeKind.Utc).AddTicks(981),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 28, 13, 7, 5, 273, DateTimeKind.Utc).AddTicks(8366));

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
    }
}
