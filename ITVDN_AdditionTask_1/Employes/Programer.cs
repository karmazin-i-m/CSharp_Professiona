using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITVDN_AdditionTask_1.Atributes;


namespace ITVDN_AdditionTask_1.Employes
{
    [AccessLevel(false)]
    class Programer : Employe
    {
        public Programer(string name) : base(name)
        {
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} работает как Programer");
        }
    }
}
