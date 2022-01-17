using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDiagonalMX.MatrixEntities
{
    internal class MatrixElementChangedArgs<T> : EventArgs
    {
        // Instances of this class contain event data for matrix ElementChanged events.

        public int Row { get; }
        public int Column { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public MatrixElementChangedArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
