﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.DiagonalMatrixItems
{
    internal class MatrixTracker<T>
    {
        // This class records last change in diagonal matrix and can roll it back.

        private DiagonalMatrix<T> _diagonalMatrix;
        private int _rowIndexOfLastChange;
        private int _columnIndexOfLastChange;
        private T _oldValue;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            _diagonalMatrix = diagonalMatrix;
            _diagonalMatrix.ElementChanged += StoreOldValue;
        }

        // Stores index and old element value for last change in diagonal matrix.
        private void StoreOldValue(int rowIndex, int columnIndex, T oldValue, T newValue)
        {
            _rowIndexOfLastChange = rowIndex;
            _columnIndexOfLastChange = columnIndex;
            _oldValue = oldValue;
        }

        // Rolls back last change in diagonal matrix.
        public void Undo()
        {
            _diagonalMatrix[_rowIndexOfLastChange, _columnIndexOfLastChange] = _oldValue;
        }
    }
}
