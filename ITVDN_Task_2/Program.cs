using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ITVDN_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Hello World.txt");

            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);

            Console.WriteLine("File was create!");

            byte[] array = new byte[100];

            for (int i = 0; i < 100; i++)
            {
                array[i] = (byte)(i*2);
            }
            stream.Write(array,0,100);

            Console.WriteLine("File was write!");

            stream.Close();

            stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(stream.ReadByte());
            }

            Console.WriteLine("File was read!");

            stream.Close();

            Console.ReadKey();
        }
    }
}
