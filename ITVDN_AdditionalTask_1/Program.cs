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
            var query = PredecateOnYields<double>( (i) => Math.Pow(i, 2), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

            foreach(var item in query)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static IEnumerable<T> PredecateOnYields<T>(Func<T,T> func, params T[] items)
        {
            foreach (var element in items)
            {
                yield return func(element);
            }
            yield break;
        }
    }
}
