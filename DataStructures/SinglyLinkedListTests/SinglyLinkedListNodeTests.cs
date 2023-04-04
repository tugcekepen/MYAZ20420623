using LinkedList.Singly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedListTests
{
    public class SinglyLinkedListNodeTests
    {
        [Fact]
        public void SinglyLinkedListNode_Test()
        {
            // arrange 
            var node1 = new SinglyLinkedListNode<int>()
            {
                Value = 10
            };

            var node2 = new SinglyLinkedListNode<int>(20);
            
            // act
            node1.Next = node2;
            

            // assert
            Assert.Equal(node1.Next, node2);
            Assert.Equal(10, node1.Value);
            Assert.Equal(20, node1.Next.Value);
            Assert.True(node1.Next.Value == node2.Value);
        }
    }
}
