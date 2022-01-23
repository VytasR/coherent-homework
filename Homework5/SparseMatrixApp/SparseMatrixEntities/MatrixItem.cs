using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp.SparseMatrixEntities
{
    internal class MatrixItem
    {
        public int Row { get; }
        public int Column { get; }
        public int Value { get; set; }

        public MatrixItem (int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
        
    }
}
