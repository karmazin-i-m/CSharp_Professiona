using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ITVDN_AdditionTask_1
{
    class View
    {
        private const int DefaultTextBufferHeight = 40;
        private const int DefaultTextBufferWidth = 120;

        private static Object KeyLock;
        private static ConsoleKey key;

        private static Thread viewThread1;
        private static Thread viewThread2;

        public View(Object obj)
        {
            KeyLock = obj;

            ProgrammSettings();
            viewThread1 = new Thread(() => { new StartBorder(); });
            viewThread1.Start();
        }

        private static void ProgrammSettings()
        {
            lock (KeyLock)
            {
                Console.SetBufferSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
                Console.SetWindowSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
            }

        }

        class StartBorder
        {
            public StartBorder()
            {
                lock (KeyLock)
                {
                    Console.Clear();
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             REFLECTOR TEXT             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.Write("X 1.                                                                                                                   X");
                    Console.Write("X 2.                                                                                                                   X");
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

                    for (int i = 0; i < 33; i++)
                    {
                        Console.Write("X                                                                                                                      X");
                    }

                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    StartMenuTextView();

                    Console.CursorLeft = 1;
                    Console.CursorTop = 6;

                    key = Console.ReadKey(false).Key;

                    if (key.Equals(ConsoleKey.D1))
                    {
                        new Thread(() => { new TypeBorder(); }).Start();
                    }
                    else
                        Environment.Exit(0);

                }
            }

            private void StartMenuTextView()
            {
                lock (KeyLock)
                {
                    Console.CursorLeft = 4;
                    Console.CursorTop = 3;

                    Console.Write("Open File");

                    Console.CursorLeft = 4;
                    Console.CursorTop = 4;

                    Console.Write("Exit");
                }
            }
        }
        class TypeBorder
        {
            public TypeBorder()
            {
                lock (KeyLock)
                {
                    Console.Clear();
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             REFLECTOR TEXT             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    Console.Write("X 1.                                                                                                                   X");
                    Console.Write("X 2.                                                                                                                   X");
                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

                    for (int i = 0; i < 33; i++)
                    {
                        Console.Write("Х                                     Х                                                                                Х");
                    }

                    Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                    TypeMenuTextView();
                    Console.CursorLeft = 1;
                    Console.CursorTop = 6;

                    key = Console.ReadKey().Key;

                    if (key.Equals(ConsoleKey.D1))
                    {

                    }
                    else
                    {
                        new Thread(() => { new StartBorder();}).Start();
                    }
                }
            }
            private void TypeMenuTextView()
            {
                lock (KeyLock)
                {
                    Console.CursorLeft = 4;
                    Console.CursorTop = 3;

                    Console.Write("Press key that show Type info");

                    Console.CursorLeft = 4;
                    Console.CursorTop = 4;

                    Console.Write("Back");
                }
            }
        }
    }
}
