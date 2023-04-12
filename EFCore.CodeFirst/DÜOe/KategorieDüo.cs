using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DÜOe
{
    public class KategorieDüo
    {
        public string KategorieName { get; set; }
        public String ProduktName { get; set; }
        public decimal GesamtPreis { get; set; }
        public int? GesamtBreite { get; set; }
    }
}
