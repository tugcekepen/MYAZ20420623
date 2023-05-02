using System.ComponentModel;

namespace LinkedList.Singly
{
    public class SinglyLinkedListNode<T>
       // where T: class // T tipini sınırlama
    {
        public T? Value { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode()
        {
        }

        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}