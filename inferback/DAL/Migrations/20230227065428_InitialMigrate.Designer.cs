﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inferback.DAL;

#nullable disable

namespace inferback.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230227065428_InitialMigrate")]
    partial class InitialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("inferback.Domain.Entity.Description", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bug_type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "bug_type");

                    b.Property<string>("bug_type_hum")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "bug_type_hum");

                    b.Property<int>("column")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "column");

                    b.Property<string>("file")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "file");

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "hash");

                    b.Property<string>("key")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "key");

                    b.Property<int>("line")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "line");

                    b.Property<string>("node_key")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "node_key");

                    b.Property<string>("procedure")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "procedure");

                    b.Property<int>("procedure_start_line")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "procedure_start_line");

                    b.Property<string>("qualifier")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "qualifier");

                    b.Property<string>("severity")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "severity");

                    b.HasKey("id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("inferback.Domain.Entity.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("path")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("inferback.Domain.Entity.Report", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("descriptionId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("descriptionId");

                    b.HasIndex("projectId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("inferback.Domain.Entity.Report", b =>
                {
                    b.HasOne("inferback.Domain.Entity.Description", "description")
                        .WithMany("reports")
                        .HasForeignKey("descriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("inferback.Domain.Entity.Project", "project")
                        .WithMany("reports")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("description");

                    b.Navigation("project");
                });

            modelBuilder.Entity("inferback.Domain.Entity.Description", b =>
                {
                    b.Navigation("reports");
                });

            modelBuilder.Entity("inferback.Domain.Entity.Project", b =>
                {
                    b.Navigation("reports");
                });
#pragma warning restore 612, 618
        }
    }
}
