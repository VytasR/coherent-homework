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
        private int Size { get; }

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
    }
}
