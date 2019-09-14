using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ITVDN_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("TelephoneBook.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                XmlDocument document = new XmlDocument();
                document.Load(fs);

                XmlElement xml = document.DocumentElement;

                foreach (XmlNode item in xml.ChildNodes)
                {
                    Console.WriteLine(item.FirstChild.Value);
                }


            }
            Console.WriteLine("Program ended");
            Console.ReadKey();
        }
    }
}
