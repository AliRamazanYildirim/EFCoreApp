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
        
        public string VorName { get; set; }
        public string NachName { get; set; }
        public int Alter { get; set; }
    }
}
