using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ITVDN_AdditionTask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите логин для проверки: ");

                string login = Console.ReadLine();

                if (login == "exit")
                    return;

                if (Regex.IsMatch(login, @"^[a-z][. - a-z 0-9]{3,20}@[a-z]+[.][a-z]+"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Логин валиден");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Логин не валиден");
                    Console.ResetColor();
                }
            }
        }
    }
}
