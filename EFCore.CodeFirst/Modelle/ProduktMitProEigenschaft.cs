using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.Modelle
{
    public class ProduktMitProEigenschaft
    {
        //Bei den speziellen Abfragen ist es besser, wenn man HasNoKey und Ignore Methode verwendet,
        //weil Ef Core wird ID property als Primary Key akzeptieren.
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Grösse { get; set; }
        public int? Breite { get; set; }


    }
}
