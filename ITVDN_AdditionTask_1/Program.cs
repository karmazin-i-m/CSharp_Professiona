using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ITVDN_AdditionTask_1
{
    class Program
    {
        static Int32 a = 0;
        private static readonly Object SyncRoot = new Object();
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Count);
            Thread thread2 = new Thread(Count);
            Thread thread3 = new Thread(Count);

            thread1.Name = "Поток 1";
            thread2.Name = "Поток 2";
            thread3.Name = "Поток 3";

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadKey();
        }

        public static void Count()
        {
            lock (SyncRoot)
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Поток {Thread.CurrentThread.Name} говорит {++a}");
                }
        }
    }
}
