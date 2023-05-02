using LinkedList.Singly;
using System.Collections.Generic;

#region notlar
//TRADE OF --> Her şeyin bir bedeli var yaklaşımı, bir yerden kazanmak isterken başka bir yerden kaybedebiliriz.
/*
            -LinkedList-      -Array-
Insert  :       Fast           Slow
Search  :       Slow           Fast

*/
#endregion

#region
//var node1 = new SinglyLinkedListNode<int>();
//node1.Value = 55;

//var node2 = new SinglyLinkedListNode<int>();
//node2.Value = 60;

//var node3 = new SinglyLinkedListNode<int>();
//node3.Value = 65;

//node1.Next = node2;
//node2.Next = node3;

//Console.WriteLine(node1);
//Console.WriteLine(node1.Next);
//Console.WriteLine(node2.Next);
//Console.WriteLine(node1.Next.Next);

//Console.WriteLine(new String('-',20));

//// ?  !!!!!!!
//var current = node1;
//while(current != null)
//{
//    Console.Write($"{current,-5} ");
//    current = current.Next;
//}
#endregion

var linkedList = new SinglyLinkedList<int>(new SortedSet<int>()
{
    4,17,23,3,6,11,9,3,4
});

#warning Dikkat
// SortedSet ---> 3 4 6 9 11 17 23
// SinglyLinkedList (AddFirst kullanımı ile bağlı listeye dönüştürdüğümüz için) ---> 23 17 11 9 6 4 3
foreach (var item in linkedList)
{
    Console.WriteLine(item);
}
