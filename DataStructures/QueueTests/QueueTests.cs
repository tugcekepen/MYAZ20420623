using Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTests
{
    public class QueueTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(15)]
        public void LinkedListQueue_Enqueue_Test(int item)
        {
            // Arrange
            var queue = new Queue.Queue<int>();

            // Act
            queue.Enqueue(10);   // 10
            queue.Enqueue(item); // 10 5

            // Assert
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void Queue_Dequeue_Test()
        {
            // Arrange
            var queue = new Queue.Queue<int>();

            // Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            // Assert
            Assert.Equal(5, queue.Count);
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(5, queue.Dequeue());
        }

        [Fact]
        public void Queue_Dequeue_ExceptionTest()
        {
            // Arrange
            var queue = new Queue.Queue<int>();

            // Act


            // Assert
            Assert.Throws<Exception>(() => queue.Dequeue());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(15)]
        public void Queue_Peek_Test(int item)
        {
            // Arrange
            var queue = new Queue.Queue<int>();
            queue.Enqueue(10);   // 10
            queue.Enqueue(item); // 10 5


            //Act
            var result = queue.Peek();

            // Assert
            Assert.Equal(2, queue.Count);
            Assert.Equal(10, result);
        }

        [Fact]
        public void Queue_IEnumerable_Ctor_Test()
        {
            //arrange - act
            var queue = new Queue.Queue<char>("ahmet".ToArray());

            //assert
            Assert.Equal(5, queue.Count);
            Assert.Equal('a', queue.Peek());
        }
    }
}
