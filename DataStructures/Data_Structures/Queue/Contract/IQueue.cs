using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Queue.Contract
{
    public interface IQueue<T>
    {
        public int Count { get; }
        public void Enqueue(T item);
        public T Dequeue();

        public T Peek();
    }
}
