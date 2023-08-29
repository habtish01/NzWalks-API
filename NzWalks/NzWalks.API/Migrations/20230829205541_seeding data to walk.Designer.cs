﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NzWalks.API.Data;

#nullable disable

namespace NzWalks.API.Migrations
{
    [DbContext(typeof(NzWalksDbContext))]
    [Migration("20230829205541_seeding data to walk")]
    partial class seedingdatatowalk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NzWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("difficulty");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e28f4960-9de0-4116-a162-bb23540167f9"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("f0f60887-3722-46b7-9712-6080d50b643a"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NzWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("region");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7fff524e-6eb8-4d15-a00d-90057ef127a0"),
                            Code = "AM",
                            Name = "Amhara",
                            RegionImageUrl = "image.png"
                        },
                        new
                        {
                            Id = new Guid("1b283634-abe1-4710-b00c-9cd0a4d8b294"),
                            Code = "AJ",
                            Name = "AJerbaja",
                            RegionImageUrl = "image.png"
                        },
                        new
                        {
                            Id = new Guid("166702ef-0511-458b-a360-ce44344cc87a"),
                            Code = "BM",
                            Name = "Bagladish",
                            RegionImageUrl = "image.png"
                        },
                        new
                        {
                            Id = new Guid("c742ff73-bacb-46e9-ac30-51b1eae05746"),
                            Code = "DW",
                            Name = "Dirediwa",
                            RegionImageUrl = "image.png"
                        });
                });

            modelBuilder.Entity("NzWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("lengthInKm")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("walks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3e30540-dc77-4064-98f3-773b57bea500"),
                            Description = "I was going to dubai to make myself enjoy",
                            DifficultyId = new Guid("f0f60887-3722-46b7-9712-6080d50b643a"),
                            Name = "Going to dubai",
                            RegionId = new Guid("7fff524e-6eb8-4d15-a00d-90057ef127a0"),
                            WalkImageUrl = "Walk.png",
                            lengthInKm = 19090.0
                        },
                        new
                        {
                            Id = new Guid("12f84c68-121f-4394-a649-569b4321be10"),
                            Description = "I was going to dubai to make myself enjoy",
                            DifficultyId = new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"),
                            Name = "Going to Elias",
                            RegionId = new Guid("1b283634-abe1-4710-b00c-9cd0a4d8b294"),
                            WalkImageUrl = "Walk.png",
                            lengthInKm = 1.0
                        },
                        new
                        {
                            Id = new Guid("8e682712-2833-46d0-b705-1aa52ee39f20"),
                            Description = "I was going to dubai to make myself enjoy",
                            DifficultyId = new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"),
                            Name = "Going to Nework",
                            RegionId = new Guid("166702ef-0511-458b-a360-ce44344cc87a"),
                            WalkImageUrl = "Walk.png",
                            lengthInKm = 1.0
                        },
                        new
                        {
                            Id = new Guid("0f17ddd8-9ff3-4c3d-a019-c878e536ab1b"),
                            Description = "I was going to dubai to make myself enjoy",
                            DifficultyId = new Guid("e28f4960-9de0-4116-a162-bb23540167f9"),
                            Name = "Going to London",
                            RegionId = new Guid("c742ff73-bacb-46e9-ac30-51b1eae05746"),
                            WalkImageUrl = "Walk.png",
                            lengthInKm = 1.0
                        });
                });

            modelBuilder.Entity("NzWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NzWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NzWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
