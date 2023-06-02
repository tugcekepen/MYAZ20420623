using LinkedList.Doubly;
using Data_Structures.Queue.Contract;

namespace Data_Structures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        //Kuyruk yapısı, iki ucu açık yapı olduğundan dolayı doubly linked list'te bulunan head ve tail gibi özellikler ile işlemlerimiz kolay olacaktır.
        private DbLinkedList<T> _linkedlistqueue;

        public LinkedListQueue()
        {
            _linkedlistqueue = new DbLinkedList<T>();
        }

        public LinkedListQueue(IEnumerable<T> collection) : this()
        {
            foreach (T item in collection)
            {
                Enqueue(item);
            }
        }

        public int Count => _linkedlistqueue.Count();

        public T Dequeue()
        {
            if (_linkedlistqueue.Head is null)
                throw new Exception("The queue is empty!");
            return _linkedlistqueue.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            _linkedlistqueue.AddLast(item);
        }

        public T Peek()
        {
            return _linkedlistqueue.Head is null ? default : _linkedlistqueue.Head.Value;
        }
    }
}