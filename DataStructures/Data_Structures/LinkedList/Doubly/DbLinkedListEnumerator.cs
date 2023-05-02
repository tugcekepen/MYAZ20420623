using System.Collections;

namespace LinkedList.Doubly
{
    public class DbLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DbNode<T> Head { get; set; }
        private DbNode<T> Tail { get; set; }
        private DbNode<T> Curr { get; set; }

        public DbLinkedListEnumerator(DbNode<T> head, DbNode<T> tail)
        {
            Head = head;
            Tail = tail;
            Curr = null;
        }

        public T Current => Curr.Value ?? default(T);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
            Tail = null;
        }

        public bool MoveNext()
        {
            if (Head == null)
                return false;
            if (Curr == null)
            {
                Curr = Head;
                return true;
            }
            if (Curr.Next is not null)
            {
                Curr = Curr.Next;
                return true;
            }
            return false;

            //Tersten çalıştırmak istersek
            /*
            if (Tail == null)
                return false;
            if (Curr == null)
            {
                Curr = Tail;
                return true;
            }
            if (Curr.Prev is not null)
            {
                Curr = Curr.Prev;
                return true;
            }
            return false;
            */
        }

        public void Reset()
        {
            Head = null;
            Tail = null;
            Curr = null;
        }
    }
}