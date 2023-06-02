using Data_Structures.Queue.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        //private List<T> _listQueue;
        private Array.Array _arrayQueue;

        public ArrayQueue()
        {
            //_listQueue = new List<T>();
            _arrayQueue = new Array.Array();

        }

        public ArrayQueue(IEnumerable<T> collections) : this()
        {
            foreach (var item in collections)
            {
                Enqueue(item);
            }
        }

        public int Count => _arrayQueue.Count; //_listQueue.Count; 

        public T Dequeue()
        {
            //if (_listQueue.Count == 0)
            //    throw new Exception("The queue is empty!");
            //T item = _listQueue[0];
            //_listQueue.RemoveAt(0);
            if (_arrayQueue.Count == 0)
                throw new Exception("The queue is empty!");
            var item = _arrayQueue.GetItem(0);
            _arrayQueue.RemoveItem(0);
            return (T)item;
        }

        public void Enqueue(T item)
        {
            //_listQueue.Add(item);
            _arrayQueue.Add(item);
        }

        public T Peek()
        {
            //return _listQueue.Count == 0 ? default : _listQueue[0];
            return _arrayQueue.Count == 0 ? default : (T)_arrayQueue.GetItem(0);
        }
    }
}
