using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class1 class2 = new Class2();
            Class1 class3 = new Class3();

            class1.Method1();
            class1.Method2();
            class1.Method3();

            Console.WriteLine();

            class2.Method1();
            class2.Method2();
            class2.Method3();

            Console.WriteLine();

            class3.Method1();
            class3.Method2();
            class3.Method3();

            Console.ReadKey();
        }
    }

    class Class1
    {
        public virtual void Method1()
        {
            Console.WriteLine("Method1 in Class1");
        }
        public void Method2()
        {
            Console.WriteLine("Method2 in Class1");
        }
        public virtual void Method3()
        {
            Console.WriteLine("Method3 in Class1");
        }
    }
    class Class2 : Class1
    {
        public override void Method1()
        {
            Console.WriteLine("Method1 in Class2");
        }
        public new void Method2()
        {
            Console.WriteLine("Method2 in Class2");
        }
        public sealed override void Method3()
        {
            Console.WriteLine("Method3 in Class2");
        }
    }
    class Class3 : Class2
    {
        public override void Method1()
        {
            Console.WriteLine("Method1 in Class3");
        }
        public new void Method2()
        {
            Console.WriteLine("Method2 in Class3");
        }
        public new void Method3()
        {
            Console.WriteLine("Method3 in Class3");
        }
    }
}
