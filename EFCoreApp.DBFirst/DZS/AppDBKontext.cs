using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DBFirst.DZS
{
    public class AppDBKontext:DbContext
    {
        public DbSet<Produkt> Produkte { get; set; }
        public AppDBKontext()
        {

        }

        public AppDBKontext(DbContextOptions<AppDBKontext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBKontextInitialisierer.configurationRoot.GetConnectionString("SqlVerbindung"));
           
        }
    }
}
