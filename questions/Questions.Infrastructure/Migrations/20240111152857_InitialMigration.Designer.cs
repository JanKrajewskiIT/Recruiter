﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Questions.Infrastructure.Context;

#nullable disable

namespace Questions.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240111152857_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Questions.Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("IconName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Questions.Domain.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("Questions.Domain.Entities.CategoryEntity", b =>
                {
                    b.HasOne("Questions.Domain.Entities.CategoryEntity", null)
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Questions.Domain.Entities.QuestionEntity", b =>
                {
                    b.HasOne("Questions.Domain.Entities.CategoryEntity", null)
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Questions.Domain.Entities.CategoryEntity", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
