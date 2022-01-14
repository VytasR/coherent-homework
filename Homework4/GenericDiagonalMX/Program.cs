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
        static void Main(string[] args)
        {
            var diagonalFloatMatrix1 = new DiagonalMatrix<double>(4);
            diagonalFloatMatrix1.ElementChanged += PrintUpdate;
            diagonalFloatMatrix1[0, 0] = 15.8;
            diagonalFloatMatrix1[0, 0] = 15.8;
            diagonalFloatMatrix1[0, 0] = 16.78;
            diagonalFloatMatrix1[1, 1] = 0.56;
            Console.WriteLine($"Value at index 0, 2 = {diagonalFloatMatrix1[0, 2]}");            

        }

        static void PrintUpdate(int i, int j, double oldValue, double newValue)
        {
            Console.WriteLine($"Element index = {i}, {j}; old value = {oldValue}; newValue = {newValue}");
        }
    }
}
