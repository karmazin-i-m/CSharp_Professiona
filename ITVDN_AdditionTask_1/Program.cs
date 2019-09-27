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
        private const int TextBufferHeight = 40;
        private const int TextBufferWidth = 120;

        static void Main(string[] args)
        {
            View(ViewState.Start);
            Menu();

            Console.ReadKey();
        }

        private static void View(ViewState state)
        {
            Console.SetWindowSize(TextBufferWidth, TextBufferHeight);

            StringBuilder sb = new StringBuilder();

            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             REFLECTOR TEXT             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("X 1. Open File                                                                                                         X");
            Console.Write("X 2. Press ESC to exit                                                                                                 X");
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            switch (state)
            {
                case ViewState.Start:

                    for (int i = 0; i < 33; i++)
                    {
                        sb.Append("X                                                                                                                      X");
                    }

                    break;
                case ViewState.Open:

                    for (int i = 0; i < 33; i++)
                    {
                        sb.Append("X                                                                                                                      X");
                    }

                    break;

            }


            sb.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write(sb.ToString());
            Console.CursorLeft = 1;
            Console.CursorTop = 38;
        }

        private static void Menu()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:

                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private static void OpenFile()
        {

        }


    }

    enum ViewState
    {
        Start,
        Open,

    }
}
