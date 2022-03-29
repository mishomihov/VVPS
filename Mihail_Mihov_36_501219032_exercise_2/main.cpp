#include <iostream>
using namespace std;

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

// Driver code
int main()
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

    return 0;
}
