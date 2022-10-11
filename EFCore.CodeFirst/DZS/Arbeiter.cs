using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class Arbeiter
    {
        public int ID { get; set; }
        public Personal Personal { get; set; }
        [Precision(18,2)]
        public decimal Gehalt { get; set; }
        
    }
}
