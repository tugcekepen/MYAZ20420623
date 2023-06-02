using Data_Structures.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTests
{
    public class ArrayQueueTests
    {
        [Fact]
        public void ArrayQueue_Enqueue_Test()
        {
            //Arrange - Act
            var list = new ArrayQueue<char>("Mehmet"); //!!!

            //Assert
            Assert.Equal(6, list.Count);
        }

        [Fact]
        public void ArrayQueue_Dequeue_Test()
        {
            //Arrange
            var list = new ArrayQueue<char>("Mehmet"); //!!!

            //Act
            var item = list.Dequeue();

            //Assert
            Assert.Equal(5, list.Count);
            Assert.Equal('M', item);
        }

        [Fact]
        public void ArrayQueue_Dequeue_Exception_Test()
        {
            //Arrange
            var list = new ArrayQueue<char>(); //!!!

            //Assert
            Assert.Throws<Exception>( () => list.Dequeue() );
        }

        [Fact]
        public void ArrayQueue_Peek_Test()
        {
            //Arrange
            var list = new ArrayQueue<char>("Mehmet"); //!!!

            //Act
            var item = list.Peek();

            //Assert
            Assert.Equal(6, list.Count);
            Assert.Equal('M', item);
        }
    }
}
