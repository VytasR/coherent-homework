﻿using System;
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

        public T this[int i, int j]
        {
            get
            {
                if (i <= 0 || i >= Size || j <= 0 || j >= Size)                
                {                    
                    throw new IndexOutOfRangeException("Index out of bounds of the diagonal matrix.");
                }
                else if (i == j)
                {
                    return _diagonalElements[i];
                }
                else
                {
                    return default(T);
                }
            }

            set
            {
                if (i <= 0 || i >= Size || j <= 0 || j >= Size)
                {
                    throw new IndexOutOfRangeException("Index out of bounds of the diagonal matrix.");
                }
                else if (i == j)
                {
                   _diagonalElements[i] = value;
                }
            }
        }
    }
}
