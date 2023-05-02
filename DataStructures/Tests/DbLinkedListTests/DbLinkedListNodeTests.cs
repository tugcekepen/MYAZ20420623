using LinkedList.Doubly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLinkedListTests
{
    public class DbLinkedListNodeTests
    {
        [Fact]
        public void DbNode_Test()
        {
            //Arrange
            var node = new DbNode<int>();

            //Act
            node.Value = 1;
            node.Next = new DbNode<int> { Value = 2 };
            node.Next.Prev = node;
            node.Next.Next = new DbNode<int> { Value = 3 };
            node.Next.Next.Prev = node.Next;

            //Assert
            Assert.Equal(1, node.Value);
            Assert.Equal(2, node.Next.Value);
            Assert.Equal(1, node.Next.Prev.Value);
            Assert.Equal(3, node.Next.Next.Value);
        }

        [Fact]
        public void DbNode_Test2()
        {
            //Arrange
            var node = new DbNode<char>();

            //Act
            node.Value = 'a';
            node.Next = new DbNode<char> { Value = 'b' };
            node.Next.Prev = node;
            node.Next.Next = new DbNode<char> { Value = 'c' };
            node.Next.Next.Prev = node.Next;

            //Assert
            Assert.Equal('a', node.Value);
            Assert.Equal('b', node.Next.Value);
            Assert.Equal('a', node.Next.Prev.Value);
            Assert.Equal('c', node.Next.Next.Value);
        }
    }
}
