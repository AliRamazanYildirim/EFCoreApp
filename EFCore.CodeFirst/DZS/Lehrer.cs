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
        //Object reference not set to an instance of an object.
        //Um die obige Fehlermeldung nicht zu erhalten, müssen wir eine Objektinstanz erstellen.
        public ICollection<Student> Studenten { get; set; }= new List<Student>();
    }
}
