using FM.BLL;
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

            OrderbatchLookupResponse response = manager.LookupOrderbatch("06012013");

            Assert.IsNotNull(response.Orderbatch);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Orderbatch[0].OrderNumber);
        }
    }
}
