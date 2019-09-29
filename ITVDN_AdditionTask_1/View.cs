using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_AdditionTask_1
{
    class View
    {
        private const int DefaultTextBufferHeight = 40;
        private const int DefaultTextBufferWidth = 120;

        private static Object KeyLock;
        public event Action<ConsoleKey> KeyPressed;
        public event Action<String> SetPath;

        public View(Object obj)
        {
            KeyLock = obj;

            ProgrammSettings();
        }

        private static void ProgrammSettings()
        {
            lock (KeyLock)
            {
                Console.SetBufferSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
                Console.SetWindowSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
            }

        }

        public void StartBorderView()
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

                IsTherePressKeyHandler(Console.ReadKey(true).Key);
            }
        }

        public void TypeBorderView()
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

        private void IsTherePressKeyHandler(ConsoleKey key)
        {
            if (KeyPressed == null)
                throw new NullReferenceException("У события нет обработчиков.");

            KeyPressed.Invoke(key);
        }

        private void IsTherePathHandler(String path)
        {

        }
    }
}
