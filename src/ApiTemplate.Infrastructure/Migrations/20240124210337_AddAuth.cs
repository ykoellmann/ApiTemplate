using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_CreatedBy",
                schema: "ApiTemplate",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UpdatedBy",
                schema: "ApiTemplate",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "ApiTemplate",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "ApiTemplate",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "ApiTemplate",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "ApiTemplate",
                newName: "User",
                newSchema: "ApiTemplate");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                schema: "ApiTemplate",
                newName: "RefreshToken",
                newSchema: "ApiTemplate");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "ApiTemplate",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UpdatedBy",
                schema: "ApiTemplate",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_CreatedBy",
                schema: "ApiTemplate",
                table: "RefreshToken",
                newName: "IX_RefreshToken_CreatedBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(6030),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 612, DateTimeKind.Utc).AddTicks(5861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(5626),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 612, DateTimeKind.Utc).AddTicks(5559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 751, DateTimeKind.Utc).AddTicks(1220),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 608, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(9337),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 608, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "ApiTemplate",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                schema: "ApiTemplate",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "ApiTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 748, DateTimeKind.Utc).AddTicks(9952)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 749, DateTimeKind.Utc).AddTicks(385)),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                schema: "ApiTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1107)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1524)),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "ApiTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2149)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2608)),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                schema: "ApiTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5175)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5601)),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.Id);
                    table.UniqueConstraint("AK_UserPermission_UserId_PermissionId", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "ApiTemplate",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ApiTemplate",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPolicy",
                schema: "ApiTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(1886)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(2486)),
                    PolicyId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPolicy", x => x.Id);
                    table.UniqueConstraint("AK_UserPolicy_UserId_PolicyId", x => new { x.UserId, x.PolicyId });
                    table.ForeignKey(
                        name: "FK_UserPolicy_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalSchema: "ApiTemplate",
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPolicy_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ApiTemplate",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "ApiTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(7968)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(8439)),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.UniqueConstraint("AK_UserRole_UserId_RoleId", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ApiTemplate",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "ApiTemplate",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId",
                schema: "ApiTemplate",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPolicy_PolicyId",
                schema: "ApiTemplate",
                table: "UserPolicy",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "ApiTemplate",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_CreatedBy",
                schema: "ApiTemplate",
                table: "RefreshToken",
                column: "CreatedBy",
                principalSchema: "ApiTemplate",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UpdatedBy",
                schema: "ApiTemplate",
                table: "RefreshToken",
                column: "UpdatedBy",
                principalSchema: "ApiTemplate",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                schema: "ApiTemplate",
                table: "RefreshToken",
                column: "UserId",
                principalSchema: "ApiTemplate",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_CreatedBy",
                schema: "ApiTemplate",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UpdatedBy",
                schema: "ApiTemplate",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                schema: "ApiTemplate",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "ApiTemplate");

            migrationBuilder.DropTable(
                name: "UserPolicy",
                schema: "ApiTemplate");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "ApiTemplate");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "ApiTemplate");

            migrationBuilder.DropTable(
                name: "Policy",
                schema: "ApiTemplate");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "ApiTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "ApiTemplate",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                schema: "ApiTemplate",
                table: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "ApiTemplate",
                newName: "Users",
                newSchema: "ApiTemplate");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                schema: "ApiTemplate",
                newName: "RefreshTokens",
                newSchema: "ApiTemplate");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UpdatedBy",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_CreatedBy",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_CreatedBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 612, DateTimeKind.Utc).AddTicks(5861),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 612, DateTimeKind.Utc).AddTicks(5559),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 608, DateTimeKind.Utc).AddTicks(9010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 751, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 10, 10, 47, 5, 608, DateTimeKind.Utc).AddTicks(7012),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "ApiTemplate",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_CreatedBy",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                column: "CreatedBy",
                principalSchema: "ApiTemplate",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UpdatedBy",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                column: "UpdatedBy",
                principalSchema: "ApiTemplate",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "ApiTemplate",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "ApiTemplate",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
