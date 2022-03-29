using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvps_exersice5;
using System;
using System.Collections.Generic;
using System.Text;

namespace vvps_exersice5.Tests
{
    [TestClass()]
    public class CalendarTests
    {
        [TestMethod()]
        public void calculateDaysFromPastDateToTodayTest()
        {
            var userInput = new Calendar();

            int expectedResult = 2;

            int day = 1, month = 3, year = 2022;

            Assert.AreEqual(expectedResult, Convert.ToInt32(userInput.calculateDaysFromPastDateToToday(day, month, year)));

            
        }

        [TestMethod()]
        public void calculateBirthDateandDayOfWeekTest()
        {
            var userInput = new Calendar();

            int days = 3, months = 0;

            DateTime testDate = DateTime.Parse("1/3/2022");

            Assert.AreEqual(DayOfWeek.Monday, userInput.calculateBirthDateandDayOfWeek(3, 0).DayOfWeek);
        }

        [TestMethod()]
        public void calculateBirthDateandDayOfWeekTest2()
        {
            var userInput = new Calendar();

            int days = 2, months = 0;

            DateTime testDate = DateTime.Parse("1/3/2022");

            
            Assert.AreEqual(testDate, userInput.calculateBirthDateandDayOfWeek(days, months));
        }
    }
}