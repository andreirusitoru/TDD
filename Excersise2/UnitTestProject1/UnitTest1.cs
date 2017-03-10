using System;
using Excersise2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldBuyMore()
        {
            var shoppingCart = new ShoppingCart();

            shoppingCart.AddItem(50, 2);

            Assert.AreEqual(shoppingCart.Total, 100);
        }

        [TestMethod]
        public void ShouldGiveSomeDiscount()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddDiscount(100, 5);
            shoppingCart.AddDiscount(200, 10);

            shoppingCart.AddItem(70, 2);
            shoppingCart.AddItem(20, 2);

            Assert.AreEqual(shoppingCart.Total, 171);
        }

        [TestMethod]
        public void ShouldGiveMoreDiscount()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddDiscount(100, 5);
            shoppingCart.AddDiscount(200, 10);

            shoppingCart.AddItem(70, 2);
            shoppingCart.AddItem(50, 2);

            Assert.AreEqual(shoppingCart.Total, 216);
        }
    }
}
