using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary dictionary = new OrderedDictionary();

            dictionary.CheckedAdd(1, "One");
            dictionary.CheckedAdd(1, "One");
            dictionary.CheckedAdd(2, "Two");
            dictionary.CheckedAdd(3, "Three");
            dictionary.CheckedAdd(4, "Four");

            foreach (DictionaryEntry element in dictionary)
            {
                Console.WriteLine($"Element key: {element.Key}, value: {element.Value}");
            }

            Console.ReadKey();
        }
    }

    static class Extension
    {
        public static void CheckedAdd(this OrderedDictionary dictionary, object key, object value)
        {
            if (dictionary.Contains(key))
            {
                Console.WriteLine("Значение с таким ключем уже существует!");
                return;
            }

            dictionary.Add(key, value);
        }
    }
}
