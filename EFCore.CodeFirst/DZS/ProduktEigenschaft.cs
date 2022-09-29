using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class ProduktEigenschaft
    {
        public int ID { get; set; }
        public int Grösse { get; set; }
        public int Höhe { get; set; }
        public string Farbe { get; set; }
        #region Mit ForeignKey Attribute FK erstellen
        public int ProduktID { get; set; }
        [ForeignKey("ProduktID")]
        public Produkt Produkt { get; set; }
        #endregion
    }
}
