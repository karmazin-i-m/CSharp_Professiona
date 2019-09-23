using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace ITVDN_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(@"HelloWorld.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write("Бык тупогуб, на тупогубенкий, у в быка губа бела была тупа");
                }
            }

            using (FileStream fs = new FileStream(@"HelloWorld.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(Regex.Replace(sr.ReadToEnd(), @"в(\w*)|на(\w*)|под(\w*)", "ГАВ"));
                }
            }

            Console.ReadKey();
        }
    }
}
