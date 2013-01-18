using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            // Will Work
            // 2, 3, 1, 4, 2, 1, 4, 2, 4, 2, 2;
            // 6, 5, 1, 4, 2, 1, 6, 4, 2, 1, 5, 2;

            List<int> numbers = new List<int>();

            Console.WriteLine("TMR>Please enter a new sequence of number, separated by comma.");
            Console.Write("TMR>");
            string userinput = Console.ReadLine();
            string[] sequence = userinput.Split(new char[] { ',' });

            int oneNum;
            foreach (string s in sequence)
            {
                if (Int32.TryParse(s, out oneNum))
                {
                    numbers.Add(oneNum);
                }
            }
            
            TimeEnigmaResolver tmr = new TimeEnigmaResolver(numbers, true);

            Program.Main(null);
            Console.ReadKey();
        }
    }
}
