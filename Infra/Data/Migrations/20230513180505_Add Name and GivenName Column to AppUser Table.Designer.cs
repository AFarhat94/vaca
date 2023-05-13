﻿// <auto-generated />
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Data.Migrations
{
    [DbContext(typeof(VacaDbContext))]
    [Migration("20230513180505_Add Name and GivenName Column to AppUser Table")]
    partial class AddNameandGivenNameColumntoAppUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Core.Entities.Coordinations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coordinations");
                });

            modelBuilder.Entity("Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Core.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoordinationsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoordinationsId")
                        .IsUnique();

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Core.Entities.Image", b =>
                {
                    b.HasOne("Core.Entities.Place", null)
                        .WithMany("Images")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Place", b =>
                {
                    b.HasOne("Core.Entities.Coordinations", "Coordinations")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Place", "CoordinationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinations");
                });

            modelBuilder.Entity("Core.Entities.Place", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
