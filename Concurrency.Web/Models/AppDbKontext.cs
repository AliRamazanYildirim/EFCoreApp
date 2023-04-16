using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Models
{
    public class AppDbKontext:DbContext
    {
        public DbSet<Produkt> Produkte { get; set; }
        public AppDbKontext(DbContextOptions<AppDbKontext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkt>().Property(p => p.RowVersion).IsRowVersion();

            modelBuilder.Entity<Produkt>().Property(p => p.Preis).HasPrecision(18,2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
