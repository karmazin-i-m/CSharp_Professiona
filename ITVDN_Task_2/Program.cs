using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ITVDN_Task_2
{
    class Program
    {
        private static readonly Object SyncRoot = new Object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                String pathRead = Directory.GetCurrentDirectory() + "\\FIle1.txt";
                String pathWrite = Directory.GetCurrentDirectory() + "\\FIle3.txt";

                WriteFile(pathWrite, ReadFile(pathRead));
            });
            Thread thread2 = new Thread(() =>
            {
                String pathRead = Directory.GetCurrentDirectory() + "\\FIle2.txt";
                String pathWrite = Directory.GetCurrentDirectory() + "\\FIle3.txt";

                WriteFile(pathWrite, ReadFile(pathRead));
            });

            thread1.Start();
            thread2.Start();

            Console.WriteLine("End");
            Console.ReadKey();
        }

        static String ReadFile(String path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = File.OpenText(path))
                return reader.ReadToEnd();

        }

        static void WriteFile(String path, String text)
        {
            lock (SyncRoot)
                using (Stream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter writer = new StreamWriter(stream))
                        writer.Write(text);
        }
    }
}
