using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace ITVDN_AdditionTask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("TelephoneBook.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                XmlWriter xml = XmlWriter.Create(fs);

                xml.WriteStartDocument();
                xml.WriteStartElement("MyContacts");
                xml.WriteStartElement("Contact");
                xml.WriteAttributeString("Name", "Illya");
                xml.WriteString("+3801234567");
                
                xml.WriteEndElement();
                xml.WriteEndElement();
                xml.WriteEndDocument();

                xml.Close();
            }

            Console.WriteLine("Program is ended...");
            Console.ReadKey();
        }
    }
}
