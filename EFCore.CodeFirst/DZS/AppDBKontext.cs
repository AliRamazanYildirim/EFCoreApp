using EFCore.CodeFirst.Modelle;
using Microsoft.Data.SqlClient.Server;
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

        //public DbSet<Produkt> Produkte { get; set; }
        //public DbSet<Kategorie> Kategorien { get; set; }
        //public DbSet<ProduktEigenschaft> ProduktEigenschaften { get; set; }

        //public DbSet<VollesProdukt> VolleProdukte { get; set; }
        //public DbSet<ProduktMitProEigenschaft> ProduktMitProEigenschaften { get; set; }
        //public DbSet<WesentlichProdukt> WesentlichProdukte { get; set; }

        //public DbSet<SpeziellesProdukt> SpeziellesProdukte { get; set; }


        //public DbSet<Student> Studenten { get; set; }
        //public DbSet<Lehrer> Lehrer { get; set; }
        //public DbSet<Leiter> Leiter { get; set; }

        //public DbSet<Personal> Personal { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Arbeiter> Arbeiter { get; set; }


        #region TPH(Table-Per-Hierarcy)  
        //Wenn wir alle anderen Tabellen in einer einzelnen Hierarchie aggregieren möchten,
        //können wir die Tabellenstruktur pro Hierarchie verwenden.
        //public DbSet<BasisPersonal> BasisPersonal { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initialisierer.Build();
            #region Lazy loading Einstellung (Logging)
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseLazyLoadingProxies().UseSqlServer(Initialisierer.configurationRoot.GetConnectionString("SqlVerbindung"));
            #endregion

            #region Global QueryTracking (Logging)
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            //    .UseLazyLoadingProxies().UseSqlServer(Initialisierer.configurationRoot.
            //    GetConnectionString("SqlVerbindung")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            #endregion

            //optionsBuilder.UseSqlServer(Initialisierer.configurationRoot.GetConnectionString("SqlVerbindung"));
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

            #region In DbKontext Klasse mit Fluent API FK definieren(One-To-Many)
            //Wenn man FK speziell benenen will, soll man Fluent API verwenden.

            //One-To-Many
            //Immer mit Has fängt man an, dann verwendet man With property
            //modelBuilder.Entity<Kategorie>().HasMany(k => k.Produkte).WithOne(p => p.Kategorie).HasForeignKey(p=>p.Kategorie_ID);
            //One-To-One
            //modelBuilder.Entity<Produkt>().HasOne(k => k.ProduktEigenschaft).WithOne(p => p.Produkt).
            //    HasForeignKey<ProduktEigenschaft>(pe => pe.ID);
            #endregion

            #region Speziell Id definieren mit Fluent API(Many-To-Many)
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

            #region Model
            #region Owned mit Fluent API

            //modelBuilder.Entity<Manager>().OwnsOne(m => m.Personal,p=>
            //{
            //    p.Property(proName => proName.VorName).HasColumnName("VorName");
            //    p.Property(proName => proName.NachName).HasColumnName("NachName");
            //    p.Property(proName => proName.Alter).HasColumnName("Alter");
            //});
            //modelBuilder.Entity<Arbeiter>().OwnsOne(a => a.Personal,p=>
            //{
            //    p.Property(proName => proName.VorName).HasColumnName("VorName");
            //    p.Property(proName => proName.NachName).HasColumnName("NachName");
            //    p.Property(proName => proName.Alter).HasColumnName("Alter");
            //});

            #endregion

            #region Keyless mit Fluent API
            //modelBuilder.Entity<SpeziellesProdukt>().HasNoKey();
            #endregion

            #region NotMapped mit Fluent API
            //modelBuilder.Entity<Produkt>().Ignore(sc => sc.Strichcode);
            //modelBuilder.Entity<Produkt>().Property(n => n.Name).IsUnicode(false).HasMaxLength(200);//varchar 
            //modelBuilder.Entity<Produkt>().Property(u => u.Url).HasColumnType("nvarchar(200)")
            //    .HasColumnName("UrlName").HasColumnOrder(7);
            //modelBuilder.Entity<Produkt>().Property(p => p.Preis).HasPrecision(18, 2);
            #endregion

            #region Mit Fluent API Index definieren???
            // Mit diesem Code wird bei Db mehr Speicherplatz verwendet

            // _kontext.Produkte.Where(ind=>ind.Name=="Aspekte Neu B1").Select(ind=>new {name=ind.Name,preis=ind.Preis,
            //vorrat = ind.Vorrat, strichCode = ind.Strichcode});

            //modelBuilder.Entity<Produkt>().HasIndex(ind => ind.Name).IncludeProperties(ind => new
            //{
            //    ind.Preis,
            //    ind.Vorrat,
            //    ind.Strichcode
            //});

            //modelBuilder.Entity<Produkt>().HasCheckConstraint("RabattPreisCheck", "[Preis]>[RabattPreis]");

            //modelBuilder.Entity<Produkt>().HasIndex(i => new {i.Name,i.Preis}); 

            #endregion
            #endregion

            #region Query(Abfrage)

            #region Raw Sql Query 3.Weise mit FromSqlInterpolated spezielle Abfrage schreiben
            //modelBuilder.Entity<ProduktMitProEigenschaft>().HasNoKey();
            //modelBuilder.Entity<ProduktMitProEigenschaft>().Ignore(p => p.ID);
            //modelBuilder.Entity<WesentlichProdukt>().HasNoKey();
            //modelBuilder.Entity<WesentlichProdukt>().Ignore(p => p.ID);

            #endregion

            #region ToSqlQuery Methode(Spezille Abfrage)

            //modelBuilder.Entity<WesentlichProdukt>().HasNoKey().ToSqlQuery("Select Name,Preis From Produkte");

            #endregion

            #region ToView Methode

            //modelBuilder.Entity<VollesProdukt>().HasNoKey().ToView("ProduktMitEigenschaften");

            #endregion

            #region Global Query Filters
            //private readonly int Strichcode;

            //public AppDBKontext(int strichcode)
            //{
            //    Strichcode = strichcode;
            //}
            //public AppDBKontext()
            //{

            //}
            //modelBuilder.Entity<Produkt>().Property(p => p.IstGelöscht).HasDefaultValue(false);

            //modelBuilder.Entity<Produkt>().HasQueryFilter(p => p.IstGelöscht == false);
            //oder
            //modelBuilder.Entity<Produkt>().HasQueryFilter(p => !p.IstGelöscht);
            //modelBuilder.Entity<Produkt>().HasQueryFilter(p => !p.IstGelöscht);

            //*** Wenn 1 Parameter von außen eingegeben wird. ***
            //if (Strichcode!=default(int))
            //{
            //    modelBuilder.Entity<Produkt>().HasQueryFilter( p => !p.IstGelöscht&&p.Strichcode == Strichcode);

            //}
            //else
            //{
            //    modelBuilder.Entity<Produkt>().HasQueryFilter(p => !p.IstGelöscht);

            //}


            #endregion

            #endregion

            #region Store Procedure mit Spezielle Tabelle und Join
            //modelBuilder.Entity<VollesProdukt>().HasNoKey();
            #endregion
            #region Store Procedure mit Fluent API 
            modelBuilder.Entity<Manager>().OwnsOne(o => o.Personal, p =>
            {
                p.Property(o => o.VorName).HasColumnName("Vorname");
                p.Property(o => o.NachName).HasColumnName("Nachname");
                p.Property(o => o.Alter).HasColumnName("Alter");

            });
            modelBuilder.Entity<Arbeiter>().OwnsOne(o => o.Personal, p =>
            {
                p.Property(o => o.VorName).HasColumnName("Vorname");
                p.Property(o => o.NachName).HasColumnName("Nachname");
                p.Property(o => o.Alter).HasColumnName("Alter");
            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
