using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Stack.Contract
{
    //Generic interface - type safe
    public interface IStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Pop();
        T Peek();

    }
}
