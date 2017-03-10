using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSinglePrime()
        {
            PrimeNumberGenerator png = new PrimeNumberGenerator();

            Assert.IsTrue(png.IsPrime(113));
            
        }

        [TestMethod]
        public void TestPrime()
        {
            PrimeNumberGenerator png = new PrimeNumberGenerator();

            List<int> primeList = new List<int>(){2, 3, 5, 7, 11, 13, 17, 19};

            CollectionAssert.AreEqual(png.GetPrimeNumbers(20), primeList);
        }
    }
}
