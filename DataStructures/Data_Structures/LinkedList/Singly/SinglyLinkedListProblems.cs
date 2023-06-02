using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_Structures.LinkedList.Singly
{
    public partial class SinglyLinkedList<T> : IEnumerable<T>
    {
        public static SinglyLinkedList<T> Concatenate(SinglyLinkedList<T> l1, SinglyLinkedList<T> l2)
        {
            if (l1.Head is null && l2.Head is null)
                throw new Exception("Linked lists are empty!");

            if(l1.Head is null)
                return l2;
            else if(l2.Head is null)
                return l1;

            // ikisi de boş değilse
            var current = l1.Head;
            var prev = current;
            while (current != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = l2.Head;
            l1._count += l2._count;
            return l1;
        }
    }
}
