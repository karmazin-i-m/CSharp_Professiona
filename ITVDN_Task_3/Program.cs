using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ITVDN_Task_3
{
    class Program
    {
        static Assembly assembly;
        static void Main(string[] args)
        {
            try
            {
                assembly = Assembly.Load("ITVDN_Task_2");
            }
            catch (FileNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла ошибка: " + e.Message);
                Console.ResetColor();
            }

            try
            {
                Type converter = assembly.GetType("ITVDN_Task_2.Converter");
                MethodInfo celsiusToFaringate = converter.GetMethod("CelsiusToFaringate");
                Console.WriteLine(celsiusToFaringate.Invoke(converter, new object[] { 0 }));
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла ошибка: " + e.Message);
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}
