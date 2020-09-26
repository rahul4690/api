﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data.Context;

namespace Repository.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200913131645_migration_v2")]
    partial class migration_v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Models.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("roleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("roleId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Repository.Models.Models.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ApplicationUserRoles");
                });

            modelBuilder.Entity("Repository.Models.Models.Category", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Repository.Models.Models.SubCategory", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("subCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Repository.Models.Models.ApplicationUser", b =>
                {
                    b.HasOne("Repository.Models.Models.ApplicationUserRole", "role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Models.Models.SubCategory", b =>
                {
                    b.HasOne("Repository.Models.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
