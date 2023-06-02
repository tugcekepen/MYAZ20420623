using Data_Structures.Queue;

namespace QueueTests
{
    public class LinkedListQueueTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(15)]
        public void LinkedListQueue_Enqueue_Test(int item)
        {
            // Arrange
            var queue = new LinkedListQueue<int>();

            // Act
            queue.Enqueue(10);   // 10
            queue.Enqueue(item); // 10 5

            // Assert
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void LinkedListQueue_Dequeue_Test()
        {
            // Arrange
            var queue = new LinkedListQueue<int>();

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
        public void LinkedListQueue_Dequeue_ExceptionTest()
        {
            // Arrange
            var queue = new LinkedListQueue<int>();

            // Act


            // Assert
            Assert.Throws<Exception>(() => queue.Dequeue());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(15)]
        public void LinkedListQueue_Peek_Test(int item)
        {
            // Arrange
            var queue = new LinkedListQueue<int>();
            queue.Enqueue(10);   // 10
            queue.Enqueue(item); // 10 5


            //Act
            var result = queue.Peek();

            // Assert
            Assert.Equal(2, queue.Count);
            Assert.Equal(10, result);
        }

        [Fact]
        public void LinkedListQueue_IEnumerable_Ctor_Test()
        {
            //arrange - act
            var queue = new LinkedListQueue<char>("ahmet".ToArray());

            //assert
            Assert.Equal(5, queue.Count);
            Assert.Equal('a', queue.Peek());
        }
    }
}