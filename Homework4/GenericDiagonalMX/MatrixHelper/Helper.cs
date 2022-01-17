using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.MatrixEntities
{
    public delegate T AdditionMethod<T>(T elementOne, T elementTwo);

    internal static class Helper<T>
    {
        // This class contains methods for operation with diagonal matrices.

        // Inputs two diagonal matrices and addition method for their elements.
        // Adds elements of the matrices and returns a new matrix. Returns null if both matrices are null.
        // If only one matrix is null then returns the other matrix. If dimensions of input matrices do not match,
        // the new matrix is filled with elements of the bigger matrix where elements of from the smaller matrix are absent.  
        public static DiagonalMatrix<T> Add(DiagonalMatrix<T> thisMatrix, DiagonalMatrix<T> anotherMatrix, AdditionMethod<T> additionMethod)
        {
            if (thisMatrix is null && anotherMatrix is null)
            {
                return null;
            }

            if (thisMatrix is null)
            {
                return anotherMatrix.Copy();
            }

            if (anotherMatrix is null)
            {
                return thisMatrix.Copy();
            }
                        
            var newMatrixSize = thisMatrix.Size > anotherMatrix.Size ? thisMatrix.Size : anotherMatrix.Size;
            var result = new DiagonalMatrix<T>(newMatrixSize);

            for (int i = 0; i < newMatrixSize; i++)
            {
                if (i < thisMatrix.Size && i < anotherMatrix.Size)
                {
                    result[i, i] = additionMethod(thisMatrix[i, i], anotherMatrix[i, i]);
                }
                else if (i >= thisMatrix.Size)
                {
                    result[i, i] = anotherMatrix[i, i];
                }
                else if (i >= anotherMatrix.Size)
                {
                    result[i, i] = thisMatrix[i, i];
                }
            }

            return result;
        }
    }
}
