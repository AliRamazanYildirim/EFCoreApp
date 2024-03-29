﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.DBFirstZurScaffold.Models
{
    public partial class EFCoreDBFirstDbKontext : DbContext
    {
        public EFCoreDBFirstDbKontext()
        {
        }

        public EFCoreDBFirstDbKontext(DbContextOptions<EFCoreDBFirstDbKontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produkt> Produkte { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=THINKPAD;Initial Catalog=EFCoreDBFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.ToTable("Produkte");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Preis).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
