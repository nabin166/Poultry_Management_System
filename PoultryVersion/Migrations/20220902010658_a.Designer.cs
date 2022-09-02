﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoultryVersion.Models;

#nullable disable

namespace PoultryVersion.Migrations
{
    [DbContext(typeof(PoultryUpdatedContext))]
    [Migration("20220902010658_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PoultryVersion.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Roles")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblDisease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Date")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DiseaseName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("EffectiveNumber")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfDead")
                        .HasColumnType("int");

                    b.Property<int?>("PoultryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoultryId");

                    b.ToTable("tblDisease", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblPoultryFarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("NoOfHens")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblPoultryFarm", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblProduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EggType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PoultryId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoultryId");

                    b.ToTable("tblProduction", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblTreatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CheckedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Date")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<string>("Medicine")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("tblTreatment", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tblUser", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblVaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Date")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PoultryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoultryId");

                    b.ToTable("tblVaccine", (string)null);
                });

            modelBuilder.Entity("PoultryVersion.Models.TblDisease", b =>
                {
                    b.HasOne("PoultryVersion.Models.TblPoultryFarm", "Poultry")
                        .WithMany("TblDiseases")
                        .HasForeignKey("PoultryId")
                        .HasConstraintName("FK_tblDisease_tblPoultryFarm");

                    b.Navigation("Poultry");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblPoultryFarm", b =>
                {
                    b.HasOne("PoultryVersion.Models.TblUser", "User")
                        .WithMany("TblPoultryFarms")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_tblPoultryFarm_tblUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblProduction", b =>
                {
                    b.HasOne("PoultryVersion.Models.TblPoultryFarm", "Poultry")
                        .WithMany("TblProductions")
                        .HasForeignKey("PoultryId")
                        .HasConstraintName("FK_tblProduction_tblPoultryFarm");

                    b.Navigation("Poultry");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblTreatment", b =>
                {
                    b.HasOne("PoultryVersion.Models.TblDisease", "Disease")
                        .WithMany("TblTreatments")
                        .HasForeignKey("DiseaseId")
                        .HasConstraintName("FK_tblTreatment_tblDisease");

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblUser", b =>
                {
                    b.HasOne("PoultryVersion.Models.Role", "Role")
                        .WithMany("TblUsers")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_tblUser_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblVaccine", b =>
                {
                    b.HasOne("PoultryVersion.Models.TblPoultryFarm", "Poultry")
                        .WithMany("TblVaccines")
                        .HasForeignKey("PoultryId")
                        .HasConstraintName("FK_tblVaccine_tblPoultryFarm");

                    b.Navigation("Poultry");
                });

            modelBuilder.Entity("PoultryVersion.Models.Role", b =>
                {
                    b.Navigation("TblUsers");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblDisease", b =>
                {
                    b.Navigation("TblTreatments");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblPoultryFarm", b =>
                {
                    b.Navigation("TblDiseases");

                    b.Navigation("TblProductions");

                    b.Navigation("TblVaccines");
                });

            modelBuilder.Entity("PoultryVersion.Models.TblUser", b =>
                {
                    b.Navigation("TblPoultryFarms");
                });
#pragma warning restore 612, 618
        }
    }
}
