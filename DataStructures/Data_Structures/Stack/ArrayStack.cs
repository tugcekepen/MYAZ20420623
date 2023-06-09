﻿using Data_Structures.Stack.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private List<T> _innerArray;
        public ArrayStack()
        {
            _innerArray = new List<T>();
        }

        public ArrayStack(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public int Count => _innerArray.Count;

        public T Peek()
        {
            return Count == 0 ? default(T) : _innerArray[_innerArray.Count-1];
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Underflow! Empty stack!");
            }
            var temp = _innerArray[_innerArray.Count - 1];
            _innerArray.RemoveAt(_innerArray.Count - 1);
            return temp;
        }

        public void Push(T item)
        {
            _innerArray.Add(item);
        }
    }
}
