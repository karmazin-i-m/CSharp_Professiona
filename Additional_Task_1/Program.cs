using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Additional_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            Console.WriteLine($"FullName: " + directory.FullName);
            Console.WriteLine($"Name: " + directory.Name);
            Console.WriteLine($"Parent: " + directory.Parent);
            Console.WriteLine($"Attributes: " + directory.Attributes);
            Console.WriteLine($"CreationTime: " + directory.CreationTime);
            Console.WriteLine($"CreationTimeUtc: " + directory.CreationTimeUtc);
            Console.WriteLine($"Extension: " + directory.Extension);
            Console.WriteLine($"LastAccessTime: " + directory.LastAccessTime);
            Console.WriteLine($"LastWriteTime: " + directory.LastWriteTime);
            Console.WriteLine($"Exists: " + directory.Exists);
            Console.WriteLine($"Root: " + directory.Root);

            Console.WriteLine(new string('-', 80));

            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory(@"C:\Users\CallCenter 3\Source\Repos\CSharp_Professional\Additional_Task_1\Folder_" + i);
            }

            Console.WriteLine("Directories was create");
            Console.ReadKey();

            for (int i = 0; i < 100; i++)
            {
                Directory.Delete(@"C:\Users\CallCenter 3\Source\Repos\CSharp_Professional\Additional_Task_1\Folder_" + i, true);
            }
            
            Console.WriteLine("Directories was delete");

            Console.ReadKey();
        }
    }
}
