using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary2s
{
    internal class Program
    {

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
