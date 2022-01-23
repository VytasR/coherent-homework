using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp.StackItems
{
    // Describes operations with a stack that stores elements of value types.
    internal interface IStack<T> where T : struct
    {
        void Push(T data);
        T Pop();
        bool IsEmpty();
    }
}
