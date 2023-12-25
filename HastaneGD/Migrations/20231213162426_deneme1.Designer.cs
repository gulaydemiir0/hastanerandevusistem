﻿// <auto-generated />
using HastaneGD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneGD.Migrations
{
    [DbContext(typeof(HContext))]
    [Migration("20231213162426_deneme1")]
    partial class deneme1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HastaneGD.Models.AnaBilimDali", b =>
                {
                    b.Property<int>("abdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("abdId"), 1L, 1);

                    b.Property<string>("abdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("abdId");

                    b.ToTable("anaBilimDalis");
                });

            modelBuilder.Entity("HastaneGD.Models.Doktor", b =>
                {
                    b.Property<int>("doktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("doktorId"), 1L, 1);

                    b.Property<int>("AnaBilimDaliabdId")
                        .HasColumnType("int");

                    b.Property<int>("PoliklinikpolId")
                        .HasColumnType("int");

                    b.Property<int>("abdID")
                        .HasColumnType("int");

                    b.Property<string>("doktorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("polId")
                        .HasColumnType("int");

                    b.HasKey("doktorId");

                    b.HasIndex("AnaBilimDaliabdId");

                    b.HasIndex("PoliklinikpolId");

                    b.ToTable("doktors");
                });

            modelBuilder.Entity("HastaneGD.Models.Poliklinik", b =>
                {
                    b.Property<int>("polId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("polId"), 1L, 1);

                    b.Property<string>("polName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("polId");

                    b.ToTable("polikliniks");
                });

            modelBuilder.Entity("HastaneGD.Models.Doktor", b =>
                {
                    b.HasOne("HastaneGD.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Doktors")
                        .HasForeignKey("AnaBilimDaliabdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneGD.Models.Poliklinik", "Poliklinik")
                        .WithMany("doktors")
                        .HasForeignKey("PoliklinikpolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");

                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("HastaneGD.Models.AnaBilimDali", b =>
                {
                    b.Navigation("Doktors");
                });

            modelBuilder.Entity("HastaneGD.Models.Poliklinik", b =>
                {
                    b.Navigation("doktors");
                });
#pragma warning restore 612, 618
        }
    }
}
