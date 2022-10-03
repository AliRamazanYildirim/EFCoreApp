using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class Lehrer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Studenten { get; set; }
    }
}
