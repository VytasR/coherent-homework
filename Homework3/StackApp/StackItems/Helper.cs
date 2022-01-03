using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp.StackItems
{
    internal static class Helper
    {
        // Returns a new stack in which the elements of the original parameter stack are in reverse order.
        // Empties the original stack.
        public static IStack<T> Reverse<T>(IStack<T> stack) where T : struct
        {
            IStack<T> reverseStack = new Stack<T>();

            while (!stack.IsEmpty())
            {
                reverseStack.Push(stack.Pop());
            }

            return reverseStack;
        }
    }
}
