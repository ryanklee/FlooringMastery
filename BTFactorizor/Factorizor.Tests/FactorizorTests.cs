using NUnit.Framework;
using Factorizor.BLL;
using System.Collections.Generic;

namespace Factorizor.Tests
{
    [TestFixture]
    public class FactorizorTests
    {
        [Test]
        public void FactorFinderTest()
        {
            FactorFinder factorFinder = new FactorFinder();

            List<int> list = new List<int>
            {
                1,
                2,
                3,
                6
            };

            List<int> actual = factorFinder.GenerateFactors(6);
            Assert.AreEqual(list, actual);
        }

        [Test]
        public void PerfectCheckerTest()
        {
            PerfectChecker perfectChecker = new PerfectChecker();

            List<int> list = new List<int>
            {
                1,
                2,
                3,
                6
            };

            bool actual = perfectChecker.IsPerfect(6, list);
            Assert.IsTrue(actual);
        }

        [Test]
        public void PrimeCheckerTest()
        {
            PrimeChecker primeChecker = new PrimeChecker();

            List<int> list = new List<int>
            {
                1,
                2,
                3,
                6
            };

            bool actual = primeChecker.IsPrime(list);
            Assert.IsFalse(actual);

        }
    }
}
