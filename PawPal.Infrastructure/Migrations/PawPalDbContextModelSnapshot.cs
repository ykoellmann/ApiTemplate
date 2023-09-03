﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawPal.Infrastructure.Persistence;

#nullable disable

namespace PawPal.Infrastructure.Migrations
{
    [DbContext(typeof(PawPalDbContext))]
    partial class PawPalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("PawPal")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PawPal.Domain.Chat.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<Guid>("ShelterAdvertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ShelterAdvertisementId");

                    b.HasIndex("ShelterId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Chat", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Chat.Entities.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("Sender")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("ChatMessage", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Image.Entities.ImageSourceType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<int>("ImageSource")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("ImageSourceType", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Image.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("ImageSourceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ContentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<Guid>("ImageSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShelterAdvertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShelterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id", "ImageSourceTypeId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ImageSourceTypeId");

                    b.HasIndex("ShelterAdvertisementId");

                    b.HasIndex("ShelterId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("ImageSourceId", "ImageSourceTypeId");

                    b.ToTable("Image", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Like.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<bool>("IsLiked")
                        .HasColumnType("bit");

                    b.Property<Guid>("ShelterAdvertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ShelterAdvertisementId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Like", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Preference.Entities.PreferenceSourceType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("PreferenceSource")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("PreferenceSourceType", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Preference.Preference", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<bool>("IsLiked")
                        .HasColumnType("bit");

                    b.Property<Guid>("PreferenceSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PreferenceSourceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SpeciesBreedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PreferenceSourceId");

                    b.HasIndex("PreferenceSourceTypeId");

                    b.HasIndex("SpeciesBreedId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Preference", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Shelter.Entities.ShelterAdvertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<Guid>("ImageSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageSourceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid>("ShelterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpeciesBreedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id");

                    b.HasAlternateKey("ImageSourceId", "ImageSourceTypeId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ShelterId");

                    b.HasIndex("SpeciesBreedId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("ShelterAdvertisement", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Shelter.Shelter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("ImageSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageSourceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.Property<string>("Website")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasAlternateKey("ImageSourceId", "ImageSourceTypeId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Shelter", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Species.Entities.SpeciesBreed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("PreferenceSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpeciesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id");

                    b.HasAlternateKey("PreferenceSourceId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("SpeciesBreed", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Species.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(101);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid>("PreferenceSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(103);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Species", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(102);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("ImageSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageSourceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("User", "PawPal");
                });

            modelBuilder.Entity("PawPal.Domain.Chat.Chat", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Shelter.Entities.ShelterAdvertisement", "ShelterAdvertisement")
                        .WithMany("Chats")
                        .HasForeignKey("ShelterAdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Shelter.Shelter", null)
                        .WithMany("Chats")
                        .HasForeignKey("ShelterId");

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("ShelterAdvertisement");

                    b.Navigation("UpdatedByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawPal.Domain.Chat.Entities.ChatMessage", b =>
                {
                    b.HasOne("PawPal.Domain.Chat.Chat", "Chat")
                        .WithMany("ChatMessages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Image.Entities.ImageSourceType", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Image.Image", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Image.Entities.ImageSourceType", "ImageSourceType")
                        .WithMany("Images")
                        .HasForeignKey("ImageSourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Shelter.Entities.ShelterAdvertisement", null)
                        .WithMany("Images")
                        .HasForeignKey("ShelterAdvertisementId");

                    b.HasOne("PawPal.Domain.Shelter.Shelter", null)
                        .WithMany("Images")
                        .HasForeignKey("ShelterId");

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "Source")
                        .WithMany("Images")
                        .HasForeignKey("ImageSourceId", "ImageSourceTypeId")
                        .HasPrincipalKey("ImageSourceId", "ImageSourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("ImageSourceType");

                    b.Navigation("Source");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Like.Like", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Shelter.Entities.ShelterAdvertisement", "ShelterAdvertisement")
                        .WithMany("Likes")
                        .HasForeignKey("ShelterAdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("ShelterAdvertisement");

                    b.Navigation("UpdatedByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawPal.Domain.Preference.Entities.PreferenceSourceType", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Preference.Preference", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Species.Species", "Source")
                        .WithMany("Preferences")
                        .HasForeignKey("PreferenceSourceId")
                        .HasPrincipalKey("PreferenceSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Preference.Entities.PreferenceSourceType", "PreferenceSourceType")
                        .WithMany("Preferences")
                        .HasForeignKey("PreferenceSourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Species.Entities.SpeciesBreed", null)
                        .WithMany("Preferences")
                        .HasForeignKey("SpeciesBreedId");

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "User")
                        .WithMany("Preferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("PreferenceSourceType");

                    b.Navigation("Source");

                    b.Navigation("UpdatedByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawPal.Domain.Shelter.Entities.ShelterAdvertisement", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Shelter.Shelter", "Shelter")
                        .WithMany("Advertisements")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Species.Entities.SpeciesBreed", "SpeciesBreed")
                        .WithMany("ShelterAdvertisements")
                        .HasForeignKey("SpeciesBreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Shelter");

                    b.Navigation("SpeciesBreed");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Shelter.Shelter", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Species.Entities.SpeciesBreed", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.Species.Species", "Species")
                        .WithMany("Breeds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Species");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Species.Species", b =>
                {
                    b.HasOne("PawPal.Domain.User.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawPal.Domain.User.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("PawPal.Domain.Chat.Chat", b =>
                {
                    b.Navigation("ChatMessages");
                });

            modelBuilder.Entity("PawPal.Domain.Image.Entities.ImageSourceType", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("PawPal.Domain.Preference.Entities.PreferenceSourceType", b =>
                {
                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("PawPal.Domain.Shelter.Entities.ShelterAdvertisement", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Images");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("PawPal.Domain.Shelter.Shelter", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Chats");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("PawPal.Domain.Species.Entities.SpeciesBreed", b =>
                {
                    b.Navigation("Preferences");

                    b.Navigation("ShelterAdvertisements");
                });

            modelBuilder.Entity("PawPal.Domain.Species.Species", b =>
                {
                    b.Navigation("Breeds");

                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("PawPal.Domain.User.User", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Images");

                    b.Navigation("Likes");

                    b.Navigation("Preferences");
                });
#pragma warning restore 612, 618
        }
    }
}
