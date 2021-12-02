using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary2s
{
    internal class Program
    {

        // This method inputs from console first integer to define the range. 
        static int InputRangeStart()
        {
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
                if (AreTwoTernary2s(i))
                    intsWithTwoTernary2s.Add(i, ConvertDecimalToTernary(i));
            }
            return intsWithTwoTernary2s;
        }

        // This method inputs integer and checks if a number contains exactly two ternary 2's. Returns true if it does. 
        static bool AreTwoTernary2s(int number)
        {
            int quotient = Math.Abs(number);
            int twosCounter = 0;

            while (quotient != 0)
            {
                if (quotient % 3 == 2) twosCounter++;
                if (twosCounter > 2) break;
                quotient /= 3;
            }

            return twosCounter == 2;            
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
        }
    }
}
