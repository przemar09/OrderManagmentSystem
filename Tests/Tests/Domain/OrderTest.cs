using NUnit.Framework;
using OrderManagmentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentSystem.Tests.Domain
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void CreatingNewOrderWithCorrectDataShouldSucceed()
        {
            var order = new Order("nr1", 23, "Bike", 1, 230.00);
            Assert.AreEqual(order.ClientId, "nr1");
            Assert.AreEqual(order.RequestId, 23);
            Assert.AreEqual(order.Name, "Bike");
            Assert.AreEqual(order.Quantity, 1);
            Assert.AreEqual(order.Price, 230.00);
        }

        [Test]
        public void Cannot_Create_With_Null_ClientId()
        {
            Assert.Throws<ArgumentNullException> (() => new Order(null, 23, "Bike", 1, 250.00));
        }

        [Test]
        public void Client_Id_Cannot_Contain_Space()
        {
            Assert.Throws<Exception>(() => new Order("id 2", 23, "Bike", 1, 250.00));
        }

        [Test]
        public void Client_Id_Cannot_Be_Longer_than_6_characters()
        {
            Assert.Throws<Exception>(() => new Order("id23431", 23, "Bike", 1, 250.00));
        }
    }
}
