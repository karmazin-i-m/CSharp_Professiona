using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ITVDN_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("TelephoneBook.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(fs);
                XmlElement xml = xmlDocument.DocumentElement;
                Console.WriteLine($"Elemen name {xml.Name}:");
                if (xml.HasAttributes == true)
                {
                    Console.WriteLine($"    Atributes:");
                    foreach (XmlAttribute item in xml.Attributes)
                    {
                        Console.WriteLine($"{item.Name} : {item.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Has not atributes");
                }

                if (xml.Value != null)
                    Console.WriteLine($"Element valur : {xml.Value}");
                else
                    Console.WriteLine("Has not value");

                if (xml.HasChildNodes == true)
                {
                    ShowNodes(xml.ChildNodes);
                }
                else
                {
                    Console.WriteLine("Has not ChildNodes");
                }
            }

            Console.WriteLine("Program finished");
            Console.ReadKey();
        }

        private static void ShowNodes(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine($"    Elemen name {node.Name}:");
                if (node.Attributes != null)
                {
                    Console.WriteLine($"    Atributes:");
                    foreach (XmlAttribute item in node.Attributes)
                    {
                        Console.WriteLine($"        {item.Name} : {item.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("     Has not atributes");
                }

                if (node.Value != null)
                    Console.WriteLine($"    Element value : {node.Value}");
                else
                    Console.WriteLine(" Has not value");

                if (node.HasChildNodes == true)
                {
                    ShowNodes(node.ChildNodes);
                    Console.WriteLine(new string('-',80));
                }
            }
        }
    }
}
