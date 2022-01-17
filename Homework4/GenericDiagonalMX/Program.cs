using GenericDiagonalMX.DiagonalMatrixItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX
{
    internal class Program
    {
        // This program demonstrates methods of generic DiagonalMatrix class.

        static void Main(string[] args)
        {
            var diagonalMatrix1 = new DiagonalMatrix<double>(4);
            var matrixTracker1 = new MatrixTracker<double>(diagonalMatrix1);            
            diagonalMatrix1[0, 0] = 15.8;                       
            diagonalMatrix1[1, 1] = 0.56;
            diagonalMatrix1[2, 2] = -27.3;
            diagonalMatrix1[3, 3] = 34;
            Console.WriteLine("Elements of matrix1 before Undo() is applied:");
            PrintDiagonalMatrixElements<double>(diagonalMatrix1);
            matrixTracker1.Undo();
            Console.WriteLine("\nElements of matrix1 after Undo() is applied:");
            PrintDiagonalMatrixElements<double>(diagonalMatrix1);

            var diagonalMatrix2 = new DiagonalMatrix<double>(5);
            diagonalMatrix2[0, 0] = 1.2;
            diagonalMatrix2[1, 1] = 3.44;
            diagonalMatrix2[2, 2] = 7.3;
            diagonalMatrix2[3, 3] = 87;
            diagonalMatrix2[4, 4] = -35;
            Console.WriteLine("\nElements of matrix2:");
            PrintDiagonalMatrixElements<double>(diagonalMatrix2);

            double AddTwoDoubles(double x, double y) => x + y;
            var diagonalMatrix3 = Helper<double>.Add(diagonalMatrix1, diagonalMatrix2, AddTwoDoubles);

            Console.WriteLine("\nElements of matrix1 + matrix2:");
            PrintDiagonalMatrixElements<double>(diagonalMatrix3);
        }

        // Prints elements from the main diagonal of the matrix.
        static void PrintDiagonalMatrixElements<T>(DiagonalMatrix<T> diagonalMatrix)
        {
            for (int i = 0; i < diagonalMatrix.Size; i++)
            {                
                Console.Write($"{diagonalMatrix[i, i]}\t");
            }
            Console.WriteLine();
        }
    }
}
