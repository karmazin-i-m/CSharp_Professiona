using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_AdditionTask_1
{
    class ViewConsole
    {
        private const int DefaultTextBufferHeight = 40;
        private const int DefaultTextBufferWidth = 120;

        private readonly Object KeyLock;

        public ViewConsole(Object key)
        {
            this.KeyLock = key;

            lock (KeyLock)
            {
                Console.SetBufferSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
                Console.SetWindowSize(DefaultTextBufferWidth, DefaultTextBufferHeight);
            }
        }

        public void Start()
        {
            StartBorder();
        }

        private void StartBorder()
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
            }
        }
        public void PrintTop(IEnumerable<String> message)
        {
            lock (KeyLock)
            {
                Console.CursorLeft = 4;
                Console.CursorTop = 3;

                Console.Write(message.ToList<String>()[0]);

                Console.CursorLeft = 4;
                Console.CursorTop = 4;

                Console.Write(message.ToList<String>()[1]);

                Console.CursorLeft = 119;
                Console.CursorTop = 39;
            }
        }
        public void PrintLeft(IEnumerable<String> message)
        {
            lock (KeyLock)
            {
                Console.CursorLeft = 2;
                Console.CursorTop = 6;

                foreach (String item in message)
                {
                    Console.Write(item);
                    Console.CursorLeft = 2;
                    Console.CursorTop++;
                }
                Console.CursorLeft = 1;
                Console.CursorTop = 6;
            }
        }
        public void PrintRight(IEnumerable<String> message)
        {
            lock (KeyLock)
            {
                Console.CursorLeft = 40;
                Console.CursorTop = 6;

                for (int i = 7; i < DefaultTextBufferHeight-1; i++)
                {
                    Console.WriteLine(new String(' ', DefaultTextBufferWidth-40));
                    Console.CursorTop = i;
                    Console.CursorLeft = 40;
                }

                Console.CursorLeft = 40;
                Console.CursorTop = 6;

                foreach (String item in message)
                {
                    Console.Write(item);
                    Console.CursorLeft = 40;
                    Console.CursorTop++;
                }
                Console.CursorLeft = 39;
                Console.CursorTop = 6;
            }
        }
    }
}
