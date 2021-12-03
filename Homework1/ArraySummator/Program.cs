using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySummator
{
    internal class Program
    {
        /*
         * This application asks the user to enter a numeric array (of int type). Then calculates and outputs 
         * the sum of the array elements located between the smallest element in the array (the leftmost element if there are several)
         * and the largest element (the rightmost element if there are several).
         */

        // Reads a single-dimensional array of integers from console. Array must contain at least two elements.
        static int[] InputIntArray()
        {
            var arrayLength = 0;
            var isArrayLengthAtLeastTwo = false;

            while (!isArrayLengthAtLeastTwo)
            {
                Console.Write("Please enter array length (min 2): ");
                arrayLength = Int32.Parse(Console.ReadLine());

                if (arrayLength >= 2)
                    isArrayLengthAtLeastTwo = true;
                else
                    Console.WriteLine("Array size error.");
            }

            int[] intArray = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write($"Please enter array element No. {i}: ");
                intArray[i] = Int32.Parse(Console.ReadLine());
            }
            return intArray;
        }

        static void Main(string[] args)
        {
        }
    }
}
