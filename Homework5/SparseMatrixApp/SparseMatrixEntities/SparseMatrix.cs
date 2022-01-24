using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp.SparseMatrixEntities
{
    internal class SparseMatrix : IEnumerable<int>
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
                _items = new SortedList<Coordinates, int>(new ByColumnFirst());
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
                return 0;                
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

        // Returns matrix elements in a multi line string.
        public override string ToString()
        {
            var result = new StringBuilder();
            for (int row = 0; row < NumberOfRows; row++)
            {
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    result.Append(this[row, column]);
                    if (column < NumberOfColumns - 1)
                    {
                        result.Append("\t");
                    }
                }
                if (row < NumberOfRows - 1)
                {
                    result.Append("\n");
                }
            }
            return result.ToString();
        }

        // Returns all elements of sparse matrix (including zero ones) line by line.
        public IEnumerator<int> GetEnumerator()
        {
            for (int row = 0; row < NumberOfRows; row++)
            {
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    yield return this[row, column];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Returns a set of touples (row, column, element value) ordered by columns then by rows.
        public IEnumerable<(int, int, int)> GetNonZeroElements()
        {
            foreach (var item in _items)
            {
                yield return (item.Key.Row, item.Key.Column, item.Value);
            }
        }

        // Returns the number of times an element occurs in matrix.
        public int GetCount(int value)
        {
            if (value == 0)
            {
                return NumberOfRows * NumberOfColumns - _items.Count;
            }
            
            int count = 0;            
            foreach (var item in _items)
            {
                if (item.Value == value)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
