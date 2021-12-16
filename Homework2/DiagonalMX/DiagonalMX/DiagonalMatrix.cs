using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMX
{
    internal class DiagonalMatrix
    {
        /*
         * This class models a diagonal square matrix.
         */
        private int[] _diagonalElements;
        public int Size { get; }

        public DiagonalMatrix (params int[] list)
        {            
            if (list != null)
            {
                int matrixSize = list.Length;
                _diagonalElements = new int[matrixSize];
                Array.Copy(list, _diagonalElements, matrixSize);
                Size = matrixSize;
            }
            else
            {
                _diagonalElements = new int[0];
                Size = 0;
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i == j && i >= 0 && i < Size && j >= 0 && j < Size)
                {                    
                    return _diagonalElements[i];
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (i == j && i >= 0 && i < Size && j >= 0 && j < Size)
                {
                    _diagonalElements[i] = value;
                }
            }
        }

        // Returns the sum of the elements of the matrix located on the main diagonal.
        public int Track()
        {
            return _diagonalElements.Sum();
        }

        // Returns true if sizes of matrices match and the corresponding elements on the diagonal coincide.
        public override bool Equals(object obj)
        {           
            var otherMatrix = obj as DiagonalMatrix;

            if (otherMatrix == null)
            {
                return false;
            } 

            if (otherMatrix.Size == this.Size)
            {
                bool areElementsEqual = true;
                for (int i = 0; i < this.Size; i++)
                {
                    if (otherMatrix._diagonalElements[i] != this._diagonalElements[i])
                    {
                        areElementsEqual = false;
                        break;
                    }
                }
                return areElementsEqual;
            }

            return false;
        }

        // Returns matrix elements in a multi line string.
        public override string ToString()
        {
            if (Size == 0)
            {
                return String.Empty;
            }
            
            var result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result.Append(this[i, j]);
                    if (j < (Size - 1))
                    {
                        if (this[i, j] >= -999999 && this[i, j] <= 9999999)
                        {
                            result.Append("\t\t");
                        }
                        else
                        {
                            result.Append("\t");
                        }                        
                    }
                }
                if (i < (Size - 1))
                {
                    result.Append("\n");
                }
            }

            return result.ToString();
        }
    }
}
