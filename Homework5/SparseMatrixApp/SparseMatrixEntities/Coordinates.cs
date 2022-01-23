using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp.SparseMatrixEntities
{
    internal class Coordinates
    {
        public int Row { get; }
        public int Column { get; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var other = obj as Coordinates;
            return other?.Row == this.Row && other?.Column == this.Column;
        }
    }
}
