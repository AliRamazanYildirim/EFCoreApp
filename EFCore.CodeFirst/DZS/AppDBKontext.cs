using Microsoft.EntityFrameworkCore;
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
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initialisierer.Build();
            optionsBuilder.UseSqlServer(Initialisierer.configurationRoot.GetConnectionString("SqlVerbindung"));
        }
        //    public override int SaveChanges()
        //    {
        //        //Ich verschiebe das Erstellungsdatum an eine zentrale Stelle.
        //        ChangeTracker.Entries().ToList().ForEach(data =>
        //        {
        //            if (data.Entity is Produkt produkt)
        //            {
        //                if (data.State == EntityState.Added)
        //                {
        //                    produkt.ErstellungsDatum = DateTime.Now;
        //                }
        //            }
        //        });

        //        return base.SaveChanges();
        //    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Produkt>().ToTable("ProduktTbl", "produkte");
            modelBuilder.Entity<Produkt>().HasKey(p => p.ID);
            modelBuilder.Entity<Produkt>().Property(p => p.Name).IsRequired();
            //modelBuilder.Entity<Produkt>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Produkt>().Property(p => p.Name).HasMaxLength(150).IsFixedLength();


            base.OnModelCreating(modelBuilder);
        }
    }
}
