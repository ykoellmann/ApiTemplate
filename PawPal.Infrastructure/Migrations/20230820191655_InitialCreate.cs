using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawPal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PawPal");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageSourceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_ImageSourceId_ImageSourceTypeId", x => new { x.ImageSourceId, x.ImageSourceTypeId });
                });

            migrationBuilder.CreateTable(
                name: "ImageSourceType",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ImageSource = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSourceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageSourceType_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageSourceType_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreferenceSourceType",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PreferenceSource = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceSourceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferenceSourceType_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreferenceSourceType_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shelter",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    City = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ImageSourceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                    table.UniqueConstraint("AK_Shelter_ImageSourceId_ImageSourceTypeId", x => new { x.ImageSourceId, x.ImageSourceTypeId });
                    table.ForeignKey(
                        name: "FK_Shelter_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shelter_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Species",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    PreferenceSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.UniqueConstraint("AK_Species_PreferenceSourceId", x => x.PreferenceSourceId);
                    table.ForeignKey(
                        name: "FK_Species_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Species_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpeciesBreed",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PreferenceSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesBreed", x => x.Id);
                    table.UniqueConstraint("AK_SpeciesBreed_PreferenceSourceId", x => x.PreferenceSourceId);
                    table.ForeignKey(
                        name: "FK_SpeciesBreed_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalSchema: "PawPal",
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesBreed_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpeciesBreed_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreferenceSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreferenceSourceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false),
                    SpeciesBreedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preference_PreferenceSourceType_PreferenceSourceTypeId",
                        column: x => x.PreferenceSourceTypeId,
                        principalSchema: "PawPal",
                        principalTable: "PreferenceSourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preference_SpeciesBreed_SpeciesBreedId",
                        column: x => x.SpeciesBreedId,
                        principalSchema: "PawPal",
                        principalTable: "SpeciesBreed",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Preference_Species_PreferenceSourceId",
                        column: x => x.PreferenceSourceId,
                        principalSchema: "PawPal",
                        principalTable: "Species",
                        principalColumn: "PreferenceSourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preference_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Preference_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Preference_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterAdvertisement",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SpeciesBreedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageSourceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterAdvertisement", x => x.Id);
                    table.UniqueConstraint("AK_ShelterAdvertisement_ImageSourceId_ImageSourceTypeId", x => new { x.ImageSourceId, x.ImageSourceTypeId });
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisement_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "PawPal",
                        principalTable: "Shelter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisement_SpeciesBreed_SpeciesBreedId",
                        column: x => x.SpeciesBreedId,
                        principalSchema: "PawPal",
                        principalTable: "SpeciesBreed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisement_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShelterAdvertisement_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShelterAdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_ShelterAdvertisement_ShelterAdvertisementId",
                        column: x => x.ShelterAdvertisementId,
                        principalSchema: "PawPal",
                        principalTable: "ShelterAdvertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "PawPal",
                        principalTable: "Shelter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chat_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chat_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chat_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageSourceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShelterAdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShelterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => new { x.Id, x.ImageSourceTypeId });
                    table.ForeignKey(
                        name: "FK_Image_ImageSourceType_ImageSourceTypeId",
                        column: x => x.ImageSourceTypeId,
                        principalSchema: "PawPal",
                        principalTable: "ImageSourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_ShelterAdvertisement_ShelterAdvertisementId",
                        column: x => x.ShelterAdvertisementId,
                        principalSchema: "PawPal",
                        principalTable: "ShelterAdvertisement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalSchema: "PawPal",
                        principalTable: "Shelter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_User_ImageSourceId_ImageSourceTypeId",
                        columns: x => new { x.ImageSourceId, x.ImageSourceTypeId },
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumns: new[] { "ImageSourceId", "ImageSourceTypeId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShelterAdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_ShelterAdvertisement_ShelterAdvertisementId",
                        column: x => x.ShelterAdvertisementId,
                        principalSchema: "PawPal",
                        principalTable: "ShelterAdvertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                schema: "PawPal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Sender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_Chat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "PawPal",
                        principalTable: "Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatMessage_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "PawPal",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_CreatedBy",
                schema: "PawPal",
                table: "Chat",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ShelterAdvertisementId",
                schema: "PawPal",
                table: "Chat",
                column: "ShelterAdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ShelterId",
                schema: "PawPal",
                table: "Chat",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UpdatedBy",
                schema: "PawPal",
                table: "Chat",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UserId",
                schema: "PawPal",
                table: "Chat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_ChatId",
                schema: "PawPal",
                table: "ChatMessage",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_CreatedBy",
                schema: "PawPal",
                table: "ChatMessage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UpdatedBy",
                schema: "PawPal",
                table: "ChatMessage",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedBy",
                schema: "PawPal",
                table: "Image",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageSourceId_ImageSourceTypeId",
                schema: "PawPal",
                table: "Image",
                columns: new[] { "ImageSourceId", "ImageSourceTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageSourceTypeId",
                schema: "PawPal",
                table: "Image",
                column: "ImageSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ShelterAdvertisementId",
                schema: "PawPal",
                table: "Image",
                column: "ShelterAdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ShelterId",
                schema: "PawPal",
                table: "Image",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UpdatedBy",
                schema: "PawPal",
                table: "Image",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSourceType_CreatedBy",
                schema: "PawPal",
                table: "ImageSourceType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSourceType_UpdatedBy",
                schema: "PawPal",
                table: "ImageSourceType",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Like_CreatedBy",
                schema: "PawPal",
                table: "Like",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Like_ShelterAdvertisementId",
                schema: "PawPal",
                table: "Like",
                column: "ShelterAdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UpdatedBy",
                schema: "PawPal",
                table: "Like",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                schema: "PawPal",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_CreatedBy",
                schema: "PawPal",
                table: "Preference",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_PreferenceSourceId",
                schema: "PawPal",
                table: "Preference",
                column: "PreferenceSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_PreferenceSourceTypeId",
                schema: "PawPal",
                table: "Preference",
                column: "PreferenceSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_SpeciesBreedId",
                schema: "PawPal",
                table: "Preference",
                column: "SpeciesBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_UpdatedBy",
                schema: "PawPal",
                table: "Preference",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_UserId",
                schema: "PawPal",
                table: "Preference",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceSourceType_CreatedBy",
                schema: "PawPal",
                table: "PreferenceSourceType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceSourceType_UpdatedBy",
                schema: "PawPal",
                table: "PreferenceSourceType",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_CreatedBy",
                schema: "PawPal",
                table: "Shelter",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_UpdatedBy",
                schema: "PawPal",
                table: "Shelter",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisement_CreatedBy",
                schema: "PawPal",
                table: "ShelterAdvertisement",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisement_ShelterId",
                schema: "PawPal",
                table: "ShelterAdvertisement",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisement_SpeciesBreedId",
                schema: "PawPal",
                table: "ShelterAdvertisement",
                column: "SpeciesBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdvertisement_UpdatedBy",
                schema: "PawPal",
                table: "ShelterAdvertisement",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Species_CreatedBy",
                schema: "PawPal",
                table: "Species",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Species_UpdatedBy",
                schema: "PawPal",
                table: "Species",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesBreed_CreatedBy",
                schema: "PawPal",
                table: "SpeciesBreed",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesBreed_SpeciesId",
                schema: "PawPal",
                table: "SpeciesBreed",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesBreed_UpdatedBy",
                schema: "PawPal",
                table: "SpeciesBreed",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "Like",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "Preference",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "Chat",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "ImageSourceType",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "PreferenceSourceType",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "ShelterAdvertisement",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "Shelter",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "SpeciesBreed",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "Species",
                schema: "PawPal");

            migrationBuilder.DropTable(
                name: "User",
                schema: "PawPal");
        }
    }
}
