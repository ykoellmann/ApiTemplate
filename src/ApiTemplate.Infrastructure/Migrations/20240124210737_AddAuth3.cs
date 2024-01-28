using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9493),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9144),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2689),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2346),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(6151),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(5658),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 214, DateTimeKind.Utc).AddTicks(290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7228),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(9310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4957),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4684),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(6739),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(4797),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6369),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6023),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(4944));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(3677),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2429));

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("76d8b0d4-cbf5-4255-8fde-8fb573ead3bc"), "Set" },
                    { new Guid("cad544a4-2156-4fc3-b653-636d7e0ba92d"), "Get" }
                });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Policy",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a53dba88-538b-4962-bd43-9d91cde2e2a6"), "SelfOrAdmin" });

            migrationBuilder.InsertData(
                schema: "ApiTemplate",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("eef1c2da-457f-4781-9dcd-8c04b027d2f5"), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_Name",
                schema: "ApiTemplate",
                table: "Policy",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Name",
                schema: "ApiTemplate",
                table: "Permission",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Policy_Name",
                schema: "ApiTemplate",
                table: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_Permission_Name",
                schema: "ApiTemplate",
                table: "Permission");

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("76d8b0d4-cbf5-4255-8fde-8fb573ead3bc"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("cad544a4-2156-4fc3-b653-636d7e0ba92d"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("a53dba88-538b-4962-bd43-9d91cde2e2a6"));

            migrationBuilder.DeleteData(
                schema: "ApiTemplate",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eef1c2da-457f-4781-9dcd-8c04b027d2f5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(1068),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 219, DateTimeKind.Utc).AddTicks(586),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9651),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 216, DateTimeKind.Utc).AddTicks(9237),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(532),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 215, DateTimeKind.Utc).AddTicks(200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 214, DateTimeKind.Utc).AddTicks(290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(9310),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 213, DateTimeKind.Utc).AddTicks(3796),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(8073),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 193, DateTimeKind.Utc).AddTicks(6018),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(5302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 192, DateTimeKind.Utc).AddTicks(4944),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 6, 14, 191, DateTimeKind.Utc).AddTicks(2429),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(3677));

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
    }
}
