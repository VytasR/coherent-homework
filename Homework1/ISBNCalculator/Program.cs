using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBNCalculator
{
    internal class Program
    {
        /*
         * This program reads first 9 digits of ISBN from console,
         * calculates the check digit and writes to console the full ISBN number.
         */

        // Reads first ISBN nine digits from console and returns it as a string.
        static string InputIsbnNineDigits()
        {
            Console.Write("\nPlease enter first 9 digits of ISBN (or enter Q to quit): ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
        }
    }
}
