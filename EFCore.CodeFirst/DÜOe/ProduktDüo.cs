using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DÜOe
{
    public class ProduktDüo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public decimal RabattPreis { get; set; }
        public int Vorrat { get; set; }
    }
}
