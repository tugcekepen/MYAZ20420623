namespace ArrayTests
{
    // Unit Test
    public class ArrayTests
    {
        [Fact]//Fact ifadeleri void ile döner
        public void Array_Count_Test()//testi calistirmak için Array_Count_Test üzerine sag tik -> Run Tests => Test Explorer'dan takip edilebilir
        {
            //Dependencies -> Add Project Reference -> Array (classlib)

            //Test yazarken 3A pattern'i uygulanır.

            // Arrange - Düzenleme
            var array = new Data_Structures.Array.Array(); // sadece Array() yazdigimizda c# kendi Array'i ile karistirip hangisi oldugunu cozumleyemedigi için kitaplik adiyla birlikte belirttik
            array.Add("Ahmet");
            array.Add("Mehmet");
            array.Add("Can");

            // Act - Eylem
            int count = array.Count;

            // Assertion - Iddia
            Assert.Equal(3, count); // "count(actual-gerçek) degiskenimde 2(beklenen-expected) degerini bekliyorum" (count ise burada gerçek deger)
            Assert.Equal(4, array.Capacity);
        }//teorik-week1

        [Fact]
        public void Array_Add_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add("Ahmet");
            array.Add("Mehmet");
            array.Add("Can");
            array.Add("Canan");
            array.Add("Filiz");

            // Act
            int count = array.Count;

            // Assertion
            Assert.Equal(5, count);
            Assert.Equal(8, array.Capacity);
        }//teorik-week1

        [Fact]
        public void Array_GetItem_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add("Ahmet");  // index : 0
            array.Add("Mehmet"); // index : 1

            // Act
            var item = array.GetItem(1);

            // Assert
            Assert.Equal("Mehmet", item);
        }

        [Fact]
        public void Arrry_Find_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            // Act
            int result = array.Find(2);
            
            // Assert
            Assert.Equal(1, result);
        }//LAB-week1

        [Fact]
        public void Array_GetEnumerator_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add("Ahmet");
            array.Add("Mehmet");
            array.Add("Can");

            string result = "";
            foreach (var item in array)
            {
                result = string.Concat(result, item);
            }

            Assert.Equal("AhmetMehmetCan", result);
        }//LAB-week1

        [Fact]
        public void Array_Contructor_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array(36,23,55,44,61);

            // Act
            var result = array.Capacity; // 5
            
            var result2 = String.Empty;
            foreach (var item in array)
            {
                result2 = string.Concat(result2, item);
            }

            // Assert
            Assert.Equal(5, result);
            Assert.Equal("3623554461", result2);
        }

        [Fact]
        public void Array_SetItem_Test()
        {
            // Arrange : Düzenleme
            var numbers = new Data_Structures.Array.Array(1, 3, 5, 7);

            // Act : Eylem
            numbers.SetItem(2, 55);

            // Assert : İddia
            Assert.Equal(55,numbers.GetItem(2));
            Assert.True(numbers.GetItem(2).Equals(55));
        }//teori-week2

        /// <summary>
        /// Week 1 - GetItem Metot Hata Firlatma Test
        /// </summary>
        [Fact]
        public void Array_GetItem_Exception_Test()
        {
            try
            {
                // Arrange
                var array = new Data_Structures.Array.Array();
                array.Add("Ahmet");
                array.Add("Mehmet");

                // Act
                var item = array.GetItem(-1);

                // Assert
                Assert.False(true);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        /// Week 1 - Swap Metot Test
        /// </summary>
        [Fact]
        public void Array_Swap_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add("Ahmet");     // 0
            array.Add("Mehmet");    // 1
            array.Add("Metin");     // 2

            // Act
            array.Swap(0, 2);
            var item1 = array.GetItem(0);   // Metin
            var item2 = array.GetItem(2);   // Ahmet

            // Assert
            Assert.Equal("Metin", item1);
            Assert.Equal("Ahmet", item2);
        }//LAB-week1

        /// <summary>
        /// Week 1 - Find Metot Test
        /// </summary>
        [Fact]
        public void Array_Find_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add("Ahmet"); //0
            array.Add("Mehmet");// 1

            // Act
            var item1 = array.Find("Mehmet");
            var item2 = array.Find("Ali");

            // Assert
            Assert.Equal(1, item1);
            Assert.Equal(-1, item2);
        }//LAB-week1

        /// <summary>
        /// Week 2 - Test
        /// </summary>
        [Fact]
        public void Array_Remove_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            array.Add(0);   // 0
            array.Add(1);   // 1
            array.Add(2);   // 2
            array.Add(3);   // 3
            array.Add(4);   // 4

            // Act
            var item = array.RemoveItem(2);
            var item2 = array.GetItem(2);
            array.RemoveItem(3);
            
            // Assert
            Assert.Equal(2, item);
            Assert.Equal(3, item2);
            Assert.Equal(4, array.Capacity);
        }//LAB-week1

        [Fact]
        public void Array_Copy_Test()
        {
            // Arrange
            var array = new Data_Structures.Array.Array();
            
            array.Add("Ahmet");     // 0
            array.Add("Mehmet");    // 1
            array.Add("Can");       // 2
            array.Add("Deniz");     // 3

            // Act
            var newArray = array.Copy(2, 3);
            var item = newArray[0];

            // Assert
            Assert.Equal("Can", item);
        }//LAB-week1

    }
}