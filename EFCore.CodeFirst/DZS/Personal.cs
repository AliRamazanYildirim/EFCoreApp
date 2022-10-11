using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    #region Mit Data Annotation attribute Owned definieren
    //[Owned]
    #endregion
    public class Personal
    {
        //Wenn man mit Owned Entity Types  die Klassen teilen möchte, soll man nicht bei Owned Klasse ID property verwenden
        public string VorName { get; set; }
        public string NachName { get; set; }
        public int Alter { get; set; }
    }

    #region BasisPersonal
    //public class Arbeiter : BasisPersonal
    //{
    //    [Precision(18, 2)]
    //    public decimal Gehalt { get; set; }
    //}
    #endregion
}
