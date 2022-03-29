package com.company;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.*;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

public class Calendar {
    public static final int CONST = 1;
    public static final int MAX_DAY = 31;
    public static final int MAX_MONTH = 12;
    public static final int MAX_HOUR = 23;
    public static final int MAX_MIN = 59;
    int day;
    int month;
    int year;
    int hour;
    int min;
    String timeZone;

    Calendar(){
        Scanner scan=new Scanner(System.in);
        do {
            System.out.print("Day:");
            this.day = scan.nextInt();
        }while(this.day < CONST || this.day > MAX_DAY);

        do{
            System.out.print("Month:");
            this.month = scan.nextInt();
        }while(this.month < CONST || this.month > MAX_MONTH);
            System.out.print("Year:");
            this.year=scan.nextInt();
    }

    Calendar(String s){
        Scanner scan=new Scanner(System.in);
        do {
            System.out.print("Day:");
            this.day = scan.nextInt();
        }while(this.day < CONST || this.day > MAX_DAY);

        do{
            System.out.print("Month:");
            this.month = scan.nextInt();
        }while(this.month < CONST || this.month > MAX_MONTH);
        System.out.print("Year:");
        this.year=scan.nextInt();
        do{
            System.out.print("Hour:");
            this.hour = scan.nextInt();
        }while(this.month < CONST || this.month > MAX_HOUR);
        do{
            System.out.print("Minutes:");
            this.min = scan.nextInt();
        }while(this.month < CONST || this.month > MAX_MIN);
    }

    public Calendar(int day, int month, int year) {
        this.day = day;
        this.month = month;
        this.year = year;
    }
    Calendar(int i){}

    private String getDateString(){
        return day+"/"+month+"/"+year;
    }

    static private long calculateDifference(Calendar date1,Calendar date2){
        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        Date d1 = null;
        Date d2 = null;
        try{
            d1 = format.parse(date1.getDateString());
            d2 = format.parse(date2.getDateString());}
        catch (ParseException e){
            System.out.println("Invalid date");
        }
        long difference = d2.getTime() - d1.getTime();
        return difference / (24 * 60 * 60 * 1000);
    }

    static private long calculateDifference(Calendar date1){
        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        Date d1 = null;
        Date d2 = null;
        java.util.Date date = new java.util.Date(System.currentTimeMillis());
        Instant instant = date.toInstant();
        LocalDateTime ldt = instant.atZone(ZoneId.systemDefault()).toLocalDateTime();
        DateTimeFormatter fmt = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        try{
            d1 = format.parse(date1.getDateString());
            d2 = format.parse(ldt.format(fmt));
        }
        catch (ParseException e){
            System.out.println("Invalid date");
        }
        long difference = d2.getTime() - d1.getTime();
        return difference / (24 * 60 * 60 * 1000);
    }

    static public String getDayOfWeek(Calendar date){
        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        Date date1 = null;
        try {
            date1 = format.parse(date.getDateString());
        } catch (ParseException e) {
            System.out.println("Invalid date");
        }
        DateFormat format2 = new SimpleDateFormat("EEEE");
        return format2.format(date1);
    }

    static public String getDayOfWeek(String date){
        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        Date date1 = null;
        try {
            date1 = format.parse(date);
        } catch (ParseException e) {
            System.out.println("Invalid date");
        }
        DateFormat format2 = new SimpleDateFormat("EEEE");
        return format2.format(date1);
    }

    static public void printTimeZoneDifferences(Calendar startDate, Calendar endDate){
        ZoneId zone1 = ZoneId.of(startDate.timeZone);
        ZoneId zone2 = ZoneId.of(endDate.timeZone);
        LocalDateTime dateTime = LocalDateTime.of(startDate.year, startDate.month, startDate.day, startDate.hour, startDate.min);
        ZonedDateTime date1 = ZonedDateTime.of(dateTime, zone1);
        ZonedDateTime date2 = date1.withZoneSameInstant(zone2);
        System.out.println("Difference between the two time zones is "+date2.getOffset().getTotalSeconds()/60/60+" hours.");
        endDate.day=date2.getDayOfMonth();
        endDate.month=date2.getMonthValue();
        endDate.year=date2.getYear();
        endDate.hour=date2.getHour();
        endDate.min=date2.getMinute();
        System.out.println("Date in "+startDate.timeZone+ " is: "+ startDate.getDateString());
        System.out.println("Date in "+endDate.timeZone+ " is: "+ endDate.getDateString());
    }

    static public ArrayList<String> getAllTimezonesFromFile(){
        BufferedReader reader;
        ArrayList<String> tzList= new ArrayList<>();
        try {
            reader = new BufferedReader(new FileReader(
                    "timezones.txt"));
            String line = reader.readLine();
            String noSpaces = line.replaceAll("\\s", "");
            String timezone=noSpaces.substring(0,noSpaces.indexOf("("));
            tzList.add(timezone);
            while (line != null) {
                line = reader.readLine();
                if(line!=null) {
                    noSpaces = line.replaceAll("\\s", "");
                    timezone=noSpaces.substring(0,noSpaces.indexOf("("));
                    tzList.add(timezone);
                }
            }
            reader.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    return tzList;
    }

    static public String getBornDate(int months, int days){
        int totalDays=(months*30)+days;
        Date borndate = Date.from( Instant.now().minus( Duration.ofDays( totalDays ) ) );
        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        return format.format(borndate);
    }

    public static void main(String[] args) {
        int option;
        Scanner scan=new Scanner(System.in);
        System.out.println("1.Difference between 2 dates.\n" +
                "2.Get day of week by date.\n" +
                "3.Get timezone difference.\n" +
                "4.Days passed since date\n" +
                "5.Which date am I born on?\n" +
                "6.Which day am I born on?\n"+
                " Enter:");
        option = scan.nextInt();
        switch (option) {
            case 1 -> {
                System.out.println("Starting date:");
                Calendar startDate = new Calendar();
                System.out.println("Ending date:");
                Calendar endDate = new Calendar();
                System.out.println(calculateDifference(startDate, endDate) + " days");
            }
            case 2 -> {
                System.out.println("Enter a date for a day of week display:");
                Calendar dayOfWeek = new Calendar();
                System.out.println(getDayOfWeek(dayOfWeek));
            }
            case 3 -> {
                Calendar startDate = new Calendar("");
                Calendar endDate = new Calendar(1);
                System.out.println("\nChoose mode\n1.Enter timezone Manually");
                System.out.println("2.Choose timezone from list");
                int timeZoneMode = scan.nextInt();
                switch (timeZoneMode) {
                    case 1 -> {
                        System.out.println("Enter timezone for first date:");
                        startDate.timeZone = scan.next();
                        System.out.println("Enter timezone for second date:");
                        endDate.timeZone = scan.next();
                    }
                    case 2 -> {
                        int index;
                        ArrayList<String> timeZones = getAllTimezonesFromFile();
                        int i = 1;
                        for (Object s : timeZones) {
                            System.out.println(i + "." + s.toString());
                            i++;
                        }
                        do {
                            System.out.println("Enter Timezone index for first region:");
                            index = scan.nextInt();
                        }while(index<0 && index>timeZones.size());

                        startDate.timeZone = timeZones.get(index - 1);
                        System.out.println("Enter index timezone for second region:");
                        index = scan.nextInt();
                        endDate.timeZone = timeZones.get(index - 1);
                    }
                }
                printTimeZoneDifferences(startDate, endDate);
            }
            case 4->{
                System.out.println("Starting date:");
                Calendar startDate = new Calendar();
                System.out.println(calculateDifference(startDate) + " days");
            }
            case 5-> {
                int days, months;
                do {
                    System.out.print("Months:");
                    months = scan.nextInt();
                } while (months < 0);
                do {
                    System.out.print("Days:");
                    days = scan.nextInt();
                } while (days < 0 || days > MAX_DAY);
                System.out.println("You're born on: " + getBornDate(months, days));
                break;
            }
            case 6-> {
                int days, months;
                do {
                    System.out.print("Months:");
                    months = scan.nextInt();
                } while (months < 0);
                do {
                    System.out.print("Days:");
                    days = scan.nextInt();
                } while (days < 0 || days > MAX_DAY);
                System.out.println("You're born on: "+getDayOfWeek(getBornDate(months,days)));
                break;
            }
            default -> System.out.println("No such case.");
        }

    }
}
