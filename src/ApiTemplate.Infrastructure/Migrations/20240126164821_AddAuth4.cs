using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 636, DateTimeKind.Utc).AddTicks(357),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 635, DateTimeKind.Utc).AddTicks(9671),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(4048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(3526),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(8440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(7761),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(106),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(9738),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(7046),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(6766),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 625, DateTimeKind.Utc).AddTicks(812),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(8874),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1649),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(2135),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(1782),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(3677));

            migrationBuilder.AddColumn<string>(
                name: "Feature",
                schema: "ApiTemplate",
                table: "Permission",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Feature_Name",
                schema: "ApiTemplate",
                table: "Permission",
                columns: new[] { "Feature", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permission_Feature_Name",
                schema: "ApiTemplate",
                table: "Permission");

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

            migrationBuilder.DropColumn(
                name: "Feature",
                schema: "ApiTemplate",
                table: "Permission");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9493),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 636, DateTimeKind.Utc).AddTicks(357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9144),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 635, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2689),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPolicy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2346),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 633, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(6151),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(8440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "UserPermission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(5658),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 631, DateTimeKind.Utc).AddTicks(106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7228),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(9738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4957),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4684),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 630, DateTimeKind.Utc).AddTicks(6766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(6739),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 625, DateTimeKind.Utc).AddTicks(812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(4797),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6369),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Policy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6023),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 624, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(3677),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 26, 16, 48, 21, 623, DateTimeKind.Utc).AddTicks(1782));

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
                name: "IX_Permission_Name",
                schema: "ApiTemplate",
                table: "Permission",
                column: "Name",
                unique: true);
        }
    }
}
