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
        private static readonly Reflector reflector = new Reflector("ITVDN_AdditionTask_1");
        private static readonly ViewConsole view = new ViewConsole(LockKey);

        static void Main()
        {
            view.Start();
            view.PrintTop(new List<String>() { "Открыть", "Выйти" });
            view.PrintLeft(reflector.Types);
            Listner();
        }
        private static void Listner()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.Enter:
                        lock (LockKey)
                        {
                            if (Console.CursorLeft == 1)
                            {
                                reflector.TypeInfo(reflector.Types.ToList<String>()[Console.CursorTop - 6]);
                                view.PrintRight(reflector.Methods);
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        lock (LockKey)
                        {
                            if (Console.CursorTop < 7)
                            {
                                Console.CursorTop = 38;
                            }
                            else
                            {
                                Console.CursorTop--;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        lock (LockKey)
                        {
                            if (Console.CursorTop > 37)
                            {
                                Console.CursorTop = 6;
                            }
                            else
                            {
                                Console.CursorTop++;
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        lock (LockKey)
                        {
                            if (Console.CursorLeft == 39)
                            {
                                Console.CursorLeft = 1;
                            }else if (Console.CursorLeft == 1)
                            {

                            }
                        }
                        break;
                    case ConsoleKey.D1:
                        view.PrintRight(reflector.Methods);
                        break;
                    case ConsoleKey.D2:
                        view.PrintRight(reflector.Fields);
                        break;
                    case ConsoleKey.D3:
                        view.PrintRight(reflector.Events);
                        break;
                    case ConsoleKey.D4:
                        view.PrintRight(reflector.Attributes);
                        break;
                }
            }
        }
    }
}
