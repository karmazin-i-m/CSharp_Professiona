using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ITVDN_Task_2
{
    class Program
    {
        //private readonly List<String> links = new List<string>();
        static void Main(string[] args)
        {
            Console.Write("Введите ссылку: ");
            String url = Console.ReadLine();

            HttpClient client = new HttpClient();

            using (var stream = client.GetAsync(url))
            {
                String html = stream.Result.Content.ReadAsStringAsync().Result;

                //Console.WriteLine(html);

                Regex regex = new Regex(@"href=""\S+""");

                foreach (Match match in regex.Matches(html))
                {
                    Console.WriteLine(match.Value.Substring(6,match.Length-7));
                }

            }

            Console.WriteLine("end");

            Console.ReadKey();
        }
    }
}
