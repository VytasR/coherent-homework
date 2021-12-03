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

        // Finds index of smallest (leftmost if there are several) element of the array.
        public int FindIndexOfSmallest(int[] array)
        {
            int indexOfSmallest = 0;

            for (int index = 1; index < array.Length; index++)
            {
                if (array[index] < array[indexOfSmallest])
                    indexOfSmallest = index;
            }

            return indexOfSmallest;
        }

        // Finds index of largest (rightmost if there are several) element of the array.
        public int FindIndexOfLargest(int[] array)
        {
            int indexOfLargest = 0;

            for (int index = 1; index < array.Length; index++)
            {
                if (array[index] >= array[indexOfLargest])
                    indexOfLargest = index;
            }

            return indexOfLargest;
        }

        // Calculates the sum of the array elements located between
        // the smallest element in the array (the leftmost element if there are several)
        // and the largest element (the rightmost element if there are several)
        public int SumBetweenSmallestAndLargest(int[] array)
        {
            var indexOfSmallest = FindIndexOfSmallest(array);
            var indexOfLargest = FindIndexOfLargest(array);
            var sum = 0;

            if (indexOfSmallest < indexOfLargest)
                for (int index = indexOfSmallest; index <= indexOfLargest; index++)
                    sum += array[index];
            else
                for (int index = indexOfLargest; index <= indexOfSmallest; index++)
                    sum += array[index];

            return sum;
        }

        static void Main(string[] args)
        {
        }
    }
}
