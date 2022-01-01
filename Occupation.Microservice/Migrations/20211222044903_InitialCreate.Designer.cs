﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OccupationMicroservice.DBContext;

namespace OccupationMicroservice.Migrations
{
    [DbContext(typeof(OccupationContext))]
    [Migration("20211222044903_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PremiumMicroservice.Models.Occupation", b =>
                {
                    b.Property<int>("OccupationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("OccupationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OccupationRatingId")
                        .HasColumnType("int");

                    b.HasKey("OccupationId");

                    b.ToTable("Occupations");

                    b.HasData(
                        new
                        {
                            OccupationId = 1,
                            OccupationName = "Cleaner",
                            OccupationRatingId = 3
                        },
                        new
                        {
                            OccupationId = 2,
                            OccupationName = "Doctor",
                            OccupationRatingId = 1
                        },
                        new
                        {
                            OccupationId = 3,
                            OccupationName = "Author",
                            OccupationRatingId = 2
                        },
                        new
                        {
                            OccupationId = 4,
                            OccupationName = "Farmer",
                            OccupationRatingId = 4
                        },
                        new
                        {
                            OccupationId = 5,
                            OccupationName = "Mechanic",
                            OccupationRatingId = 4
                        },
                        new
                        {
                            OccupationId = 6,
                            OccupationName = "Florist",
                            OccupationRatingId = 3
                        });
                });

            modelBuilder.Entity("PremiumMicroservice.Models.OccupationRating", b =>
                {
                    b.Property<int>("OccupationRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Factor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OccupationRatingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OccupationRatingId");

                    b.ToTable("OccupationRatings");

                    b.HasData(
                        new
                        {
                            OccupationRatingId = 1,
                            Factor = 1.00m,
                            OccupationRatingName = "Professional"
                        },
                        new
                        {
                            OccupationRatingId = 2,
                            Factor = 1.25m,
                            OccupationRatingName = "White Collar"
                        },
                        new
                        {
                            OccupationRatingId = 3,
                            Factor = 1.50m,
                            OccupationRatingName = "Light Manual"
                        },
                        new
                        {
                            OccupationRatingId = 4,
                            Factor = 1.75m,
                            OccupationRatingName = "Heavy Manual"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
