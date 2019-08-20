using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ITVDN_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MonthList months = new MonthList();

            foreach(Month month in months)
            {
                System.Console.WriteLine($"Number: {month.Number}, Name: {month.Name}, Days: {month.Days}");
            }

            System.Console.WriteLine(new string('_', 80));

            foreach (Month month in months.GetMonthsOnDays(31))
            {
                System.Console.WriteLine($"Number: {month.Number}, Name: {month.Name}, Days: {month.Days}");
            }

            Console.ReadKey();
        }
    }
}

