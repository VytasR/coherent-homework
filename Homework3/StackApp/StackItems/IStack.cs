﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp.StackItems
{
    internal interface IStack<T> where T : struct
    {
        void Push(T data);
        T Pop();
        bool IsEmpty();
    }
}