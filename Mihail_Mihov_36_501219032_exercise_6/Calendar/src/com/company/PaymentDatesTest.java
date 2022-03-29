package com.company;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.time.LocalDate;

import static org.junit.jupiter.api.Assertions.*;

class PaymentDatesTest {

    @Test
    void calculateFuturePaymentDate() {
        PaymentDates pd = new PaymentDates();
        LocalDate sampleDate = LocalDate.parse("2022-06-07");
        //act phase
        LocalDate resultDateWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);
        //assert phase
        Assertions.assertEquals(sampleDate.plusDays(30), resultDateWhichShouldBe30DaysLater);
    }

    @Test
    void calculateFuturePaymentDateSaturday() {
        PaymentDates pd = new PaymentDates();
        LocalDate sampleDate = LocalDate.parse("2022-03-12");
        //act phase
        LocalDate resultDateWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);
        //assert phase
        Assertions.assertEquals(sampleDate.plusDays(30), resultDateWhichShouldBe30DaysLater);
    }
    @Test
    void calculateFuturePaymentDateSunday() {
        PaymentDates pd = new PaymentDates();
        LocalDate sampleDate = LocalDate.parse("2022-03-13");
        //act phase
        LocalDate resultDateWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);
        //assert phase
        Assertions.assertEquals(sampleDate.plusDays(30), resultDateWhichShouldBe30DaysLater);
    }
}