using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestingPackage
{
    [TestClass]
    public class ValidSubsequenceTest
    {
        [TestMethod]
        public void IsValidSequence()
        {
            List<int> array = new()
            {
                5, 1, 22, 25, 6, -1, 8, 10
            };

            List<int> sequence = new()
            {
                1, 6, -1, 10
            };

            Assert.IsTrue(ValidateSequence.Program.IsValidSubsequence(array, sequence));
        }

        [TestMethod]
        public void IsValidSequenceV2()
        {
            List<int> array = new()
            {
                5,
                1,
                22,
                25,
                6,
                -1,
                8,
                10
            };

            List<int> sequence = new()
            {
                1,
                6,
                -1,
                10
            };

            Assert.IsTrue(ValidateSequence.Program.IsValidSubsequenceV2(array, sequence));
        }
    }
}
