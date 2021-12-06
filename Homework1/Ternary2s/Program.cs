using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary2s
{
    internal class Program
    {
        /*
         * This program reads integer range limits from console and
         * outputs to console the numbers with exactly two ternary 2's 
         * from the defined range.
         */

        // This method request user if they want to continue using the app. Returns true if they do.
        static bool InputEndApp()
        {
            Console.WriteLine("-------------------------------");
            Console.Write("Press 'q' and Enter to close the app, or press any other key and Enter to continue: ");
            return (Console.ReadLine() == "q");
        }

        // This method inputs from console last integer to define the range
        static int InputRangeEnd()
        {
            Console.Write("Please enter last integer in the range: ");
            return Int32.Parse(Console.ReadLine());
        }

        // This method inputs from console first integer to define the range. 
        static int InputRangeStart()
        {
            Console.WriteLine("\n");
            Console.Write("Please enter first integer in the range: ");
            return Int32.Parse(Console.ReadLine());
        }

        // This method inputs a dictionary with integer as a key and its ternary representation in string as a value
        // and outputs it to console.
        static void OutputIntsWithTernary (Dictionary<int, string> intsWithTwoTernary2s)
        {
            foreach (KeyValuePair<int, string> keyValuePair in intsWithTwoTernary2s)
            {
                Console.WriteLine($"Int: {keyValuePair.Key}, ternary: {keyValuePair.Value}");
            }
        }

        // This method inputs integer range limits and finds integers with exactly two ternary 2's.
        // Returns a dictionary with integer as a key and its ternary representation in string as a value.
        static Dictionary<int, string> FindTwoTernary2s(int rangeStart, int rangeEnd)
        {
            var intsWithTwoTernary2s = new Dictionary<int, string>();
            
            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                string ternary = ConvertDecimalToTernary(i);
                var sum2s = 0;

                // Check for two ternary 2's
                foreach (char c in ternary)
                {
                    if (c == '2') sum2s++;
                    if (sum2s > 2) break;
                }

                // Add int and ternary representation to dictionary
                if (sum2s == 2)
                {
                    intsWithTwoTernary2s.Add(i, ternary);
                }                
            }
            return intsWithTwoTernary2s;
        }

        // This method inputs integer and converts it to ternary numeral system. Returns a string.
        static string ConvertDecimalToTernary (int number)
        {
            if (number == 0) return "0";

            var ternaryRepresentation = new StringBuilder(5);
            int quotient = Math.Abs(number);

            while (quotient != 0)
            {
                ternaryRepresentation.Insert(0, Convert.ToString(quotient % 3));
                quotient /= 3;
            }

            if (number < 0) ternaryRepresentation.Insert(0, "-");

            return ternaryRepresentation.ToString();
        }

        static void Main(string[] args)
        {
            bool endApp = false;

            while (!endApp)
            {
                int rangeStart = InputRangeStart();
                int rangeEnd = InputRangeEnd();

                var intsWithTwoTernary2s = FindTwoTernary2s(rangeStart, rangeEnd);

                OutputIntsWithTernary(intsWithTwoTernary2s);

                endApp = InputEndApp();                
            }            
        }
    }
}
