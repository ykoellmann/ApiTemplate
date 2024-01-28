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
    [Migration("20240124210337_AddAuth")]
    partial class AddAuth
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 748, DateTimeKind.Utc).AddTicks(9952))
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 749, DateTimeKind.Utc).AddTicks(385))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("Permission", "ApiTemplate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b4d43f1e-16da-4c33-9a1d-115479c3c77b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Get",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("85691f11-36f8-4a88-8994-99b422d6f3af"),
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1107))
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(1524))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("Policy", "ApiTemplate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b84a43f6-413e-41d9-851e-831ad0cd5f4a"),
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 750, DateTimeKind.Utc).AddTicks(9337))
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 751, DateTimeKind.Utc).AddTicks(1220))
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2149))
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(2608))
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("Role", "ApiTemplate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("839b7836-cc23-4a4d-9711-28fca2bf1524"),
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(5626))
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 757, DateTimeKind.Utc).AddTicks(6030))
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5175))
                        .HasColumnOrder(102);

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 758, DateTimeKind.Utc).AddTicks(5601))
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(1886))
                        .HasColumnOrder(102);

                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 760, DateTimeKind.Utc).AddTicks(2486))
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
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(7968))
                        .HasColumnOrder(102);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 1, 24, 21, 3, 37, 761, DateTimeKind.Utc).AddTicks(8439))
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