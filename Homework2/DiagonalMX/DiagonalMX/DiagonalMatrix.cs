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
    }
}
