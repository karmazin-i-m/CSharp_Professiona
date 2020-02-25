using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITVDN_Task_3
{
    class Program
    {
        private const String _name = "MY PROGRAMM";
        private static Mutex _mutex;
        static void Main(string[] args)
        {
            if (Mutex.TryOpenExisting(_name, out _mutex))
                Process.GetCurrentProcess().Kill();
            else
                _mutex = new Mutex(true, _name);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            _mutex.Dispose();
        }
    }
}
