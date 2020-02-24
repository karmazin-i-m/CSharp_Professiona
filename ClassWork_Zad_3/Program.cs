using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_Zad_3
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayable curentStrategy;

            while (true)
            {
                Console.Write("Выберети желаемый метод: ");

                switch (Console.ReadLine())
                {
                    case "D":
                        curentStrategy = new DiagonalStrategy();
                        curentStrategy.MakeMove();
                        break;
                    case "V":
                        curentStrategy = new DirectSrategy();
                        curentStrategy.MakeMove();
                        break;
                    case "G":
                        curentStrategy = new DirectSrategy();
                        curentStrategy.MakeMove();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }
    }

    interface IPlayable
    {
        void MakeMove();
    }

    class DirectSrategy : IPlayable
    {
        public void MakeMove()
        {
            Console.WriteLine("Ходить фигурами по вертикали и горизонтали");
        }
    }

    class DiagonalStrategy : IPlayable
    {
        public void MakeMove()
        {
            Console.WriteLine("Ходить фигурами по диагонали");
        }
    }
}
