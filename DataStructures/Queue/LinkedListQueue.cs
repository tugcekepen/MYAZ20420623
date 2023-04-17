﻿using LinkedList.Doubly;
using Queue.Contract;

namespace Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private DbLinkedList<T> linkedlistqueue;

        public LinkedListQueue()
        {
            linkedlistqueue = new DbLinkedList<T>();
        }

        public int Count => linkedlistqueue.Count();

        public T Dequeue()
        {
            if (linkedlistqueue.Head is null)
                throw new Exception("The queue is empty!");
            return linkedlistqueue.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            linkedlistqueue.AddLast(item);
        }

        public T Peek()
        {
            return linkedlistqueue.Head is null ? default : linkedlistqueue.Head.Value;
        }
    }
}