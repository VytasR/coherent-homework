using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.DiagonalMatrixItems
{
    internal class DiagonalMatrix<T>
    {
        private T[] _diagonalElements;
        public int Size { get; }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Invalid diagonal matrix size.");
            }
            else
            {
                Size = size;
                _diagonalElements = new T[Size];
            }
        }
    }
}
