#include <iostream>
#include <cmath>
#include <iomanip>
#include <climits> // For ULLONG_MAX
using namespace std;

/* Problem1: Car Rental Company. */

// #define FEE_PER_8HOURS 25
// #define FEE_PER_HOUR 5
// #define CHARGE_PER_DAY 50
// #define TAX_PER_HOUR 0.5

// void CalculateCharges(int hours1, int hours2, int hours3) {
//     int charges[3] = {0};
//     int hours[3] = {hours1, hours2, hours3};
//     for(int i = 0; i < 3; i++){
//         if(hours[i] >= 24){
//             charges[i] = (hours[i]/24) * CHARGE_PER_DAY + (hours[i] % 24) * FEE_PER_HOUR
//                         + hours[i] * TAX_PER_HOUR;
//         }
//         else{   // Assume minimum number of hours is 8
//             charges[i] = FEE_PER_8HOURS + (hours[i] - 8) * FEE_PER_HOUR
//                         + hours[i] * TAX_PER_HOUR;
//         }
//     }
//     // Column headers
//     cout << left << setw(10) << "Car"
//     << right << setw(15) << "Hours"
//     << right << setw(15) << "Charge" << '\n';
//     // Separate line
//     cout << setfill('-') << setw(40) << "" << setfill(' ') << '\n';
//     for(int i = 0; i < 3; i++){
//         cout << left << setw(10)<< i+1
//         << right << setw(15) << hours[i]
//         << right << setw(15) << charges[i] << '\n';
//     }
//     cout << left << setw(10) << "Total"
//     << right << setw(15) << hours[0] + hours[1] + hours[2]
//     << right << setw(15) << charges[0] + charges[1] + charges[2] << '\n';
// }

// int main(){
//     int hours[3] = {0};
//     for(int i = 0; i < 3; i++){
//         cout << "Enter hours parked for car " << (i + 1) << ": ";
//         cin >> hours[i];
//     }
//     CalculateCharges(hours[0], hours[1], hours[2]);
//     return 0;
// }

/* Problem2: 2.Define a function called hypotenuse that calculates
 the length of the hypotenuse of a right triangle when
 the other two sides are given. The function should take
 two arguments of type double and return the hypotenuse as a double.*/

// double hypotenuse(double a, double b) {
//     return sqrt(a * a + b * b);
// }
// int main(){
//     double side1, side2;
//     cout << "Enter the length of the first side of the right triangle: ";
//     cin >> side1;
//     cout << "Enter the length of the second side of the right triangle: ";
//     cin >> side2;
//     cout << "The length of the hypotenuse is: " << hypotenuse(side1, side2) << endl;
//     return 0;
// }

/* Problem3: Write a function that reads three
 nonzero double values (a, b, c) as the sides of a triangle,
 and calculates and returns the area of the triangle as a double variable.
 It should also check whether the numbers represent
 the sides of a triangle before calculating the area.
*/
// double Area(double a, double b, double c){
//     if((a + b > c) && (a + c > b) && (b + c > a)){
//         double s = (a+b+c) / 2;
//         double area = sqrt(s*(s-a)*(s-b)*(s-c)); 
//         return area;
//     }
//     return -1; // return -1 to indicate invalid triangle sides
// }
// int main(){
//     double side1, side2, side3;
//     cout << "Enter the length of the first side of the triangle: ";
//     cin >> side1;
//     cout << "Enter the length of the second side of the triangle: ";
//     cin >> side2;
//     cout << "Enter the length of the third side of the triangle: ";
//     cin >> side3;
//     double area = Area(side1, side2, side3);
//     if(area == -1){
//         cout << "The given sides do not form a valid triangle." << endl;
//     }
//     else{
//         cout << "The area of the triangle is: " << area << endl;
//     }
//     return 0;
// }

/* Problem4: 4.Write a function that reads three nonzero integers
 and determines whether they are the sides of a right-angled triangle.
 The function should take three integer arguments and
 return 1 (true) if the arguments comprise a right-angled triangle,
 and 0 (false) otherwise. Use this function in a program that inputs a series of sets of integers.
*/

// int CheckTriangle(int a, int b, int c){
//     int res = 0;
//     if((a*a + b*b == c*c) || (a*a + c*c == b*b) || (b*b + c*c == a*a)){
//         res = 1;
//     }
//     else if((a + b > c) && (a + c > b) && (b + c > a)){
//         res = 0;
//     }
//     else{
//         res = -1; // not a triangle
//     }
//     return res;
// }
// int main(){
//     int side1, side2, side3;
//     cout << "Enter the length of the first side of the triangle: ";
//     cin >> side1;
//     cout << "Enter the length of the second side of the triangle: ";
//     cin >> side2;
//     cout << "Enter the length of the third side of the triangle: ";
//     cin >> side3;
//     int res = CheckTriangle(side1, side2, side3);
//     if(res == 1){
//         cout << "The given sides form a right-angled triangle." << endl;
//     }
//     else if(res == 0){
//         cout << "The given sides do not form a right-angled triangle." << endl;
//     }
//     else{
//         cout << "The given sides do not form a triangle." << endl;
//     }
//     return 0;
// }

/* Problem5: 5.Implement the following double functions:
a) Function toYen takes an amount in US dollars and returns the Yen equivalent.
b) Function toEuro takes an amount in US dollars and return the Euro equivalent
c) Use these functions to write a program that prints charts showing the Yen
and Euro equivalents of a range of dollar amounts.
Print the outputs in a neat tabular format. Use an exchange rate of 1 USD = 118.87 Yen
and 1 USD = 0.92 Euro.*/

// double toYen(double usd){
//     return usd * 118.87;
// }

// double toEuro(double usd){
//     return usd * 0.92;
// }
// int main(){
//     double usd = 0;
//     double amounts[] = {10, 15, 20, 25, 30, 35};

//     // Column headers
//     cout << left << setw(10) << "USD"
//     << right << setw(15) << "Yen"
//     << right << setw(15) << "Euro" << '\n';
//     // Separate line
//     cout << setfill('-') << setw(40) << "" << setfill(' ') << '\n';
//     for(int i = 0; i < 6; i++){
//         usd = amounts[i];
//         cout << left << setw(10) << fixed << setprecision(2) << usd
//         << right << setw(15) << fixed << setprecision(2) << toYen(usd)
//         << right << setw(15) << fixed << setprecision(2) << toEuro(usd) << '\n';
//     }
//     return 0;
// }

/* Problem6: 6.Write a function that takes an integer and returns
 the sum of its digits. For example, given the number 7631,
 the function should return 17.*/
// int SumDigits(int num){
//     int sum = 0;
//     while(num > 0){
//         sum += num % 10;
//         num /= 10;
//     }
//     return sum;
// }
// int main(){
//     int number;
//     cout << "Enter an integer: ";
//     cin >> number;
//     number = abs(number); // Ensure the number is non-negative
//     cout << "The sum of the digits is: " << SumDigits(number) << endl;
//     return 0;
// }

/* Problem7: 7.Write a recursive function power(base, exponent) that
 when invoked returns baseexponent For example,
 power(3, 4) = 3 * 3 * 3 * 3. Assume that exponent is 
 an integer greater than or equal to 1.*/
// long Exponen(int base, int exp){
//     long res = 0;
//     if(exp == 1){
//         res = base;
//     }
//     else{
//         res = base * Exponen(base, exp-1);
//     }
//     return res;
// }
// int main(){
//     int base, exp;
//     cout << "Enter the base integer: ";
//     cin >> base;
//     cout << "Enter the exponent integer: ";
//     cin >> exp;
//     cout << "The result is: " << Exponen(base, exp) << endl;
//     return 0;
// }



/* Problem8: The Fibonacci series 0, 1, 1, 2, 3, 5, 8, 13, 21,
… begins with the terms 0 and 1 and has the property
that each succeeding term is the sum of the two preceding terms. 
a) Write a non recursive function fibonacci(n) that calculates
the nth Fibonacci number. Use unsigned int for the function’s
parameter and unsigned long long int for its return type. 
b) Determine the largest Fibonacci number that can be printed on your system.*/
// unsigned long long Fibonacci(unsigned int term){
//     unsigned long long res = 0;
//     term -= 1; // Adjust for zero-based index
//     if(term == 0){res = 0;}
//     else if(term == 1){res = 1;}
//     else{
//         unsigned long long fib1 = 0;
//         unsigned long long fib2 = 1;
//         unsigned long long nextFib = 1;
//         for(int i = 2; i <= term; i++){
//             nextFib = fib1 + fib2;
//             fib1 = fib2;
//             fib2 = nextFib;
//         }
//         res = nextFib;
//     }
//     return res;
// }

// unsigned long long DetermLargestFibonacci(){
//     unsigned long long fib1 = 0;
//     unsigned long long fib2 = 1;
//     unsigned long long nextFib = 1;
//     // Check for overflow before adding
//     while(fib2 <= (ULLONG_MAX - fib1)){   
//         nextFib = fib1 + fib2;
//         fib1 = fib2;
//         fib2 = nextFib;
//     }
//     return fib2;
// }

// int main(){
//     int term;
//     cout << "Enter the number of Fibonacci series term: ";
//     cin >> term;
//     cout << "The " << term << " term of the Fibonacci series is: " << Fibonacci(term) << endl;
//     cout << "The largest Fibonacci number that can be printed is: " << DetermLargestFibonacci() << endl;
//     cout << ULLONG_MAX << endl;
//     return 0;
// }

/* Problem9: 9.Use a one-dimensional array to solve the following problem.
A company pays its salespeople on a commission basis. The salespeople
receive $200 per week plus 9% of their gross sales for that week.
For example, a salesperson who grosses $3,000 in sales in a week
receives $200 plus 9% of $3,000, or a total of $470.
Write a C program (using an array of counters) that determines how many
of the salespeople earned salaries in each of the following ranges
(assume that each salesperson’s salary is truncated to an integer amount):
a) $200–299
b) $300–399
c) $400–499
d) $500–599
e) $600–699
f) $700–799
g) $800–899
h) $900–999
i) $1000 and over*/

// #define RANGE_COUNT 9
// #define BASE_SALARY 200
// #define COMMISION_RATIO 0.09

// int main(){
//     int range_counters[RANGE_COUNT] = {0}; 
//     int sales_people = 0;
//     cout << "Enter the number of sales people: ";
//     cin >> sales_people;
//     int gross_sales = 0, total_salary = 0;
//     for(int i = 0; i < sales_people; i++){
//         cout << "Enter the gross sales for sales person " << (i + 1) << ": ";
//         cin >> gross_sales;
//         total_salary = (int)(BASE_SALARY + gross_sales * COMMISION_RATIO);
//         if((total_salary >= 200) && (total_salary < 300)){range_counters[0] += 1;}
//         else if((total_salary >= 300) && (total_salary < 400)){range_counters[1] += 1;}
//         else if((total_salary >= 400) && (total_salary < 500)){range_counters[2] += 1;}
//         else if((total_salary >= 500) && (total_salary < 600)){range_counters[3] += 1;}
//         else if((total_salary >= 600) && (total_salary < 700)){range_counters[4] += 1;}
//         else if((total_salary >= 700) && (total_salary < 800)){range_counters[5] += 1;}
//         else if((total_salary >= 800) && (total_salary < 900)){range_counters[6] += 1;}
//         else if((total_salary >= 900) && (total_salary < 1000)){range_counters[7] += 1;}
//         else{range_counters[8] += 1;}
//     }
//     cout << "Salary Range\tNumber of Sales People" << endl;
//     cout << "----------------------------------------" << endl;
//     for(int i = 0; i < RANGE_COUNT; i++){
//         if(i == RANGE_COUNT - 1){
//             cout << "$1000 and over\t" << range_counters[i] << endl;
//         }
//         else{
//             cout << "$" << (i + 2) * 100 << " - $" << (i + 3) * 100 << "\t\t" << range_counters[i] << endl;
//         }
//     }
//     return 0;
// }

/* Problem10: 10.Write loops that perform each of the following
one-dimensional array operations:
a) Read the 20 elements of double array sales from the keyboard.
b) Add 1000 to each of the 75 elements of double array allowance.
c) Initialize the 50 elements of integer array numbers to zero.
d) Print the 10 values of integer array GPA in column format.*/

// int main(){
//     // a) Read the 20 elements of double array sales from the keyboard.
//     double sales[20];
//     for(int i = 0; i < 20; i++){
//         cout << "Enter sales amount for element " << (i + 1) << ": ";
//         cin >> sales[i];
//     }
//     // b) Add 1000 to each of the 75 elements of double array allowance.
//     double allowance[75] = {0};
//     for(int i = 0; i < 75; i++){
//         allowance[i] += 1000;
//     }
//     // c) Initialize the 50 elements of integer array numbers to zero.
//     int arr[50] = {0}; // All elements are initialized to zero
//     // d) Print the 10 values of integer array GPA in column format.
//     float GPA[10] = {3.5, 3.7, 3.2, 3.8, 3.0, 3.9, 2.8, 3.6, 3.4, 3.1};
//     cout << "GPA Values:" << endl;
//     for(int i = 0; i < 10; i++){
//         cout << "GPA[" << i << "]: " << GPA[i] << endl;
//     }
//     return 0;
// }

/* Problem11: 11.Use one-dimensional arrays to solve the following problem.
Read in two sets of numbers, each having 10 numbers.
After reading all values, display the unique elements common to both sets of numbers.*/

int main(){
    int set1[10];
    for(int i = 0; i < 10; i++){
        cout << "Enter element " << (i + 1) << " as an integer for set1: ";
        cin >> set1[i];
    }

    int set2[10];
    for(int i = 0; i < 10; i++){
        cout << "Enter element " << (i + 1) << " as an integer for set2: ";
        cin >> set2[i];
    }

    int unique1 = 1, unique2 = 1; 
    for(int i = 0; i < 10; i++){
        unique1 = 1, unique2 = 1;
        for(int j = 0; j < 10; j++){
            if(set1[i] == set2[j]){
                unique1 = 0;
                break;
            }
            if(set2[i] == set1[j]){
                unique2 = 0;
                break;
            }
        }
        if(unique1){
            cout << set1[i] << " ";
        }
        if(unique2){
            cout << set2[i] << " ";
        }
    }
    return 0;
}