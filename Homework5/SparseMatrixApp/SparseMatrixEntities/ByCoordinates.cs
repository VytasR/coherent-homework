using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixApp.SparseMatrixEntities
{
    internal class ByCoordinates : IComparer<Coordinates>
    {
        // This class implements IComparer so that Coordinate objects are sorted by columns first then by rows
        public int Compare(Coordinates x, Coordinates y)
        {
            if (x.Column.CompareTo(y.Column) != 0)
            {
                return x.Column.CompareTo(y.Column);
            }
            else if (x.Row.CompareTo(y.Row) != 0)
            {
                return x.Row.CompareTo(y.Row);
            }
            else
            {
                return 0;
            }
        }
    }
}
