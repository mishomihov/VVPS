package com.company;

import java.time.DayOfWeek;
import java.time.LocalDate;

public class PaymentDates {

    public LocalDate CalculateFuturePaymentDate(LocalDate startingDate)
    {
        LocalDate tempDate = startingDate.plusDays(30);

        switch (tempDate.getDayOfWeek())
        {
            case SATURDAY: {
                tempDate = tempDate.plusDays(2);
                break;
            }
            case SUNDAY: {
                tempDate = tempDate.plusDays(1);
                break;
            }
        }
        return tempDate;
    }
}
