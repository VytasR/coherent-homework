using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp.StackItems
{
    internal class Stack<T> : IStack<T> where T : struct
    {
        private const int DEFAULT_CAPACITY = 16;
        private T[] _array;
        private int _pointer;

        public Stack(int capacity)
        {
            if (capacity > 0)
            {
                _array = new T[capacity];
            }
            else
            {
                _array = new T[DEFAULT_CAPACITY];
            }
            _pointer = 0;
        }

        public Stack()
        {
            _array = new T[DEFAULT_CAPACITY];
            _pointer = 0;
        }

        // Checks for the emptiness of the stack.
        public bool IsEmpty()
        {
            return _pointer == 0;
        }

        // Removes and returns the last inserted element.
        public T Pop()
        {
            if (_pointer > 0)
            {
                _pointer--;
                return _array[_pointer];
            }
            else
            {
                throw new InvalidOperationException("Attempt to remove an item from an empty stack.");
            }                        
        }

        // Pushes an item onto the stack.
        public void Push(T data)
        {
            if (_pointer < _array.Length)
            {
                _array[_pointer] = data;
                _pointer++;
            }
            else
            {
                throw new InvalidOperationException("Attempt to push an item to a full stack.");
            }            
        }
    }
}
