using List.Models.Classes;
using NUnit.Framework;
using System.Linq;

namespace ListNUnitTests
{
    public class TestWithInteger
    {
        private static CList<int> listOfInt;

        [SetUp]
        public void Setup()
        {
            listOfInt = new CList<int>();
        }


        [Test]
        public void Capacity_0ItemsInserted_Returns4()
        {
            Assert.AreEqual(4, listOfInt.Capacity);
        }

        [Test]
        public void Capacity_3ItemsInserted_Returns4()
        {
            for (int i = 0; i < 3; i++)
            {
                listOfInt.Add(10 + i);
            }

            Assert.AreEqual(4, listOfInt.Capacity);
        }

        [Test]
        public void Capacity_6ItemsInserted_Returns8()
        {
            for (int i = 0; i < 6; i++)
            {
                listOfInt.Add(10 + i);
            }

            Assert.AreEqual(8, listOfInt.Capacity);
        }

        [Test]
        public void Capacity_10ItemsInserted_Returns16()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(10 + i);
            }

            Assert.AreEqual(16, listOfInt.Capacity);
        }




        [Test]
        public void Count_0ItemsInserted_Returns0()
        {
            Assert.AreEqual(0, listOfInt.Count);
        }


        [Test]
        public void Count_3ItemsInserted_Returns3()
        {
            for (int i = 0; i < 3; i++)
            {
                listOfInt.Add(10 + i);
            }

            Assert.AreEqual(3, listOfInt.Count);
        }

        [Test]
        public void Count_10ItemsInserted_Returns10()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(10 + i);
            }

            Assert.AreEqual(10, listOfInt.Count);
        }




        [Test]
        public void Add4Items_ValidIntegers_Pass()
        {
            for (int i = 0; i < 4; i++)
            {
                listOfInt.Add(i + 10);
            }

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(i + 10, listOfInt[i]);
            }
        }

        [Test]
        public void Add6Items_ValidIntegers_Pass()
        {
            for (int i = 0; i < 6; i++)
            {
                listOfInt.Add(i + 10);
            }

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i + 10, listOfInt[i]);
            }
        }




        [Test]
        public void Contains_ValidInput_ReturnsTrue()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(i + 10);
            }

            Assert.AreEqual(true, listOfInt.Contains(15));
        }

        [Test]
        public void Contains_InvalidInput_ReturnsFalse()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(i + 10);
            }

            Assert.AreEqual(false, listOfInt.Contains(97));
        }



        [Test]
        public void Clear_ValidInput_ReturnsAllFalse()
        {
            int[] integers = new int[3] { 2, 8, 12 };

            for (int i = 0; i < integers.Length; i++)
            {
                listOfInt.Add(integers[i]);
            }

            for (int i = 0; i < integers.Length; i++)
            {
                Assert.AreEqual(integers[i], listOfInt[i]);
            }

            listOfInt.Clear();

            for (int i = 0; i < integers.Length; i++)
            {
                Assert.AreNotEqual(integers[i], listOfInt[i]);
            }
        }




        [Test]
        public void CopyTo_EmptyArray_ReturnsFilledArray()
        {
            for (int i = 0; i < 8; i++)
            {
                listOfInt.Add(10 + i);
            }

            int[] array = new int[8];
            listOfInt.CopyTo(array);

            for (int i = 0; i < listOfInt.Count; i++)
            {
                Assert.AreEqual(listOfInt[i], array[i]);
            }
        }

        [Test]
        public void CopyTo_Array_ReturnsExpectedArray()
        {
            for (int i = 0; i < 8; i++)
            {
                listOfInt.Add(10 + i);
            }

            int[] array = new int[10];
            array[0] = 55;
            array[1] = 66;
            listOfInt.CopyTo(array, 2);

            Assert.AreEqual(55, array[0]);
            Assert.AreEqual(66, array[1]);

            for (int i = 0; i < listOfInt.Count; i++)
            {
                Assert.AreEqual(listOfInt[i], array[i + 2]);
            }
        }

        [Test]
        public void IndexOf_ValidItem11_ReturnsCorrectIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(10 + i);
            }

            int expectedResult = 1;
            int actualResult = listOfInt.IndexOf(11);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void IndexOf_ValidItem15_ReturnsCorrectIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(10 + i);
            }

            int expectedResult = 5;
            int actualResult = listOfInt.IndexOf(15);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void IndexOf_InvalidItem150_ReturnsCorrectIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                listOfInt.Add(10 + i);
            }

            int expectedResult = -1;
            int actualResult = listOfInt.IndexOf(150);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}