using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_2.TwoParthFlag
{
    class UkraineFlag : TwoParthFlag
    {
        protected override void DrawBottomParth()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.DrawTopParth();
        }

        protected override void DrawTopParth()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.DrawTopParth();
        }
    }
}
