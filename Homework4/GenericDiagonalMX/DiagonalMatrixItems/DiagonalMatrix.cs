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
    }
}
