using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class Kategorie
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public virtual List<Produkt> Produkte { get; set; } = new List<Produkt>();
    }
}
