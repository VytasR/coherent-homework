using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMX
{
    internal class Program
    {
        /*
         * This program demostrates the methods of DiagonalMatrix class.
         */
        static void Main(string[] args)
        {
            var diagonalMatrix1 = new DiagonalMatrix(11, 123456789, 33, -123456789);
            var diagonalMatrix2 = new DiagonalMatrix(-11, -123456789, -33, 123456789);
            var diagonalMatrix3 = Helper.Add(diagonalMatrix1, diagonalMatrix2);

            Console.WriteLine($"diagonalMatrix1:\n{diagonalMatrix1}");
            Console.WriteLine();
            Console.WriteLine($"diagonalMatrix2:\n{diagonalMatrix2}");
            Console.WriteLine();
            Console.WriteLine($"Helper.Add(diagonalMatrix1, diagonalMatrix2):\n{diagonalMatrix3}");
            Console.WriteLine();
            Console.WriteLine($"diagonalMatrix1.Equals(diagonalMatrix3): {diagonalMatrix1.Equals(diagonalMatrix3)}");
            Console.WriteLine($"diagonalMatrix1.Equals(diagonalMatrix1): {diagonalMatrix1.Equals(diagonalMatrix1)}");
            Console.WriteLine($"diagonalMatrix1.Track(): {diagonalMatrix1.Track()}");

            Console.ReadKey();
        }
    }
}
