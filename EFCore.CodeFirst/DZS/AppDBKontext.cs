using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class AppDBKontext:DbContext
    {
        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Kategorie>Kategorien { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initialisierer.Build();
            optionsBuilder.UseSqlServer(Initialisierer.configurationRoot.GetConnectionString("SqlVerbindung"));
        }
        #region SaveChanges Methode in DbKontext Klasse definieren
        //public override int SaveChanges()
        //{
        //    //Ich verschiebe das Erstellungsdatum an eine zentrale Stelle.
        //    ChangeTracker.Entries().ToList().ForEach(data =>
        //    {
        //        if (data.Entity is Produkt produkt)
        //        {
        //            if (data.State == EntityState.Added)
        //            {
        //                produkt.ErstellungsDatum = DateTime.Now;
        //            }
        //        }
        //    });

        //    return base.SaveChanges();
        //}
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tabelle umbenennen
            //modelBuilder.Entity<Produkt>().ToTable("ProduktTbl", "produkte");
            #endregion
            #region Property Vorgänge
            //modelBuilder.Entity<Produkt>().HasKey(p => p.ID);
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).IsRequired();
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).HasMaxLength(50);
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).HasMaxLength(150).IsFixedLength();
            #endregion
            #region In DbKontext Klasse mit Fluent API FK definieren
            //Immer mit Has fängt man an, dann verwendet man With property
            //modelBuilder.Entity<Kategorie>().HasMany(k => k.Produkte).WithOne(p => p.Kategorie).HasForeignKey(p=>p.Kategorie_ID);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
