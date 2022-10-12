using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    [Keyless]
    public class SpeziellesProdukt
    {
        public int Produkt_ID { get; set; }
        public string KategorieName { get; set; }
        public string Name { get; set; }
        [Precision(18,2)]
        public decimal Preis { get; set; }
        public int Grösse { get; set; }



    }
}
