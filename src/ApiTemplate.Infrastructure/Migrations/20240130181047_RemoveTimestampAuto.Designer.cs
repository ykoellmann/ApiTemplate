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
    [Migration("20240130181047_RemoveTimestampAuto")]
    partial class RemoveTimestampAuto
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
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(102);

                    b.Property<string>("Feature")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.HasIndex("Feature", "Name")
                        .IsUnique();

                    b.ToTable("Permission", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Policy", "ApiTemplate");
                });

            modelBuilder.Entity("ApiTemplate.Domain.Users.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
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
                        .HasColumnType("timestamp with time zone")
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
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(102);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(104);

                    b.HasKey("Id");

                    b.ToTable("Role", "ApiTemplate");
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
                        .HasColumnType("timestamp with time zone")
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
                        .HasColumnType("timestamp with time zone")
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
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(102);

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
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
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(102);

                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
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
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(102);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
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