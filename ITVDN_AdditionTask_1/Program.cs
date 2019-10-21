using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ITVDN_AdditionTask_1
{
    class Program
    {
        private static readonly Object LockKey = new Object();
        private static readonly Reflector reflector = new Reflector("ITVDN_Task_2");
        private static readonly View view = new View(LockKey);

        static void Main(string[] args)
        {
            //Console.WriteLine($"В сборке есть типы:");
            //foreach (String item in reflector.Types)
            //{
            //    Console.WriteLine(item);
            //    reflector.TypeInfo(item);

            //    Console.WriteLine("Методы: ");
            //    foreach (var method in reflector.Methods)
            //        Console.WriteLine(method);

            //    Console.WriteLine("Поля: ");
            //    foreach (var method in reflector.Fields)
            //        Console.WriteLine(method);

            //    Console.WriteLine("События: ");
            //    foreach (var method in reflector.Events)
            //        Console.WriteLine(method);

            //    Console.WriteLine(new String('-', 80));
            //}

            //Console.ReadKey();
        }
    }
}
