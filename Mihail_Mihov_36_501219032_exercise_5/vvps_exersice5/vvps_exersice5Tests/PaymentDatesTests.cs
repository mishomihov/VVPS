using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvps_exersice5;
using System;
using System.Collections.Generic;
using System.Text;

namespace vvps_exersice5.Tests
{
    [TestClass()]
    public class PaymentDatesTests
    {
        [TestMethod()]
        public void CalculateFuturePaymentDateTest()
        {
            //arrange faza
            var pd = new PaymentDates();
            DateTime sampleDate = DateTime.Parse("7/6/2011");
            //act faza
            DateTime resultDateWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);
            //assert faza
            Assert.AreEqual(sampleDate.AddDays(30),resultDateWhichShouldBe30DaysLater);
        }

        [TestMethod()]
        public void CalculateFuturePaymentDate_InputCauseesSundayDate_DateReturnedIsMonday()
        {
            //arrange
            var pd = new PaymentDates();
            DateTime sampleDate = DateTime.Parse("6/8/2011");
            //act
            DateTime resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);
            //assert
            Assert.AreEqual(DayOfWeek.Monday, resultDateWhichShouldBeMonday.DayOfWeek);
        }

    }
}

namespace vvps_exersice5Tests
{
    class PaymentDatesTests
    {
    }
}
