﻿// <auto-generated />
using JuniorTest.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JuniorTest.Domain.Migrations
{
    [DbContext(typeof(TestDBContext))]
    [Migration("20230222182744_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JuniorTest.Domain.DomainModels.ProductionFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Square")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Facilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "testName1",
                            Square = 450
                        },
                        new
                        {
                            Id = 2,
                            Name = "testName2",
                            Square = 600
                        },
                        new
                        {
                            Id = 3,
                            Name = "testName3",
                            Square = 350
                        },
                        new
                        {
                            Id = 4,
                            Name = "testName4",
                            Square = 200
                        });
                });

            modelBuilder.Entity("JuniorTest.Domain.DomainModels.TechnologicalEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Square")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "testName1",
                            Square = 50
                        },
                        new
                        {
                            Id = 2,
                            Name = "testName2",
                            Square = 90
                        },
                        new
                        {
                            Id = 3,
                            Name = "testName3",
                            Square = 120
                        },
                        new
                        {
                            Id = 4,
                            Name = "testName4",
                            Square = 75
                        });
                });

            modelBuilder.Entity("JuniorTest.Domain.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EquipmentCount")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("JuniorTest.Domain.Models.Contract", b =>
                {
                    b.HasOne("JuniorTest.Domain.DomainModels.TechnologicalEquipment", "Equipment")
                        .WithMany("Contracts")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorTest.Domain.DomainModels.ProductionFacility", "Facility")
                        .WithMany("Contracts")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("JuniorTest.Domain.DomainModels.ProductionFacility", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("JuniorTest.Domain.DomainModels.TechnologicalEquipment", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
