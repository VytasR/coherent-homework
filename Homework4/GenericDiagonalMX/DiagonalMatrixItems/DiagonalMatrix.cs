using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.DiagonalMatrixItems
{
    public delegate void ElementChangedEventHandler<T>(int i, int j, T oldValue, T newValue);

    internal class DiagonalMatrix<T>
    {   
        // This class models a diagonal square matrix.

        public event ElementChangedEventHandler<T> ElementChanged;

        private T[] _diagonalElements;
        public int Size { get; }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Invalid diagonal matrix size. Must be a non negative integer.");
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
                if (i < 0 || i >= Size || j < 0 || j >= Size)                
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
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                {
                    throw new IndexOutOfRangeException("Index out of bounds of the diagonal matrix.");
                }
                else if (i == j)
                {
                    if (!_diagonalElements[i].Equals(value))
                    {
                        ElementChanged?.Invoke(i, j, _diagonalElements[i], value);
                    }                    
                   _diagonalElements[i] = value;
                }
            }
        }

        // Returns a copy of this matrix.
        public DiagonalMatrix<T> Copy()
        {
            var result = new DiagonalMatrix<T>(Size);
            for (int i = 0; i < Size; i++)
            {
                result[i, i] = this[i, i];
            }

            return result;
        }
    }
}
