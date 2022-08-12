using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_AdditionalTask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> sortedList = new SortedList<int, string>();

            sortedList.Add(7, "Z");
            sortedList.Add(6, "D");
            sortedList.Add(5, "F");
            sortedList.Add(4, "E");
            sortedList.Add(8, "A");
            sortedList.Add(3, "T");
            sortedList.Add(2, "U");
            sortedList.Add(1, "W");
            sortedList.Add(0, "G");

            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }

            var quary = sortedList.OrderByDescending(t => t.Value).Select(t => t);

            foreach (var item in quary)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
