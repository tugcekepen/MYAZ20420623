using Stack;

namespace StackTests
{
    public class LinkedListStackTests
    {
        [Fact]
        public void LinkedListStack_Push_Test()
        {
            //Arrange
            var stack = new LinkedListStack<int>();

            //Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Assert
            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void LinkedListStack_Pop_Test()
        {
            //Arrange
            var stack = new LinkedListStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Act
            var item1 = stack.Pop();
            var item2 = stack.Pop();

            //Assert
            Assert.Equal(3, item1);
            Assert.Equal(2, item2);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void LinkedListStack_Peek_Test()
        {
            //Arrange
            var stack = new LinkedListStack<String>();
            stack.Push("Ahmet");
            stack.Push("Fatma");
            stack.Push("Can");

            //Act
            var item1 = stack.Peek();

            //Assert
            Assert.Equal("Can", item1);
            Assert.Equal(3, stack.Count);
        }
    }
}