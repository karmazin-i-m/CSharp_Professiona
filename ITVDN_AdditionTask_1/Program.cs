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
        private static View view = new View(LockKey);

        static void Main(string[] args)
        {
            view.KeyPressed += PressedKey;
            view.StartBorderView();
            
            

            Console.ReadKey();
        }

        static void PressedKey(ConsoleKey key)
        {
            if (key == ConsoleKey.D1)
            {
                view.TypeBorderView();
            }


        }

    }
}
