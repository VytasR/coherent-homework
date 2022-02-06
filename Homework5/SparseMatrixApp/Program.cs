using SparseMatrixApp.SparseMatrixEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp
{
    internal class Program
    {
        // This program demonstrates usage of SparseMatrix class

        static void Main(string[] args)
        {
            var matrix1 = new SparseMatrix(3, 4);
            matrix1[0, 3] = -985;
            matrix1[2, 3] = -985;
            matrix1[0, 2] = -985;
            matrix1[1, 2] = 3;
            matrix1[2, 1] = 586;
            matrix1[0, 3] = 0;
            matrix1[1, 0] = 555;
            Console.WriteLine($"Matrix items:\n{matrix1}");

            Console.WriteLine();
            Console.WriteLine($"There are {matrix1.GetCount(0)} elements with value 0");
            Console.WriteLine($"There are {matrix1.GetCount(-985)} elements with value -985");
            Console.WriteLine($"There are {matrix1.GetCount(-1)} elements with value -1");

            Console.WriteLine();
            Console.WriteLine("Non zero items in matrix: ");
            foreach (var item in matrix1.GetNonZeroElements())
            {
                Console.WriteLine($"({item.Item1}, {item.Item2}) = {item.Item3}");
            }

            Console.WriteLine();
            Console.WriteLine("List of all matrix items: ");
            int itemCount = 0;
            foreach (var item in matrix1)
            {
                Console.WriteLine($"item {itemCount} = {item}");
                itemCount++;
            }
        }
    }
}
