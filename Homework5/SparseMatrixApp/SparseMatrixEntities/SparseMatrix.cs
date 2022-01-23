using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp.SparseMatrixEntities
{
    internal class SparseMatrix
    {
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private SortedList<Coordinates, int> _items;

        public SparseMatrix(int numberOfRows, int numberOfColumns)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
            {
                throw new ArgumentException("Invalid diagonal matrix size. Must contain positive number of rows and columns.");
            }
            else
            {
                NumberOfRows = numberOfRows;
                NumberOfColumns = numberOfColumns;
                _items = new SortedList<Coordinates, int>(new ByCoordinates());
            }
        }

        public int this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= NumberOfRows || column < 0 || column >= NumberOfColumns)
                {
                    throw new IndexOutOfRangeException("Index out of bounds of the matrix.");
                }

                var coordinates = new Coordinates(row, column);
                if (_items.ContainsKey(coordinates))
                {
                    return _items[coordinates];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (row < 0 || row >= NumberOfRows || column < 0 || column >= NumberOfColumns)
                {
                    throw new IndexOutOfRangeException("Index out of bounds of the matrix.");
                }

                var coordinates = new Coordinates(row, column);
                if (_items.ContainsKey(coordinates))
                {
                    if (value == 0)
                    {
                        _items.Remove(coordinates);
                    }
                    else
                    {
                        _items[coordinates] = value;
                    }
                }
                else
                {
                    if (value != 0)
                    {
                        _items.Add(coordinates, value);
                    }
                }
            }
        }
    }
}
