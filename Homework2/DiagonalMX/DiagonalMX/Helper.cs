using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMX
{
    internal static class Helper
    {
        /*
         This class contains methods for operations with matrices
         */
                       
        // Inputs two diagonal matrices. Adds elements of the matrices and returns a new diagonal matrix.
        // Returns null if both matrices are null. If only one is null then returns the other matrix.
        // If the dimensions of the matrix do not match, the smaller matrix is padded with zeros.
        public static DiagonalMatrix Add(this DiagonalMatrix thisMatrix, DiagonalMatrix anotherMatrix)
        {            
            if (thisMatrix == null && anotherMatrix == null)
            {
                return null;
            }
            
            int newMatrixSize;

            if (anotherMatrix == null)
            {
                newMatrixSize = thisMatrix.Size;
                anotherMatrix = new DiagonalMatrix();
            }
            else if (thisMatrix == null)
            {
                newMatrixSize = anotherMatrix.Size;
                thisMatrix = new DiagonalMatrix();
            }
            else
            {
                newMatrixSize = thisMatrix.Size > anotherMatrix.Size ? thisMatrix.Size : anotherMatrix.Size;
            }
            
            int[] newMatrixElements = new int[newMatrixSize];

            for (int i = 0; i < newMatrixSize; i++)
            {
                newMatrixElements[i] = thisMatrix[i, i] + anotherMatrix[i, i];
            }

            return new DiagonalMatrix(newMatrixElements);
        }
    }
}
