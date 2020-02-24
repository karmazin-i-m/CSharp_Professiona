using ITVDN_Task_2.TwoParthFlag;
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
            TwoParthFlag.TwoParthFlag ukraine = new UkraineFlag();
            TwoParthFlag.TwoParthFlag poland = new PolandFlag();
            TwoParthFlag.TwoParthFlag haiti = new HaitiFlag();

            ukraine.Draw();
            Console.WriteLine();
            poland.Draw();
            Console.WriteLine();
            haiti.Draw();

            Console.ReadKey();
        }
    }
}
