using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITVDN_AdditionTask_1.Employes;
using System;

namespace ITVDN_AdditionTask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Dima");
            Director director = new Director("Vlad");
            Programer programer = new Programer("Oleg");

            Company qwerty = new Company();

            qwerty.GetAccess(director);
            qwerty.GetAccess(manager);
            qwerty.GetAccess(programer);

            Console.ReadKey();
        }
    }
}
