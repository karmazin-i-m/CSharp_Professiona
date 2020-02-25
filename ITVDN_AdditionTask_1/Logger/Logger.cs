using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_AdditionTask_1.Logging
{
    static class Logger
    {
        private static readonly Object _syncRoot = new Object();

        public static void Information(String log) 
        {
            lock (_syncRoot)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[Information]");
                Console.Write(" ");
                Console.ResetColor();
                Console.WriteLine(log);
                Console.WriteLine("/=================================================================/");
                Console.WriteLine();
            }
            
        }  
    }
}
