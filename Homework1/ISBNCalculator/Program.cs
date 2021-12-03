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

        // Inputs a string of ISBN first nine digits, calculates check digit and returns it as a string.
        static string CalculateIsbnCheckDigit(string isbnNineDigits)
        {
            // Calculate check sum for first 9 digits.
            int checkSumOfNineDigits = 0;
            for (int i = 0; i < isbnNineDigits.Length; i++)
                checkSumOfNineDigits += ((int)Char.GetNumericValue(isbnNineDigits[i])) * (10 - i);

            // Find next multiple of 11 (if not already a multiple).
            int nextMultipleofEleven = checkSumOfNineDigits;
            while (nextMultipleofEleven % 11 != 0)
                nextMultipleofEleven++;

            int checkDigit = nextMultipleofEleven - checkSumOfNineDigits;

            return checkDigit == 10 ? "X" : checkDigit.ToString();
        }

        // Inputs ISBN first nine digits, check digit and writes full ISBN number to console.
        static void OutputIsbn(string isbnNineDigits, string checkDigit)
        {
            Console.WriteLine($"Calculated ISBN is {isbnNineDigits}-{checkDigit}");
        }

        static void Main(string[] args)
        {
            string isbnNineDigits = InputIsbnNineDigits();

            string checkDigit = CalculateIsbnCheckDigit(isbnNineDigits);

            OutputIsbn(isbnNineDigits, checkDigit);

            Console.ReadKey();
        }
    }
}
