using List.Models.Classes;
using NUnit.Framework;
using System.Linq;

namespace ListNUnitTests
{
    public class TestWithInteger
    {
        private static CList<int> arrOfInt;

        [SetUp]
        public void Setup()
        {
            arrOfInt = new CList<int>();
        }

        [Test]
        public void Add4Items_ValidIntegers_Pass()
        {
            for (int i = 0; i < 4; i++)
            {
                arrOfInt.Add(i + 10);
            }

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(i + 10, arrOfInt[i]);
            }
        }

        [Test]
        public void Add6Items_ValidIntegers_Pass()
        {
            for (int i = 0; i < 6; i++)
            {
                arrOfInt.Add(i + 10);
            }

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i + 10, arrOfInt[i]);
            }
        }

        [Test]
        public void Contains_ValidInput_ReturnsTrue()
        {
            for (int i = 0; i < 10; i++)
            {
                arrOfInt.Add(i + 10);
            }

            Assert.AreEqual(true, arrOfInt.Contains(15));
        }

        [Test]
        public void Contains_InvalidInput_ReturnsFalse()
        {
            for (int i = 0; i < 10; i++)
            {
                arrOfInt.Add(i+10);
            }

            Assert.AreEqual(false, arrOfInt.Contains(97));
        }

        [Test]
        public void Clear_ValidInput_ReturnsAllFalse()
        {
            int[] integers = new int[3] { 2, 8, 12 };

            for (int i = 0; i < integers.Length; i++)
            {
                arrOfInt.Add(integers[i]);
            }

            for (int i = 0; i < integers.Length; i++)
            {
                Assert.AreEqual(integers[i], arrOfInt[i]);
            }         

            arrOfInt.Clear();

            for (int i = 0; i < integers.Length; i++)
            {
                Assert.AreNotEqual(integers[i], arrOfInt[i]);
            }       
        }
    }
}