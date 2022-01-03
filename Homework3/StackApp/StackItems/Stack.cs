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

        public bool IsEmpty()
        {
            return _pointer == 0;
        }

        public T Pop()
        {
            if (_pointer > 0)
            {
                _pointer--;
                return _array[_pointer];
            }
            return default(T);
        }

        public void Push(T data)
        {
            throw new NotImplementedException();
        }
    }
}
