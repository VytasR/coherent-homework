using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            int numberOfRows = 100;
            int numberOfColumns = 200;
            SortedList<int, int>[] _items = new SortedList<int, int>[numberOfRows];
            for (int row = 0; row < numberOfRows; row++)
            {
                _items[row] = new SortedList<int, int>();
            }
            _items[5].Add(10, 1256);
            _items[5].Add(55, -899);
            _items[5].Add(37, 59845);

            for (int row = 0; row < numberOfRows; row++)
            {
                foreach (var item in _items[row])
                {
                    Console.WriteLine($"Row {row}, Column {item.Key}, Value {item.Value}");
                }
            }

        }
    }
}
