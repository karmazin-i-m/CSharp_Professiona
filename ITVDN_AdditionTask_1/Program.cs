using ITVDN_AdditionTask_1.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITVDN_AdditionTask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Information("Start");

            for (int i = 0; i < 10; i++)
            {
                new Thread(() =>
                {
                    Reader reader = new Reader() { Name = $"Readder {i}" };
                    Logger.Information($"Создан пользователь с именем {reader.Name}");
                    reader.GoToLibrary();

                }).Start();
                Thread.Sleep(10);
            }

            Console.ReadKey();
        }
    }

    class Reader
    {
        private Library _library = Library.GetInstance();
        private static Random _random = new Random();
        public String Name { get; set; }

        public void GoToLibrary()
        {
            _library.AddReader(this);
            Read();
        }

        private void Read()
        {
            Logger.Information($"Читатель {Name} пришел в библиотеку и читает");
            Thread.Sleep(_random.Next(3000));
            GoToHome();
        }

        public void GoToHome()
        {
            Logger.Information($"Читатель {Name} решил пойти домой.");
            _library.RemoveReader(this);
        }
    }

    class Library
    {
        private static Library _instance = null;
        private static readonly Object _syncRoot = new Object();
        private static readonly Semaphore semaphore = new Semaphore(3, 3);
        private List<Reader> _readers;

        public void AddReader(Reader reader)
        {
            semaphore.WaitOne();
            _readers.Add(reader);
        }
        public void RemoveReader(Reader reader)
        {
            _readers.Remove(reader);
            semaphore.Release();
        }

        private Library()
        {
            _readers = new List<Reader>();
        }

        public static Library GetInstance()
        {
            if (_instance == null)
                lock (_syncRoot)
                    if (_instance == null)
                        _instance = new Library();
            return _instance;
        }
    }
}
