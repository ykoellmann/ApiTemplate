using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 153, DateTimeKind.Utc).AddTicks(153),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 152, DateTimeKind.Utc).AddTicks(9861),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 149, DateTimeKind.Utc).AddTicks(4855),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 149, DateTimeKind.Utc).AddTicks(3005),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 153, DateTimeKind.Utc).AddTicks(153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 152, DateTimeKind.Utc).AddTicks(9861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 149, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 9, 20, 16, 53, 149, DateTimeKind.Utc).AddTicks(3005));
        }
    }
}
