﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp.StackItems
{
    internal class Stack<T> : IStack<T> where T : struct
    {
        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(T data)
        {
            throw new NotImplementedException();
        }
    }
}
