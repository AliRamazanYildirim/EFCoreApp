﻿// <auto-generated />
using EFCore.CodeFirst.DZS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    [DbContext(typeof(AppDBKontext))]
    partial class AppDBKontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCore.CodeFirst.DZS.BasisPersonal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Alter")
                        .HasColumnType("int");

                    b.Property<string>("NachName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Personal", (string)null);
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Arbeiter", b =>
                {
                    b.HasBaseType("EFCore.CodeFirst.DZS.BasisPersonal");

                    b.Property<decimal>("Gehalt")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Arbeiter", (string)null);
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Manager", b =>
                {
                    b.HasBaseType("EFCore.CodeFirst.DZS.BasisPersonal");

                    b.Property<int>("Grad")
                        .HasColumnType("int");

                    b.ToTable("Manager", (string)null);
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Arbeiter", b =>
                {
                    b.HasOne("EFCore.CodeFirst.DZS.BasisPersonal", null)
                        .WithOne()
                        .HasForeignKey("EFCore.CodeFirst.DZS.Arbeiter", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.CodeFirst.DZS.Manager", b =>
                {
                    b.HasOne("EFCore.CodeFirst.DZS.BasisPersonal", null)
                        .WithOne()
                        .HasForeignKey("EFCore.CodeFirst.DZS.Manager", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
