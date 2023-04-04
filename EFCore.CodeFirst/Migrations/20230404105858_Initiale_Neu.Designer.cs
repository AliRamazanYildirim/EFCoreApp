﻿// <auto-generated />
using EFCore.CodeFirst.DZS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    [DbContext(typeof(AppDBKontext))]
    [Migration("20230404105858_Initiale_Neu")]
    partial class Initiale_Neu
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Kategorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kategorien");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Produkt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("IstGelöscht")
                        .HasColumnType("bit");

                    b.Property<int>("KategorieID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preis")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal>("RabattPreis")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("Strichcode")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vorrat")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KategorieID");

                    b.ToTable("Produkte");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.ProduktEigenschaft", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Breite")
                        .HasColumnType("int");

                    b.Property<string>("Farbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grösse")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ProduktEigenschaften");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Produkt", b =>
                {
                    b.HasOne("EFCore.CodeFirst.DZS.Kategorie", "Kategorie")
                        .WithMany("Produkte")
                        .HasForeignKey("KategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorie");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.ProduktEigenschaft", b =>
                {
                    b.HasOne("EFCore.CodeFirst.DZS.Produkt", "Produkt")
                        .WithOne("ProduktEigenschaft")
                        .HasForeignKey("EFCore.CodeFirst.DZS.ProduktEigenschaft", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Kategorie", b =>
                {
                    b.Navigation("Produkte");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Produkt", b =>
                {
                    b.Navigation("ProduktEigenschaft");
                });
#pragma warning restore 612, 618
        }
    }
}
