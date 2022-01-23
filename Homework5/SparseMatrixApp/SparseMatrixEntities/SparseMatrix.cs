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
    }
}
