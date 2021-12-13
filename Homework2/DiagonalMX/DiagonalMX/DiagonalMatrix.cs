using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMX
{
    internal class DiagonalMatrix
    {
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
                if ((i == j) && (i >= 0) && (i < Size) && (j >= 0) && (j < Size))
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
                if ((i == j) && (i >= 0) && (i < Size) && (j >= 0) && (j < Size))
                {
                    _diagonalElements[i] = value;
                }
            }
        }

        public int Track()
        {
            return _diagonalElements.Sum();
        }

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

        // Returns a string of elements on the diagonal, separated by comma. 
        public override string ToString()
        {
            if (Size == 0)
            {
                return String.Empty;
            }
            else
            {
                var diagonal = new StringBuilder();
                for (int i = 0; i < Size; i++)
                {
                    diagonal.Append(_diagonalElements[i]);
                    if (i < (Size - 1))
                    {
                        diagonal.Append(", ");
                    }
                }
                return diagonal.ToString();
            }            
        }
    }
}
