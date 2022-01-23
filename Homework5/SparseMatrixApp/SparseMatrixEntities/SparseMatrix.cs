using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp.SparseMatrixEntities
{
    internal class SparseMatrix
    {
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private SortedSet<MatrixItem> _items;
    }
}
