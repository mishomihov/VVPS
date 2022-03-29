using System;
using System.Collections.Generic;
using System.Text;

namespace vvps_exersice5
{
    public class Calendar
    {
        public double calculateDaysFromPastDateToToday(int day, int month, int year)
        {
           
            DateTime today = DateTime.Today;

            DateTime pastDate = new DateTime(year, month, day);

            return (today - pastDate).TotalDays;
        }

        public DateTime calculateBirthDateandDayOfWeek(int days, int months)
        {

            DateTime today = DateTime.Today;

            today = today.AddMonths(-months);
            today = today.AddDays(-days);

            Console.WriteLine(today);
            Console.WriteLine(today.DayOfWeek);

            return today;
        }
    }
}
