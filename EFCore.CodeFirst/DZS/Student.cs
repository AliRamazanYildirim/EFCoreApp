using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DZS
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Alter { get; set; }
        public List<Lehrer> Lehrer { get; set; } = new();
    }
}
