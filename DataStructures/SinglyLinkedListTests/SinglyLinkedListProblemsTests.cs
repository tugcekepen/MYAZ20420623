using LinkedList.Singly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedListTests
{
    public class SinglyLinkedListProblemsTests
    {
        [Fact]
        public void SinglyLinkedList_Concatenate_Test()
        {
            //Arrange
            var linkedList = new SinglyLinkedList<int>(); // 30 20 10
            linkedList.AddFirst(10);
            linkedList.AddFirst(20);
            linkedList.AddFirst(30);
            var linkedList2 = new SinglyLinkedList<int>(); // 60 50 40
            linkedList2.AddFirst(40);
            linkedList2.AddFirst(50);
            linkedList2.AddFirst(60);

            //Act
            var concatList = SinglyLinkedList<int>.Concatenate(linkedList, linkedList2);

            //Assert
            Assert.Equal(6, concatList.Count);
            Assert.Equal(50, concatList.Head.Next.Next.Next.Next.Value);
            Assert.Collection<int>(concatList,
                item => Assert.Equal(30, item),
                item => Assert.Equal(20, item),
                item => Assert.Equal(10, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(40, item));
        }

        [Fact]
        public void SinglyLinkedList_Concatenate2_Test()
        {
            var linkedList = new SinglyLinkedList<String>();
            linkedList.AddFirst("Ayşe");
            linkedList.AddFirst("Fatma");
            linkedList.AddFirst("Hayriye");
            var linkedList2 = new SinglyLinkedList<String>(); //boş

            var concatList = SinglyLinkedList<String>.Concatenate(linkedList, linkedList2);

            Assert.Collection<String>(concatList,
                item => Assert.Equal("Hayriye", item),
                item => Assert.Equal("Fatma", item),
                item => Assert.Equal("Ayşe", item));
        }

        [Fact]
        public void SinglyLinkedList_Concatenate_Exception_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            var linkedList2 = new SinglyLinkedList<int>();

            Assert.Throws<Exception>(() => SinglyLinkedList<int>.Concatenate(linkedList, linkedList2));
        }
    }
}
