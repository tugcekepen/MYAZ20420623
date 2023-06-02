using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTests
{
    public class ArrayProblemsTests
    {
        [Fact]
        public void Array_Concate_Test()
        {
            //Arrange
            var numbers = new Data_Structures.Array.Array();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            //Act
            numbers.Concate(new Object[4] { 4, 5, 6, 7 });

            var item = numbers.GetItem(5);

            //Assert
            Assert.Equal(4, item);
        }
    }
}
