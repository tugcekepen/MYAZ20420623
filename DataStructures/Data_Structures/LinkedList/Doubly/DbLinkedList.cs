using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.LinkedList.Doubly
{
    public class DbLinkedList<T> : IEnumerable<T>
    {
        public DbNode<T>? Head { get; set; }
        public DbNode<T>? Tail { get; set; }
        public bool isHeadNull { get; set; }

        public DbLinkedList()
        {
            isHeadNull = true;
        }

        public DbLinkedList(IEnumerable<T> collection)
        {
            isHeadNull = true;
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddFirst(T item)
        {
            var node = new DbNode<T>(item);

            if(isHeadNull)
            {
                Head = node;
                Tail = node;
                isHeadNull = false;
                return;
            }

            if (!isHeadNull)
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
                return;
            }
        }

        public void AddLast(T item)
        {
            var node = new DbNode<T>(item);

            if (isHeadNull)
            {
                Head = node;
                Tail = node;
                isHeadNull = false;
                return;
            }
            if (!isHeadNull)
            {
                node.Prev = Tail;
                Tail.Next = node;
                Tail = node;
                return;
            }
        }

        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("The linked list is empty!");
            }
            if(Head.Next is null) // if(Head.Equals(Tail))
            {
                var item = Head.Value;
                Head = null;
                Tail = null;
                return item;
            }
            if (!isHeadNull)
            {
                var item = Head.Value;
                Head.Next.Prev = null;
                Head = Head.Next;
                return item;
            }
            throw new Exception();
        }

        public T RemoveLast()
        {
            if (isHeadNull)
            {
                throw new Exception("The linked list is empty!");
            }
            if (Head.Next is null) // if(Head.Equals(Tail))
            {
                var item = Tail.Value;
                Head = null;
                Tail = null;
                return item;
            }
            if (!isHeadNull)
            {
                var item = Tail.Value;
                Tail = Tail.Prev;
                Tail.Next = null;
                return item;
            }
            throw new Exception();
        }



        public IEnumerator<T> GetEnumerator()
        {
            return new DbLinkedListEnumerator<T>(Head, Tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
