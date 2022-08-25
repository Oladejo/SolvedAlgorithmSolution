using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestingPackage
{
    [TestClass]
    public class SmallestDifferenceTest
    {
        [TestMethod]
        public void TestCase1()
        {
            int[] expected = { 28, 26 };
            int[] arrayOne = new int[] { -1, 10, 20, 28, 3 };
            int[] arrayTwo = new int[] { 26, 134, 135, 15, 17 };

            Assert.IsTrue(Enumerable.SequenceEqual(SmallestDifferent.Program.SmallestDifference(arrayOne, arrayTwo), expected));
        }

        [TestMethod]
        public void TestCase2()
        {
            int[] expected = { 28, 26 };
            int[] arrayOne = new int[] { -1, 10, 20, 28, 3 };
            int[] arrayTwo = new int[] { 26, 134, 135, 15, 17 };

            Assert.IsTrue(Enumerable.SequenceEqual(SmallestDifferent.Program.SmallestDifferenceV2(arrayOne, arrayTwo), expected));
        }

        [TestMethod]
        public void TestCase3()
        {
            int[] expected = { 20, 17 };
            int[] arrayOne = new int[] { -1, 5, 10, 20, 3 };
            int[] arrayTwo = new int[] { 26, 134, 135, 15, 17 };

            Assert.IsTrue(Enumerable.SequenceEqual(SmallestDifferent.Program.SmallestDifferenceV2(arrayOne, arrayTwo), expected));
        }

    }
}
