using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DBFirst.DZS
{
    
    public class DBKontextInitialisierer
    {
        public static IConfigurationRoot configurationRoot;
        public static DbContextOptionsBuilder<AppDBKontext> optionsBuilder;
        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile
                ("appsettings.json", optional:true,reloadOnChange:true);

            configurationRoot = builder.Build();
            //optionsBuilder = new DbContextOptionsBuilder<AppDBKontext>();
            //optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("SqlVerbindung"));
        }

    }
}
