package com.company;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class CalendarTest {


    @Test
    void getBornDate() {
        Calendar calendar = new Calendar(1);
        String date=Calendar.getBornDate(2,15);
        Assertions.assertEquals(date, calendar.getBornDate(2,15));

    }

    @Test
    void getDayOfWeek(){
        Calendar calendar = new Calendar(1);
        String day =calendar.getDayOfWeek(calendar.getBornDate(2,15));
        Assertions.assertEquals(day, calendar.getDayOfWeek(calendar.getBornDate(2,15)));

    }
}