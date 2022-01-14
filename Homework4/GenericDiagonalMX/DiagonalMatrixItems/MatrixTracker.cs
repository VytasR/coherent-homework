using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.DiagonalMatrixItems
{
    internal class MatrixTracker<T>
    {
        private DiagonalMatrix<T> _diagonalMatrix;
        private int _rowIndexOfLastChange;
        private int _columnIndexOfLastChange;
        private T _elementValueBeforeLastChange;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            _diagonalMatrix = diagonalMatrix;
            _diagonalMatrix.ElementChanged += Update;
        }

        private void Update(int rowIndex, int columnIndex, T oldValue, T newValue)
        {
            _rowIndexOfLastChange = rowIndex;
            _columnIndexOfLastChange = columnIndex;
            _elementValueBeforeLastChange = oldValue;
        }

        public void Undo()
        {
            _diagonalMatrix[_rowIndexOfLastChange, _columnIndexOfLastChange] = _elementValueBeforeLastChange;
        }
    }
}
