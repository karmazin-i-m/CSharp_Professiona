using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ITVDN_Task_3
{
    class Program
    {
        static List<string> ToZipPathes = new List<string>();
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(@"C:\");

            var innerDirectoryInfo = info.GetDirectories();
            var innerFileInfo = info.GetFiles();

            Console.WriteLine("Программа работает...");

            FileSearch(innerDirectoryInfo, "Hello World.txt");
            FileZip();
            FileDeZip();

            foreach (var element in ToZipPathes)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Программа завершила выполнеие!");

            Console.ReadKey();
        }

        public static void FileSearch(DirectoryInfo[] directories, string str)
        {
            if (directories.Length != 0)
            {
                for (int i = 0; i < directories.Length; i++)
                {
                    try
                    {
                        FileSearch(directories[i].GetDirectories(), str);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }

                    foreach (var element in directories[i].GetFiles())
                    {
                        if (element.Name == str)
                            ToZipPathes.Add(element.FullName);
                    }
                }
            }
            else
                return;
        }

        public static void FileZip()
        {
            for (int i = 0; i < ToZipPathes.Count; i++)
            {
                FileInfo info = new FileInfo(Directory.GetCurrentDirectory() + @"\HelloWorld" + i + ".gz");
                if (info.Exists)
                {
                    using (FileStream stream = new FileStream(info.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                    {
                        using (FileStream deZippedFile = File.Create(Directory.GetCurrentDirectory() + @"\HelloWorld" + i + ".txt"))
                        {
                            GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
                            gZipStream.CopyTo(deZippedFile);
                        }
                    }
                }
                
            }

        }

        public static void FileDeZip()
        {
            for (int i = 0; i < ToZipPathes.Count; i++)
            {
                using (FileStream stream = new FileStream(ToZipPathes[i], FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (FileStream zippedFile = File.Create(Directory.GetCurrentDirectory() + @"\HelloWorld" + i + ".gz"))
                    {
                        GZipStream gZipStream = new GZipStream(zippedFile, CompressionMode.Compress);
                        stream.CopyTo(gZipStream);
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                        stream, stream.Length.ToString(), zippedFile.Length.ToString());
                    }
                }
            }
        }
    }
}
