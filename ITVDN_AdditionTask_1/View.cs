using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace ITVDN_AdditionTask_1
{
    class View
    {
        private const int DefaultTextBufferHeight = 40;
        private const int DefaultTextBufferWidth = 120;

        private static Object KeyLock;
        private static ConsoleKey key;

        public event Action GetTypes;
        public event Action<String> GetTypeInfo;

        private List<String> Types;

        public View(Object obj)
        {
            KeyLock = obj;

            ProgrammSettings();
            new Thread(StartBorder).Start();
        }

        private static void ProgrammSettings()
        {
            lock (KeyLock)
            {
                Console.SetBufferSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
                Console.SetWindowSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
            }

        }

        public void StartBorder()
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

                key = Console.ReadKey(true).Key;

                if (key.Equals(ConsoleKey.D1) == true)
                {
                    new Thread(TypeBorder).Start();
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

        public void TypeBorder()
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

                key = Console.ReadKey(true).Key;

                if (key.Equals(ConsoleKey.D1))
                {
                    GetTypes?.Invoke();
                    while (true)
                    {
                        MoveCursor();
                        if (Console.ReadKey(true).Key.Equals(ConsoleKey.Enter) && Console.CursorTop >= 6 && Console.CursorLeft <= 39)
                        {
                            GetTypeInfo?.Invoke(Types[Console.CursorTop - 6]);

                            //Console.Clear();
                            //new Thread(TypeBorder).Start();
                        }
                    }

                }
                else
                {
                    new Thread(StartBorder).Start();
                }
            }
        }

        public void PrintTypes(IEnumerable<String> strings)
        {
            lock (KeyLock)
            {
                this.Types = new List<string>(strings);

                Console.CursorLeft = 2;
                Console.CursorTop = 6;

                foreach (String item in strings)
                {
                    Console.Write(item);
                    Console.CursorLeft = 2;
                    Console.CursorTop++;
                }
                Console.CursorLeft = 1;
                Console.CursorTop = 6;
            }
        }

        public void PrintTypeInfo(IEnumerable<String> strings)
        {
            lock (KeyLock)
            {
                Console.CursorLeft = 40;
                Console.CursorTop = 6;

                foreach (String item in strings)
                {
                    Console.Write(item);
                    Console.CursorLeft = 40;
                    Console.CursorTop++;
                }
                Console.CursorLeft = 39;
                Console.CursorTop = 6;
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

        private void MoveCursor()
        {
            lock (KeyLock)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.CursorTop--;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.CursorTop++;
                        break;
                }
            }
        }

        //class StartBorder
        //{
        //    public StartBorder()
        //    {
        //        lock (KeyLock)
        //        {
        //            Console.Clear();
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             REFLECTOR TEXT             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            Console.Write("X 1.                                                                                                                   X");
        //            Console.Write("X 2.                                                                                                                   X");
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

        //            for (int i = 0; i < 33; i++)
        //            {
        //                Console.Write("X                                                                                                                      X");
        //            }

        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            StartMenuTextView();

        //            Console.CursorLeft = 1;
        //            Console.CursorTop = 6;

        //            key = Console.ReadKey(false).Key;

        //            if (key.Equals(ConsoleKey.D1))
        //            {
        //                new Thread(() => { new TypeBorder(); }).Start();
        //            }
        //            else
        //                Environment.Exit(0);

        //        }

        //        private void StartMenuTextView()
        //        {
        //            lock (KeyLock)
        //            {
        //                Console.CursorLeft = 4;
        //                Console.CursorTop = 3;

        //                Console.Write("Open File");

        //                Console.CursorLeft = 4;
        //                Console.CursorTop = 4;

        //                Console.Write("Exit");
        //            }
        //        }
        //    }
        //}
        //class TypeBorder
        //{
        //    public TypeBorder()
        //    {
        //        lock (KeyLock)
        //        {
        //            Console.Clear();
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             REFLECTOR TEXT             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            Console.Write("X 1.                                                                                                                   X");
        //            Console.Write("X 2.                                                                                                                   X");
        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

        //            for (int i = 0; i < 33; i++)
        //            {
        //                Console.Write("Х                                     Х                                                                                Х");
        //            }

        //            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        //            TypeMenuTextView();
        //            Console.CursorLeft = 1;
        //            Console.CursorTop = 6;

        //            key = Console.ReadKey().Key;

        //            if (key.Equals(ConsoleKey.D1))
        //            {

        //            }
        //            else
        //            {
        //                new Thread(() => { new StartBorder();}).Start();
        //            }
        //        }
        //    }
        //    private void TypeMenuTextView()
        //    {
        //        lock (KeyLock)
        //        {
        //            Console.CursorLeft = 4;
        //            Console.CursorTop = 3;

        //            Console.Write("Press key that show Type info");

        //            Console.CursorLeft = 4;
        //            Console.CursorTop = 4;

        //            Console.Write("Back");
        //        }
        //    }
        //}
    }
}
