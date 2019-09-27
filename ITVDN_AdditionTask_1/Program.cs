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
        private const int DefaultTextBufferHeight = 40;
        private const int DefaultTextBufferWidth = 120;

        private static String path;

        static void Main(string[] args)
        {
            ProgrammSettings();

            View(ViewState.Start);
            Menu();

            Console.ReadKey();
        }

        private static void View(ViewState state)
        {
            Console.Clear();

            StringBuilder sb;

            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             REFLECTOR TEXT             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("X 1. Open File                                                                                                         X");
            Console.Write("X 2. Press ESC to exit                                                                                                 X");
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            switch (state)
            {
                case ViewState.Start:

                    sb = new StringBuilder();

                    for (int i = 0; i < 33; i++)
                    {
                        sb.Append('X');
                        sb.Append(new String(' ', DefaultTextBufferWidth - 2));
                        sb.Append('X');
                    }

                    sb.Append('X', 119);

                    Console.Write(sb.ToString());

                    Console.CursorLeft = 1;
                    Console.CursorTop = 38;
                    return;

                case ViewState.Open:

                    sb = new StringBuilder();

                    String str = " Введите полный путь к файлу: ";
                    sb.Append('X');
                    sb.Append(str);
                    sb.Append(' ', DefaultTextBufferWidth - 2 - str.Length);
                    sb.Append('X');

                    for (int i = 0; i < 30; i++)
                    {
                        sb.Append('X');
                        sb.Append(new String(' ', DefaultTextBufferWidth - 2));
                        sb.Append('X');
                    }
                    sb.Append('X', 119);
                    Console.Write(sb.ToString());

                    Console.CursorLeft = DefaultTextBufferWidth - (DefaultTextBufferWidth - str.Length - 1);
                    Console.CursorTop = 6;
                    path = Console.ReadLine();
                    View(ViewState.ShowAssembly);
                    return;
                case ViewState.ShowAssembly:

                    Assembly assembly;

                    sb = new StringBuilder();

                    try
                    {
                        assembly = Assembly.Load(path);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }

                    Type[] types = assembly.GetTypes();

                    if (types.Length > 0)
                    {
                        int count = 0;
                        foreach (Type item in types)
                        {
                            str = $" {count}. ";
                            sb.Append('X');
                            sb.Append(str + item.FullName);
                            sb.Append(' ', DefaultTextBufferWidth - str.Length - item.FullName.Length - 2);
                            sb.Append('X');
                            count++;
                        }

                        for (int i = 0; i < 33 - types.Length; i++)
                        {
                            sb.Append('X');
                            sb.Append(new String(' ', DefaultTextBufferWidth - 2));
                            sb.Append('X');
                        }
                        sb.Append('X', 119);
                        Console.Write(sb.ToString());
                    }

                    return;
            }
        }

        private static void Menu()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        View(ViewState.Open);
                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private static void ProgrammSettings()
        {
            Console.SetBufferSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
            Console.SetWindowSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
        }


    }

    enum ViewState
    {
        Start,
        Open,
        ShowAssembly,

    }
}
