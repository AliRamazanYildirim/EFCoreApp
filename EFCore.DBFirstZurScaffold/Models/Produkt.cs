using System;
using System.Collections.Generic;

namespace EFCore.DBFirstZurScaffold.Models
{
    public partial class Produkt
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public decimal Preis { get; set; }
        public int? Vorrat { get; set; }
    }
}
