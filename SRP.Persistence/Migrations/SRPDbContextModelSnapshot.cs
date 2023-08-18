﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRP.Persistence;

#nullable disable

namespace SRP.Persistence.Migrations
{
    [DbContext(typeof(SRPDbContext))]
    partial class SRPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SRP.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Building")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SlotIndex")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SyncTS")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Address", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce0c97b0-961e-4179-bb66-9113b5ad4716"),
                            AddressTypeId = new Guid("2e5262ec-b18a-47c5-bafd-1bbf4b5d10fe"),
                            BeginDate = new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(4922),
                            Building = "Dombea Block",
                            City = "Johannesburg",
                            CountryId = new Guid("94fc7c1d-15bf-4238-9616-46675beafab2"),
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Floor = "1st Floor",
                            LocationId = new Guid("586bf713-a7f9-4ef1-aff7-bb93499c9b49"),
                            PostalCode = "1684",
                            ProvinceId = new Guid("1da1d26d-8d64-4535-8767-dc41d85f9a6c"),
                            SlotIndex = 1,
                            Street = "Unit 155",
                            SyncTS = 638271070333474931L
                        },
                        new
                        {
                            Id = new Guid("6d37efa3-c94e-4ac3-9ad7-8367a5bb370f"),
                            AddressTypeId = new Guid("6dc8d3ea-660b-4b4e-825e-cfa1a098077d"),
                            BeginDate = new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(4937),
                            City = "Johannesburg",
                            CountryId = new Guid("94fc7c1d-15bf-4238-9616-46675beafab2"),
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("061f9a0e-de82-489d-8c58-d5d7523dbd98"),
                            PostalCode = "2196",
                            ProvinceId = new Guid("1da1d26d-8d64-4535-8767-dc41d85f9a6c"),
                            SlotIndex = 1,
                            Street = "129 Rivonia Road",
                            SyncTS = 638271070333474938L
                        });
                });

            modelBuilder.Entity("SRP.Domain.Entities.AddressType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SyncTS")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("AddressType", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("16a4335e-9504-4e54-9673-3b2a438ad349"),
                            BeginDate = new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(5910),
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Physical",
                            SyncTS = 638271070333475911L
                        },
                        new
                        {
                            Id = new Guid("ffdbd18c-ce41-4e00-b9fb-313761c3effa"),
                            BeginDate = new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(5914),
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Postal",
                            SyncTS = 638271070333475914L
                        },
                        new
                        {
                            Id = new Guid("d0021e61-acec-4a5c-b947-a34f060632e3"),
                            BeginDate = new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(5923),
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Domicilium",
                            SyncTS = 638271070333475924L
                        });
                });

            modelBuilder.Entity("SRP.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SyncTS")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Country", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("SRP.Domain.Entities.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SyncTS")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Province", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("SRP.Domain.Entities.Address", b =>
                {
                    b.HasOne("SRP.Domain.Entities.AddressType", "AddressType")
                        .WithMany("Addresses")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressType");
                });

            modelBuilder.Entity("SRP.Domain.Entities.AddressType", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
