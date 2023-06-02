using System.Collections;

namespace Data_Structures.LinkedList.Singly
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T> //week5
    {
        private SinglyLinkedListNode<T> Head { get; set; }
        private SinglyLinkedListNode<T> Curr { get; set; }

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head; //temel amacımız bağlı listenin Head referansını buraya taşımak
            Curr = null;
        }

        public T Current => Curr.Value;

        object IEnumerator.Current => Current;

        public void Dispose() //yok etmek
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(Head == null)
            {
                return false;
            }
            if(Curr == null)
            {
                Curr = Head;
                return true;
            }
            if(Curr.Next is not null)
            {
                Curr = Curr.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Curr = null;
            Head = null;
        }
    }
}