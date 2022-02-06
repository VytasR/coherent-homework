using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.MatrixEntities
{    
    internal class DiagonalMatrix<T>
    {   
        // This class models a diagonal square matrix.
                
        public event EventHandler<MatrixElementChangedArgs<T>> ElementChanged;

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

        public T this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Size || column < 0 || column >= Size)                
                {                    
                    throw new IndexOutOfRangeException("Index out of bounds of the diagonal matrix.");
                }
                else if (row == column)
                {
                    return _diagonalElements[row];
                }
                else
                {
                    return default(T);
                }
            }

            set
            {
                if (row < 0 || row >= Size || column < 0 || column >= Size)
                {
                    throw new IndexOutOfRangeException("Index out of bounds of the diagonal matrix.");
                }
                else if (row == column)
                {
                    var oldValue = _diagonalElements[row];
                    _diagonalElements[row] = value;
                    if (!oldValue.Equals(value))
                    {
                        ElementChanged?.Invoke(this, new MatrixElementChangedArgs<T>(row, column, oldValue, value));
                    }
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
