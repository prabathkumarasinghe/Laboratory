﻿// <auto-generated />
using System;
using Laboratory.Services.TestParameterAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Laboratory.Services.TestParameterAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Laboratory.Services.TestParameterAPI.Models.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ALP")
                        .HasColumnType("int");

                    b.Property<int?>("ALT")
                        .HasColumnType("int");

                    b.Property<int?>("AST")
                        .HasColumnType("int");

                    b.Property<int?>("Albumin")
                        .HasColumnType("int");

                    b.Property<int?>("CholHDLRatio")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Eosinophils")
                        .HasColumnType("int");

                    b.Property<int?>("GGT")
                        .HasColumnType("int");

                    b.Property<int?>("Globulin")
                        .HasColumnType("int");

                    b.Property<int?>("Glucose")
                        .HasColumnType("int");

                    b.Property<int?>("HCT")
                        .HasColumnType("int");

                    b.Property<int?>("HDL")
                        .HasColumnType("int");

                    b.Property<int?>("Hb")
                        .HasColumnType("int");

                    b.Property<int?>("LD")
                        .HasColumnType("int");

                    b.Property<int?>("LDL")
                        .HasColumnType("int");

                    b.Property<int?>("LabNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Lymphocytes")
                        .HasColumnType("int");

                    b.Property<int?>("MCH")
                        .HasColumnType("int");

                    b.Property<int?>("MCV")
                        .HasColumnType("int");

                    b.Property<int?>("MPV")
                        .HasColumnType("int");

                    b.Property<int?>("Neutrophils")
                        .HasColumnType("int");

                    b.Property<int?>("NonHDLChol")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlateletCount")
                        .HasColumnType("int");

                    b.Property<int?>("Potassium")
                        .HasColumnType("int");

                    b.Property<int?>("RBC")
                        .HasColumnType("int");

                    b.Property<int?>("RefNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Sodium")
                        .HasColumnType("int");

                    b.Property<int?>("TotalCholesterol")
                        .HasColumnType("int");

                    b.Property<int?>("TotalProtein")
                        .HasColumnType("int");

                    b.Property<int?>("Triglycerides")
                        .HasColumnType("int");

                    b.Property<int?>("WBC")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("parameters");
                });
#pragma warning restore 612, 618
        }
    }
}
