﻿// <auto-generated />
using HastaneGD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneGD.Migrations
{
    [DbContext(typeof(HContext))]
    partial class HContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("HastaneGD.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("polName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("doctors");
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
#pragma warning restore 612, 618
        }
    }
}
