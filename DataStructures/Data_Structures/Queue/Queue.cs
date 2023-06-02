using Data_Structures.Queue.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Queue
{
    public class Queue<T> : IQueue<T>
    {
        private IQueue<T> _queue;
        public Queue()
        {
            _queue = new LinkedListQueue<T>();
        }

        public Queue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        
        public int Count => _queue.Count;

        public T Dequeue()
        {
            return _queue.Dequeue();
        }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        public T Peek()
        {
            return _queue.Peek();
        }
    }
}
