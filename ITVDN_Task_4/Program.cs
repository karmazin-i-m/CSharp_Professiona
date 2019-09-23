using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ITVDN_Task_4
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            var american = new CultureInfo("en-US");

            using (FileStream fs = new FileStream("Reeceipt.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(GetString("Banana"));
                    sw.Write(GetString("Apple"));
                    sw.Write(GetString("Strawberry"));
                    sw.Write(GetString("Watermelow"));
                    sw.Write(GetString("Melow"));
                }
            }

            using (FileStream fs = new FileStream("Reeceipt.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string local = sr.ReadToEnd();
                    Console.WriteLine(sr.ReadToEnd().ToString("C", american));
                }
            }

            Console.ReadKey();
        }

        static string GetString(String name)
        {
            return $"{name} - {random.NextDouble()}, грн\n";
        }
    }


}
