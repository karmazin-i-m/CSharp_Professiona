using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazin magazin = new Magazin();
            magazin.Add(new Customer("Illya"), "apples");
            magazin.Add(new Customer("Illya"), "Banana");
            magazin.Add(new Customer("Illya"), "Pinaapple");
            magazin.Add(new Customer("Illya"), "Water");

            magazin.Add(new Customer("Lilia"), "apples");
            magazin.Add(new Customer("Lilia"), "Banana");
            magazin.Add(new Customer("Lilia"), "Pinaapple");

            magazin.ShowCustomers("Banana");
            magazin.ShowProducts(new Customer("Illya"));
            magazin.ShowCustomers("Water");

            Console.WriteLine(magazin);
            Console.ReadKey();
        }
    }
    class Magazin
    {
        private Dictionary<Customer, List<string>> magazin = new Dictionary<Customer, List<string>>();

        public void Add(Customer customer, string product)
        {
            if (!magazin.ContainsKey(customer))
            {
                magazin.Add(customer, new List<string>());
            }

            magazin.TryGetValue(customer, out List<string> list);
            list.Add(product);
        }

        public void ShowProducts(Customer customer)
        {
            if (!magazin.ContainsKey(customer))
            {
                Console.WriteLine("Такого покупателя не существует!");
                return;
            }
            magazin.TryGetValue(customer, out List<string> list);

            Console.WriteLine($"Покупатель {customer.Name} приобретал: ");
            foreach (var element in list)
            {
                Console.WriteLine("    " + element);
            }
        }

        public void ShowCustomers(string product)
        {
            foreach (KeyValuePair<Customer, List<string>> element in magazin)
            {
                foreach (var innerElement in element.Value)
                {
                    if (product == innerElement)
                    {
                        Console.WriteLine($"Покупатель {element.Key.Name} приобретал: {innerElement}");
                    }
                }
                Console.WriteLine(new string('-', 80));
            }
        }

        public override string ToString()
        {
            foreach (KeyValuePair<Customer, List<string>> element in magazin)
            {
                Console.WriteLine($"Покупатель {element.Key.Name} приобретал: ");
                foreach (var innerElement in element.Value)
                {
                    Console.WriteLine("    "+innerElement);
                }
                Console.WriteLine(new string('-', 80));
            }
            return "";
        }
    }

}
