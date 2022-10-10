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
        //public DbSet<Manager>Manager { get; set; }
        //public DbSet<Arbeiter> Arbeiter { get; set; }
        #region TPH(Table-Per-Hierarcy)  
        //Wenn wir alle anderen Tabellen in einer einzelnen Hierarchie aggregieren möchten,
        //können wir die Tabellenstruktur pro Hierarchie verwenden.
        //public DbSet<BasisPersonal> BasisPersonal { get; set; }
        #endregion

        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<ProduktEigenschaft> ProduktEigenschaften { get; set; }

        //public DbSet<Student> Studenten { get; set; }
        //public DbSet<Lehrer> Lehrer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initialisierer.Build();
            #region Lazy loading Einstellung (Logging)
            //optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information)
            //    .UseLazyLoadingProxies().UseSqlServer(Initialisierer.configurationRoot.GetConnectionString("SqlVerbindung"));
            #endregion
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
            #region EF Core Configuration 
            #region Tabelle umbenennen
            //modelBuilder.Entity<Produkt>().ToTable("ProduktTbl", "produkte");
            #endregion

            #region EF Core Configuration (Property Vorgänge) 
            //modelBuilder.Entity<Produkt>().HasKey(p => p.Produkt_ID); //Speziell benennen
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).IsRequired();
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).HasMaxLength(50);
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).HasMaxLength(150).IsFixedLength();
            #endregion

            #region In DbKontext Klasse mit Fluent API FK definieren
            //Wenn man FK speziell benenen will, soll man Fluent API verwenden.

            //One-To-Many
            //Immer mit Has fängt man an, dann verwendet man With property
            //modelBuilder.Entity<Kategorie>().HasMany(k => k.Produkte).WithOne(p => p.Kategorie).HasForeignKey(p=>p.Kategorie_ID);
            //One-To-One
            //modelBuilder.Entity<Produkt>().HasOne(k => k.ProduktEigenschaft).WithOne(p => p.Produkt).
            //    HasForeignKey<ProduktEigenschaft>(pe => pe.ID);
            #endregion

            #region Speziell Id definieren mit Fluent API
            //Many-To-Many
            //modelBuilder.Entity<Student>().HasMany(s => s.Lehrer)
            //    .WithMany(t => t.Studenten)
            //    .UsingEntity<Dictionary<string, object>>("StudentLehrerManyToMany",
            //    tbl => tbl.HasOne<Lehrer>().WithMany().HasForeignKey("Lehrer_ID").HasConstraintName("FK_LehrerID"),
            //    tbl=>tbl.HasOne<Student>().WithMany().HasForeignKey("Student_ID").HasConstraintName("FK_StudentID"));
            #endregion
            #endregion

            #region Relationships Delete Behaviors
            #region Cascade
            //modelBuilder.Entity<Kategorie>().HasMany(p => p.Produkte).WithOne(k => k.Kategorie).HasForeignKey
            //    (fk => fk.KategorieID).OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region Restrict
            //modelBuilder.Entity<Kategorie>().HasMany(p => p.Produkte).WithOne(k => k.Kategorie).HasForeignKey
            //    (fk => fk.KategorieID).OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region NoAction
            //modelBuilder.Entity<Kategorie>().HasMany(p => p.Produkte).WithOne(k => k.Kategorie).HasForeignKey
            //    (fk => fk.KategorieID).OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region SetNull
            //modelBuilder.Entity<Kategorie>().HasMany(p => p.Produkte).WithOne(k => k.Kategorie).HasForeignKey
            //    (fk => fk.KategorieID).OnDelete(DeleteBehavior.SetNull);
            #endregion
            #endregion

            #region DatabaseGenerated Attribute
            //modelBuilder.Entity<Produkt>().Property(p => p.MwStPreis).HasComputedColumnSql("[MwSt]*[Preis]");
            #endregion

            #region DatabaseGenerated Identity-Computed-None
            //modelBuilder.Entity<Produkt>().Property(p => p.MwStPreis).ValueGeneratedOnAdd();//Identity
            //modelBuilder.Entity<Produkt>().Property(p => p.MwStPreis).ValueGeneratedOnAddOrUpdate();//Computed
            //modelBuilder.Entity<Produkt>().Property(p => p.MwStPreis).ValueGeneratedNever();//None
            #endregion

            #region Precision Einstellung(Preis Property(18,2))
            //modelBuilder.Entity<Produkt>().Property(p => p.Preis).HasPrecision(18, 2);
            #endregion

            #region TPH(Table-Per-Type)
            //modelBuilder.Entity<BasisPersonal>().ToTable("Personal");
            //modelBuilder.Entity<Arbeiter>().ToTable("Arbeiter");
            //modelBuilder.Entity<Manager>().ToTable("Manager");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
