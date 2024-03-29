﻿// <auto-generated />
using System;
using ApiTemplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiTemplate.Infrastructure.Migrations
{
    [DbContext(typeof(ApiTemplateDbContext))]
    [Migration("20240124210737_AddAuth3")]
    partial class AddAuth3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ApiTemplate")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiTemplate.Domain.Users.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(3677))
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 373, DateTimeKind.Utc).AddTicks(4086))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Permission", "ApiTemplate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cad544a4-2156-4fc3-b653-636d7e0ba92d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Get",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("76d8b0d4-cbf5-4255-8fde-8fb573ead3bc"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Set",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6023))
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 374, DateTimeKind.Utc).AddTicks(6369))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Policy", "ApiTemplate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a53dba88-538b-4962-bd43-9d91cde2e2a6"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "SelfOrAdmin",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(4797))
                        .HasColumnOrder(102);

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnOrder(101);

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 375, DateTimeKind.Utc).AddTicks(6739))
                        .HasColumnOrder(104);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnOrder(103);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4684))
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(4957))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("Role", "ApiTemplate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eef1c2da-457f-4781-9dcd-8c04b027d2f5"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7228))
                        .HasColumnOrder(102);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 381, DateTimeKind.Utc).AddTicks(7620))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("User", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.UserPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(5658))
                        .HasColumnOrder(102);

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 382, DateTimeKind.Utc).AddTicks(6151))
                        .HasColumnOrder(104);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermission", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.UserPolicy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2346))
                        .HasColumnOrder(102);

                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 384, DateTimeKind.Utc).AddTicks(2689))
                        .HasColumnOrder(104);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "PolicyId");

                    b.HasIndex("PolicyId");

                    b.ToTable("UserPolicy", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9144))
                        .HasColumnOrder(102);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 7, 37, 385, DateTimeKind.Utc).AddTicks(9493))
                        .HasColumnOrder(104);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.RefreshToken", b =>
                {
                    b.HasOne("ApiTemplate.Domain.Users.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiTemplate.Domain.Users.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiTemplate.Domain.Users.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.UserPermission", b =>
                {
                    b.HasOne("ApiTemplate.Domain.Users.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTemplate.Domain.Users.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.UserPolicy", b =>
                {
                    b.HasOne("ApiTemplate.Domain.Users.Policy", "Policy")
                        .WithMany("UserPolicies")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTemplate.Domain.Users.User", "User")
                        .WithMany("UserPolicies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.UserRole", b =>
                {
                    b.HasOne("ApiTemplate.Domain.Users.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTemplate.Domain.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.Permission", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.Policy", b =>
                {
                    b.Navigation("UserPolicies");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserPermissions");

                    b.Navigation("UserPolicies");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
