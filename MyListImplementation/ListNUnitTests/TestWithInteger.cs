using List.Models.Classes;
using NUnit.Framework;

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
    }
}