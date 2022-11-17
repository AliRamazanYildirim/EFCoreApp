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
    [Migration("20221117114230_Initiale")]
    partial class Initiale
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Arbeiter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Gehalt")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Arbeiter");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Manager", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Grad")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Arbeiter", b =>
                {
                    b.OwnsOne("EFCore.CodeFirst.DZS.Personal", "Personal", b1 =>
                        {
                            b1.Property<int>("ArbeiterID")
                                .HasColumnType("int");

                            b1.Property<int>("Alter")
                                .HasColumnType("int");

                            b1.Property<string>("NachName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("VorName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ArbeiterID");

                            b1.ToTable("Arbeiter");

                            b1.WithOwner()
                                .HasForeignKey("ArbeiterID");
                        });

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Manager", b =>
                {
                    b.OwnsOne("EFCore.CodeFirst.DZS.Personal", "Personal", b1 =>
                        {
                            b1.Property<int>("ManagerID")
                                .HasColumnType("int");

                            b1.Property<int>("Alter")
                                .HasColumnType("int");

                            b1.Property<string>("NachName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("VorName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ManagerID");

                            b1.ToTable("Manager");

                            b1.WithOwner()
                                .HasForeignKey("ManagerID");
                        });

                    b.Navigation("Personal");
                });
#pragma warning restore 612, 618
        }
    }
}
