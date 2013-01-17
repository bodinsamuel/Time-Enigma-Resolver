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
            // Fonctionnera
            int?[] numbers = new int?[]{ 2, 3, 1, 4, 2, 1, 4, 2, 4, 2, 2 };
            //int?[] numbers = new int?[] { 6, 5, 1, 4, 2, 1, 6, 4, 2, 1, 5, 2 };
            //int?[] numbers = new int?[] { 5, 3, 3, 6, 3, 4, 3, 1, 6, 3, 3, 4, 1 };
            //int?[] numbers = new int?[] { 1, 4, 2, 3, 4, 2, 3, 3 };
            //int?[] numbers = new int?[] { 1, 2, 4, 3, 6, 2, 4, 1, 5, 2, 1, 4, 5 };

            // Ne marchera pas
            //int?[] numbers = new int?[] { 1, 2, 4, 3, 6, 2, 4, 9, 9, 2, 1, 4, 5 };

            TimeEnigmaResolver tmr = new TimeEnigmaResolver(numbers,true);
            Console.Read();
        }
    }
}
