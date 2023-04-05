﻿// <auto-generated />
using Imperial_Metric.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Imperial_Metric.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230404210227_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Imperial_Metric.Domain.Entities.Conversions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("conversionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Conversions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            conversionName = "Length"
                        },
                        new
                        {
                            Id = 2,
                            conversionName = "Mass"
                        },
                        new
                        {
                            Id = 3,
                            conversionName = "Speed"
                        },
                        new
                        {
                            Id = 4,
                            conversionName = "Temperature"
                        },
                        new
                        {
                            Id = 5,
                            conversionName = "Pressure"
                        },
                        new
                        {
                            Id = 6,
                            conversionName = "Volume"
                        });
                });

            modelBuilder.Entity("Imperial_Metric.Domain.Entities.ConversionsRates", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("ConversionFactor")
                        .HasColumnType("double precision");

                    b.Property<int>("ConversionId")
                        .HasColumnType("integer");

                    b.Property<double>("ConversionOffset")
                        .HasColumnType("double precision");

                    b.Property<string>("FromUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ToUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConversionId");

                    b.ToTable("ConversionsRates");

                    b.HasData(
                        new
                        {
                            Id = "c9ae47f1-1c7e-4807-8604-e669bf288f59",
                            ConversionFactor = 1.8,
                            ConversionId = 4,
                            ConversionOffset = 32.0,
                            FromUnit = "Celsius",
                            Name = "Celsius to Fahrenheit",
                            ToUnit = "Fahrenheit"
                        },
                        new
                        {
                            Id = "e63e9a1e-8c76-469a-bc9b-481cd30604be",
                            ConversionFactor = 0.55555555560000003,
                            ConversionId = 4,
                            ConversionOffset = -32.0,
                            FromUnit = "Fahrenheit",
                            Name = "Fahrenheit to Celsius",
                            ToUnit = "Celsius"
                        },
                        new
                        {
                            Id = "5d4d83d5-baea-4d38-bd5b-b315b99ff487",
                            ConversionFactor = 3.2808398950000002,
                            ConversionId = 1,
                            ConversionOffset = 0.0,
                            FromUnit = "Meters",
                            Name = "Meters to Feet",
                            ToUnit = "Feet"
                        },
                        new
                        {
                            Id = "7abdf623-4995-44a2-abd2-3fcb51dbb303",
                            ConversionFactor = 1.09361,
                            ConversionId = 1,
                            ConversionOffset = 0.0,
                            FromUnit = "Meters",
                            Name = "Meters to Yard",
                            ToUnit = "Yard"
                        },
                        new
                        {
                            Id = "497b6bc5-9a89-480c-9419-8346c01c40ea",
                            ConversionFactor = 0.30480000000000002,
                            ConversionId = 1,
                            ConversionOffset = 0.0,
                            FromUnit = "Feet",
                            Name = "Feet to Meters",
                            ToUnit = "Meters"
                        },
                        new
                        {
                            Id = "54d95a13-9830-4355-8e22-aefae3a3b033",
                            ConversionFactor = 2.2046199999999998,
                            ConversionId = 2,
                            ConversionOffset = 0.0,
                            FromUnit = "Kilograms",
                            Name = "Kilograms to Pounds",
                            ToUnit = "Pounds"
                        },
                        new
                        {
                            Id = "9c9d33f3-c705-4e23-9d78-c85800043173",
                            ConversionFactor = 0.453592,
                            ConversionId = 2,
                            ConversionOffset = 0.0,
                            FromUnit = "Pounds",
                            Name = "Pounds to Kilograms",
                            ToUnit = "Kilograms"
                        },
                        new
                        {
                            Id = "a0001d7e-f30e-49c2-bc65-7d5b5881dc94",
                            ConversionFactor = 0.26417200000000002,
                            ConversionId = 6,
                            ConversionOffset = 0.0,
                            FromUnit = "Liters",
                            Name = "Liters to Gallons",
                            ToUnit = "Gallons"
                        },
                        new
                        {
                            Id = "a96e8f04-5391-4b6c-8631-6dbb326aaab5",
                            ConversionFactor = 3.7854100000000002,
                            ConversionId = 6,
                            ConversionOffset = 0.0,
                            FromUnit = "Gallons",
                            Name = "Gallons to Liters",
                            ToUnit = "Liters"
                        },
                        new
                        {
                            Id = "1d78ec2d-bea4-4a69-b933-fb39a7043bb2",
                            ConversionFactor = 0.000145038,
                            ConversionId = 5,
                            ConversionOffset = 0.0,
                            FromUnit = "Pascals",
                            Name = "Pascals to PSI",
                            ToUnit = "PSI"
                        },
                        new
                        {
                            Id = "a56f04c3-d01a-4ffb-a4f4-0bc87f052903",
                            ConversionFactor = 6894.7600000000002,
                            ConversionId = 5,
                            ConversionOffset = 0.0,
                            FromUnit = "PSI",
                            Name = "PSI to Pascals",
                            ToUnit = "Pascals"
                        },
                        new
                        {
                            Id = "4535ccaa-d228-4022-b6c1-acaf934134b6",
                            ConversionFactor = 0.62137100000000001,
                            ConversionId = 3,
                            ConversionOffset = 0.0,
                            FromUnit = "Kilometers per hour",
                            Name = "Kilometers to Miles",
                            ToUnit = "Miles per hour"
                        },
                        new
                        {
                            Id = "138021cb-6ee4-4602-b599-95cc5a4063da",
                            ConversionFactor = 1.60934,
                            ConversionId = 3,
                            ConversionOffset = 0.0,
                            FromUnit = "Miles per hour",
                            Name = "Miles to Kilometers",
                            ToUnit = "Kilometers per hour"
                        });
                });

            modelBuilder.Entity("Imperial_Metric.Domain.Entities.ConversionsRates", b =>
                {
                    b.HasOne("Imperial_Metric.Domain.Entities.Conversions", "Conversion")
                        .WithMany()
                        .HasForeignKey("ConversionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversion");
                });
#pragma warning restore 612, 618
        }
    }
}
