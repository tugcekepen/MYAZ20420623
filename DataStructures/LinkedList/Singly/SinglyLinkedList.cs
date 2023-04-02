using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Singly
{
    public class SinglyLinkedList<T>
    {
        // Auto-implemented propert
        public SinglyLinkedListNode<T>? Head { get; set; } //başlangıç noktası olan node'dur aslında. listenin başlangıç elemanı diye düşünülebilir.

        public SinglyLinkedList()
        {
            
        }

        /// <summary>
        /// Bağlı listenin başına eleman ekler
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            // önce düğüm oluşturman gerekir!!!!!!!!!!!!!! eklenecek şey bir düğüm olacak!
            var node = new SinglyLinkedListNode<T>()
            {
                Value = item
            };

            // Head boş mu?
            if (Head is null)
            {
                Head = node;
                return; //return illa geriye bir şey döndürüyor demek değil. böyle kullanıldığında fonksiyonu burada kesecek.!
            }

            node.Next = Head;
            Head = node;
            return;
        }

        /// <summary>
        /// Bağlı listenin sonuna eleman ekler. 
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            // T ifadesini düğüme çevir
            var node = new SinglyLinkedListNode<T>(item);
            
            // Head kontrol et
            if (Head is null)
            {
                Head = node;
                return;
            }

            // Son elemana kadar git
            var current = Head;
            var prev = current;
            while (current != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = node;
            return;
        }

        /// <summary>
        ///  a - [b] - c                    x -> c
        /// </summary>
        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if(Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(item);

            var current = Head;
            var prev = current;
            
            while(current is not null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }

        /// <summary>
        /// Week 4 - Verilen düğümden sonraya verilen T değerini ekler.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(item);

            var current = Head;
            var prev = current;

            while (current is not null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next.Next; // newNode.Next = current.Next;
                    prev.Next.Next = newNode;      // current.Next = newNode;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }

        /// <summary>
            /// Week 4 - Bağlı listenin başındaki düğümü çıkarır.
            /// Çıkarılan düğümün değerini geri döndürür.
            /// </summary>
            /// <returns></returns>
        public T RemoveFirst()
        {
            if (Head is null)
            {
                throw new Exception("The linked list is empty.");
            }
            if (Head.Next == null)
            {
                var item = Head.Value;
                Head = Head.Next;
                return item;
            }
            var current = Head;
            var removed = Head.Value;
            Head = current.Next;
            current = null;
            return removed;
        }

        /// <summary>
        /// Week 4 - Bağlı listenin sonundaki düğümü çıkarır.
        /// Çıkarılan düğümün değerini geri döndürür.
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            if (Head is null)
            {
                throw new Exception("The linked list is empty.");
            }
            if (Head.Next == null)
            {
                var item = Head.Value;
                Head = null;
                return item;
            }
            var current = Head;
            var removed = Head.Value;
            while ( current is not null)
            {
                if (current.Next.Next == null)
                {
                    removed = current.Next.Value;
                    current.Next = null;
                    break;
                }
                current = current.Next;
            }
            return removed;
        }

        /// <summary>
        /// Week 4 - Bağlı listeden verilen düğümü çıkarır.
        /// Eğer düğüm bağlı listede bulunmuyorsa hata fırlatır.
        /// Çıkarılan değeri geri döndürür.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T Remove(SinglyLinkedListNode<T> node)
        {
            if (Head is null)
            {
                throw new Exception("The linked list is empty.");
            }
            if (node.Value.Equals(Head.Value))
            {
                var item = RemoveFirst();
                return item;
            }
            var current = Head;
            while (current != null)
            {
                if(current.Next.Value.Equals(node.Value))
                {
                    var item = current.Next.Value;
                    current.Next = current.Next.Next;
                    return item;
                }
                current = current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }
    }
}
