using FM.BLL;
using FM.BLL.Controllers;
using FM.BLL.Factories;
using FM.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Tests
{
    [TestFixture]
    public class MockRepositoryTests
    {
        [Test]
        public void CanLoadOrderMockData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrder("06012013");

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Order.ElementAt(0).OrderNumber);
        }

        [Test]
        public void ReturnFalseyResponseOnBadOrderdate()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrder("00000000");

            Assert.IsFalse(response.Order.Any());
            Assert.IsFalse(response.Success);
        }
    }
}