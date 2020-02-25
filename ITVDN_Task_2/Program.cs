using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITVDN_Task_2
{
    class Program
    {
        // Аргумент:
        // false - установка в несигнальное состояние.
        static AutoResetEvent auto = new AutoResetEvent(false);
        static Boolean flag = false;

        static void Main()
        {
            Thread thread = new Thread(Function);
            thread.Start();
            Thread.Sleep(500); // Дадим время запуститься вторичному потоку.

            Console.WriteLine("Ждите.\n");
            Wait();
            auto.Set(); // Продолжение выполнения вторичного потока.

            Console.WriteLine("Ждите.\n");
            Wait();
            auto.Set(); // Продолжение выполнения вторичного потока.

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            Console.WriteLine("Красный свет");
            //Thread.Sleep(100);
            flag = true;
            auto.WaitOne(); // Остановка выполнения вторичного потока.

            Console.WriteLine("Желтый");
            Thread.Sleep(1000);
            flag = true;
            auto.WaitOne(); // Остановка выполнения вторичного потока.

            Console.WriteLine("Зеленый");
        }

        static void Wait()
        {
            while (!flag)
            {
                Thread.Sleep(20);
                flag = false;
            }
        }
    }
}
