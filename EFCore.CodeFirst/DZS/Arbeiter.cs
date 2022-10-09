using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class Arbeiter:BasisPersonal
    {
        [Precision(18,2)]
        public decimal Gehalt { get; set; }
    }
}
