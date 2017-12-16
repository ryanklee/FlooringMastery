using FM.BLL;
using FM.Models;
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
    public class ValidationTests
    {
        [Test]
        [TestCase("01011000", false)]
        [TestCase("01013000", true)]
        public void OrderDatesFailPassFuturePastValidation(string dateTime, bool expectedResult)
        {
            Validation validate = new Validation();
            ValidationResponse response = validate.OrderDateIsInFuture(dateTime);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [Test]
        [TestCase("Acme", true)]
        [TestCase("Acme Brand", true)]
        [TestCase("Acme, LLC", true)]
        [TestCase("Acme, INC.", true)]
        [TestCase("Acme1000", true)]
        [TestCase("", false)]
        [TestCase("Acme!", false)]
        public void CustomerNameContainsOnlyNumberDatesSpacesCommasAndPeriods(string customerName, bool expectedResult)
        {
            Validation validate = new Validation();
            ValidationResponse response = validate.CustomerName(customerName);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [Test]
        [TestCase("not a number", false)]
        [TestCase("-5", false)]
        [TestCase("0", false)]
        [TestCase("0.1", true)]
        [TestCase("5", true)]
        [TestCase("5.0", true)]
        public void BadAreaInputFails(string area, bool expectedResult)
        {
            Validation validate = new Validation();
            ValidationResponse response = validate.Area(area);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
