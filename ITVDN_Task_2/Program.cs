using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            My my = new My();

            my.Method1();
            my.Method2();

            Console.ReadKey();
        }
    }

    class My
    {
        [Obsolete("Warning", false)]
        public void Method1()
        {
            Console.WriteLine("Method1");
        }
        [Obsolete("Error", true)]
        public void Method2()
        {
            Console.WriteLine("Method2");
        }
    }
}
