using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public int Vorrat { get; set; }
        public int Strichcode { get; set; }
    }
}
