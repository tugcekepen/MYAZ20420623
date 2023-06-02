using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.LinkedList.Singly
{
    public partial class SinglyLinkedList<T> : IEnumerable<T>
    {
        #region notlar
        //LinkedList, DİNAMİKTİR.
        //Bağlı listede, array'de olduğu gibi istenilen göze doğrudan erişebilme özelliği yok.
        //Bir Head belirlememiz gerekiyor. Yani koleksiyona nereden dahil olacağımızı bilmeliyiz.

        //Arrayda Preallocation vardır. Önceden yer/boyut belirleriz. block allocation
        //LinkedList'de bu yoktur. Separate Allocation. Verilerimiz, bellekte yer olduğu müddetçe(Stack OverFlow olmuyorsa), her biri birbirinden ayrı ve node'lar halinde alan tutar.

        //Bir sınıfa iterasyon özelliklerini kazandırmak için gereken tüm özellikler IEnumerator interface’i aracılığıyla elde edilebilmektedir. !!!
        //IEnumerable interface’i ise bir sınıfa foreach mekanizması tarafından tanınması için gerekli yetenekleri/nitelikleri kazandırır. Yani enumerator yapısını… !!!
        #endregion

        // Auto-implemented property
        public SinglyLinkedListNode<T>? Head { get; set; } //başlangıç noktası olan node'dur aslında. listenin başlangıç elemanı diye düşünülebilir.

        private int _count = 0;
        public int Count => _count;

        public SinglyLinkedList()
        {
        }

        /// <summary>
        /// Iterable olan herh bir veriyi/koleksiyonu parametre olr alsın ve bağlı listeye çevirsin.
        /// </summary>
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        /// <summary>
        /// Bağlı listenin başına eleman ekler
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item) // O(1)
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
                _count++;
                return; //return illa geriye bir şey döndürüyor demek değil. böyle kullanıldığında fonksiyonu burada kesecek.!
            }

            node.Next = Head;
            Head = node;
            _count++;
            return;
        }

        /// <summary>
        /// Bağlı listenin sonuna eleman ekler. 
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item) // O(n) n:kaç tane eleman varsa
        {
            // T ifadesini düğüme çevir
            var node = new SinglyLinkedListNode<T>(item);
            
            // Head kontrol et
            if (Head is null)
            {
                Head = node;
                _count++;
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
            _count++;
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
                    _count++;
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
                    _count++;
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
            
            var removed = Head.Value;
            Head = Head.Next;
            _count--;
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
                _count--;
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
            _count--;
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
                    _count--;
                    return item;
                }
                current = current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }


        //Enumerator; bağlı listelerde farklı, çift yönlü bağlı listelerde farklı, arraylerde farklı, ağaçlarda farklı çalışır.
        //Fakat temelde, koleksiyondaki elemanları sırayla dolaşmak için kullandığımız bir yapıdır.
        public IEnumerator<T> GetEnumerator() //interface'ler referans tutucudur.
        {   
            /*
            foreach döngüsü bir sınıf üzerinde çalışacaksa o sınıfın kesinlikle ve kesinlikle
            içerisinde geriye IEnumerator döndüren GetEnumerator metodunun bulunmasını ister. Tek şartı budur.
            */
            return new SinglyLinkedListEnumerator<T>(Head); //bu classın IEnumerator<T> tipiyle geri dönebilmesi için IEnumerator<T>'yi kalıtımla devralması lazım. ---Polimorfizm---
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
