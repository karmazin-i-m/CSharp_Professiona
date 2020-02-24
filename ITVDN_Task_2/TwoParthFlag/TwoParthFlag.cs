using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_Task_2.TwoParthFlag
{
    abstract class TwoParthFlag
    {
        public void Draw()
        {
            DrawTopParth();
            DrawBottomParth();
        }

        protected virtual void DrawTopParth()
        {
            Console.WriteLine(new String('X', 80));
            Console.WriteLine(new String('X', 80));
            Console.WriteLine(new String('X', 80));
            Console.WriteLine(new String('X', 80));
        }
        protected virtual void DrawBottomParth()
        {
            Console.WriteLine(new String('X', 80));
            Console.WriteLine(new String('X', 80));
            Console.WriteLine(new String('X', 80));
            Console.WriteLine(new String('X', 80));
        }
    }
}
