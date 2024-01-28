using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("85691f11-36f8-4a88-8994-99b422d6f3af"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b4d43f1e-16da-4c33-9a1d-115479c3c77b"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("b84a43f6-413e-41d9-851e-831ad0cd5f4a"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("839b7836-cc23-4a4d-9711-28fca2bf1524"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(1068),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(8439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(586),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(7968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9651),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9237),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(1886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(532),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 214, DateTimeKind.Utc).AddTicks(290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(9310),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(3796),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(8073),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 751, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(6018),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(5302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(4944),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 749, DateTimeKind.Utc).AddTicks(385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2429),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 748, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b1084a95-2654-44f2-bf7b-8a18e478c6db"), "Get" },
                    { new Guid("bf65a940-ee0e-40d6-84d2-d8fe61a3865a"), "Set" }
                });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Policy",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7f109a54-8f28-4931-85d6-75dfdf12cbfb"), "SelfOrAdmin" });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9ad3203f-fa5d-4891-8ac0-640acbd36c33"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b1084a95-2654-44f2-bf7b-8a18e478c6db"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("bf65a940-ee0e-40d6-84d2-d8fe61a3865a"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("7f109a54-8f28-4931-85d6-75dfdf12cbfb"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9ad3203f-fa5d-4891-8ac0-640acbd36c33"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(8439),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(7968),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(2486),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(1886),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5601),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5175),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(6030),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 214, DateTimeKind.Utc).AddTicks(290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(5626),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(9310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2608),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2149),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 751, DateTimeKind.Utc).AddTicks(1220),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(9337),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1524),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1107),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(4944));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 749, DateTimeKind.Utc).AddTicks(385),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 748, DateTimeKind.Utc).AddTicks(9952),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2429));

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("85691f11-36f8-4a88-8994-99b422d6f3af"), "Set" },
                    { new Guid("b4d43f1e-16da-4c33-9a1d-115479c3c77b"), "Get" }
                });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Policy",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b84a43f6-413e-41d9-851e-831ad0cd5f4a"), "SelfOrAdmin" });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("839b7836-cc23-4a4d-9711-28fca2bf1524"), "Admin" });
        }
    }
}
