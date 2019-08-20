using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            MigrationService service = new MigrationService();

            service.Add(new Student("Illya", 20));
            service.Add(new Student("Lilia", 21));
            service.Add(new Student("Oleg", 17));
            service.Add(new Student("Vasya", 19));
            service.Add(new Worker("Kostya", 34));
            service.Add(new Worker("Petya", 27));
            service.Add(new Worker("Alina", 27));
            service.Add(new Retiree("Lybov", 65));
            service.Add(new Retiree("Anatoli", 67));
            service.Add(new Retiree("Sergey", 55));

            foreach(var item in service)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-',80));

            service.Remove();
            service.Remove(new Worker("Kostya", 34));

            foreach (var item in service)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 80));

            Console.ReadKey();
        }
    }
}
