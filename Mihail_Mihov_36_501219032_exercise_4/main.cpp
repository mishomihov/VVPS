#include <iostream>
#include <fstream>
#include <sstream>
using namespace std;

fstream file;
string citiesNames[100];
string citiesHourZones[100];
int nOfCities;

void loadCities()
{
    string nOfCitiesStr;

    file.open("cities.txt", ios::in); //otvarqme faila za chetene

    getline(file,nOfCitiesStr); //chetem broq na gradovete vyv faila

    stringstream intValue(nOfCitiesStr); //tuk prevryshtame stringa s broq na gradovete v int
    intValue >> nOfCities;

    for(int i=0;i<nOfCities;i++)
    {
        getline(file,citiesNames[i]); //chetem imenata na gradovete edno po edno i gi zapisvame v masiva ot stringove
    }

    for(int i=0;i<nOfCities;i++)
    {
        getline(file,citiesHourZones[i]); //chetem chasovite razliki na gradovete i gi zapisvame v masiva ot stringove
    }

    file.close();

}

void enterCity()
{
    nOfCities++;

    cout << "Enter the city name: " << endl;
    cin >> citiesNames[nOfCities-1];

    cout << "Enter the city time zone (example: +2 or -1):" << endl;
    cin >> citiesHourZones[nOfCities-1];
}

int findHoursDifference(int firstCity, int secondCity)
{
    int firstCityHourZone;
    int secondCityHourZone;
    int difference;

    firstCity = firstCity - 1; //namalqvame chislata, za da moje masivite da rabotqt s tqh
    secondCity = secondCity - 1;

    if(citiesHourZones[firstCity] == citiesHourZones[secondCity]) //ako dvata grada sa s ednakvi chasovi zoni
    {
        return 0;
    }

    stringstream intValue(citiesHourZones[firstCity]); //prevryshtame stoinostta ot string v int
    intValue >> firstCityHourZone;

    stringstream intValue2(citiesHourZones[secondCity]);//prevryshtame stoinostta ot string v int
    intValue2 >> secondCityHourZone;

    difference = firstCityHourZone - secondCityHourZone; //presmqtame razlikata v chasovite zoni

    if(difference < 0) //ako se poluchi otricatelno chislo go prevryshtame v polojitelno
    {
        difference = abs(difference);
    }


    return difference;
}

void printCurrentCities()
{
    for(int i=0;i<nOfCities;i++)
    {
        cout << i+1 << ". " << citiesNames[i] << endl;
    }
}

//ot tuk zapochvat funkciite za 2-ro upr, nagore za sa 3-to

struct Date {
    int d, m, y; //d - den, m - mesec, y - godina
};

//zapazvame dnite na vsichki meseci
const int monthDays[12]
    = { 31, 28, 31, 30, 31, 30,
    31, 31, 30, 31, 30, 31 };

//tuk broime visokosnite godini
int countLeapYears(Date d)
{
    int years = d.y;

    //proverqvame dali godinata e visokosna
    if (d.m <= 2)
        years--;

    //visokosna e ako e kratna na 4, kratna na 400, no ne i na 100
    return years / 4
        - years / 100
        + years / 400;
}

//tuk vryshtame razlikata
int getDifference(Date dt1, Date dt2)
{

    //sybirame broq na dnite v godinite i dnite samostoqtelno
    long int n1 = dt1.y * 365 + dt1.d;

    //dobavqme dnite ot mesecite
    for (int i = 0; i < dt1.m - 1; i++)
        n1 += monthDays[i];

    //dobavqme den za vsqka visokosna godina
    n1 += countLeapYears(dt1);


    //syshtoto za 2rata godina
    long int n2 = dt2.y * 365 + dt2.d;
    for (int i = 0; i < dt2.m - 1; i++)
        n2 += monthDays[i];
    n2 += countLeapYears(dt2);

    //vryshta razlikata mejdu dvete
    return (n2 - n1);
}

int dayofweek(int d, int m, int y)
{
    static int t[] = { 0, 3, 2, 5, 0, 3,
                       5, 1, 4, 6, 2, 4 };
    y -= m < 3;
    return ( y + y / 4 - y / 100 +
             y / 400 + t[m - 1] + d) % 7;
}

void daysBetweenTwoDates()
{
    Date d1,d2; //d1 - today's date, d2 - the previous date

    cout << "Enter the today's date - 1. day, 2. month, 3. year" << endl;
    cin >> d1.d;
    cin >> d1.m;
    cin >> d1.y;

    cout << "Enter the previous date - 1. day, 2. month, 3. year" << endl;
    cin >> d2.d;
    cin >> d2.m;
    cin >> d2.y;

    cout << "The days passed between these two dates - " << getDifference(d1,d2) << endl;
}

Date calculateBirthDate()
{
    Date d1; //d1 - today's date

    cout << "Enter the today's date - 1. day, 2. month, 3. year" << endl;
    cin >> d1.d;
    cin >> d1.m;
    cin >> d1.y;

    int currentMonths, currentDays, totalDays;
    cout << "Enter your months: " << endl;
    cin >> currentMonths;
    cout << "Enter your days" << endl;
    cin >> currentDays;

    totalDays = currentMonths*30 + currentDays;

    for(int i=0;i<totalDays;i++)
    {
        d1.d--;

        if(d1.d == 0 && d1.m == 1)
        {
            d1.y--;
            d1.m = 12;
            d1.d = monthDays[10];
        }else if(d1.d == 0)
        {
            d1.m--;
            d1.d = monthDays[(d1.m - 1)];
        }
    }

    return d1;

}

void calculateBirthDayOfWeek()
{
    Date dt2 = calculateBirthDate();
    int day = dayofweek(dt2.d, dt2.m, dt2.y);

    switch(day)
    {
    case 1:
        cout << "Ponedelnik" << endl;
        break;
    case 2:
        cout << "Vtornik" << endl;
        break;
    case 3:
        cout << "Srqda" << endl;
        break;
    case 4:
        cout << "Chetvurtuk" << endl;
        break;
    case 5:
        cout << "Petyk" << endl;
        break;
    case 6:
        cout << "Sybota" << endl;
        break;
    case 7:
        cout << "Nedelq" << endl;
        break;
    }

}

// Driver code
int main()
{
    cout << "Choose which exercise you want to use the program for - 2-nd, 3-rd or 4-th" << endl;

    int choice;

    cin >> choice;

    if(choice == 3)
    {
        cout << "Loading cities from the text file..." << endl;
        loadCities();

        while(1)
        {
            cout << "1 - enter a new city, 2 - find difference in hours between cities, 3 - print the current entered cities" << endl;
            cin >> choice;

            if(choice == 1)
            {
                enterCity();
            }else if(choice == 2)
            {
                int firstCity, SecondCity;
                printCurrentCities();

                cout << "Enter the first city:" << endl;
                cin >> firstCity;

                cout << "Enter the second city:" << endl;
                cin >> SecondCity;

                cout << findHoursDifference(firstCity,SecondCity) << endl;
            }else if(choice == 3)
            {
                printCurrentCities();
            }else
            {
                cout << "Wrong choice" << endl;
            }
        }

    }else if(choice == 2)
    {
        Date dt1;
        Date dt2;

        cout << "Enter the first date - first day, second month and the last is the year. Click enter after each part of the date: " << endl;
        cin >> dt1.d;
        cin >> dt1.m;
        cin >> dt1.y;

        cout << "Enter the second date - first day, second month and the last is the year. Click enter after each part of the date: " << endl;
        cin >> dt2.d;
        cin >> dt2.m;
        cin >> dt2.y;


        cout << "Difference between two dates is "
            << getDifference(dt1, dt2) << endl;

        cout << "Enter the date you want to find the day of the week for - first day, second month and the last is the year. Click enter after each part of the date: " << endl;
        cin >> dt2.d;
        cin >> dt2.m;
        cin >> dt2.y;

        int day = dayofweek(dt2.d, dt2.m, dt2.y);

        switch(day)
        {
        case 1:
            cout << "Ponedelnik" << endl;
            break;
        case 2:
            cout << "Vtornik" << endl;
            break;
        case 3:
            cout << "Srqda" << endl;
            break;
        case 4:
            cout << "Chetvurtuk" << endl;
            break;
        case 5:
            cout << "Petyk" << endl;
            break;
        case 6:
            cout << "Sybota" << endl;
            break;
        case 7:
            cout << "Nedelq" << endl;
            break;
        }
    }else if(choice == 4){
        int choice4choice;
        cout << "Choose which function you want to use - 1,2,3" << endl;
        cin >> choice4choice;

        switch (choice4choice)
        {
        case 1:
            daysBetweenTwoDates();
            break;
        case 3:
            calculateBirthDayOfWeek();
            break;
        case 2:
            Date d1 = calculateBirthDate();
            cout << "Your born date is: " << d1.d << " " << d1.m << " " << d1.y << endl;
            break;
        }

    }else
    {
        cout << "Wrong input";
    }

    return 0;
}
