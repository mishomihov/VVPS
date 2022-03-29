using System;
using System.Collections.Generic;
using System.Text;

namespace vvps_exersice5
{
    public class PaymentDates
    {
        public DateTime CalculateFuturePaymentDate(DateTime startingDate)
        {
            var tempDate = startingDate.AddDays(30);

            switch(tempDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    tempDate=tempDate.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    tempDate = tempDate.AddDays(1);
                    break;
            }
            return tempDate;
        }
    }
}
