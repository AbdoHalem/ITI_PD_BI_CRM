#include <iostream>
using namespace std;
/*
C/C++ Day 1:
Lecture 1:
•	Introduction to Programming
•	C Programming Language
•	Pre-Processor
•	Variable & Constant (Data Types)
•	I/P statement (cin)
•	O/P statement (cout)
•	Operators
Lab 1:
1.	Setup the environment (Visual studio code or code blocks)
2.	Write a program to take a depth in (kilometers) inside the earth as input, then compute and print the temperature at this depth in Celsius and Fahrenheit 
•	Celsius = 10 * depth + 20
•	Fahrenheit = 1.8 * Celsius + 32
3.	Write a program that takes the length and width of a rectangular yard and the length and width of rectangular house situated in the yard. It is required to calculate and display the time required to cut the grass at the rate of two square feet a second
*/
int main(){
    /* Program 1 */
    float depth = 0;
    cout << "Enter the depth in kilometers: ";
    cin >> depth;
    float Celsius = 10 * depth + 20;
    float Fehrenheit = 1.8 * Celsius + 32;
    cout << "The temperature at " << depth << " kilometers in Celsius is " << Celsius << endl;
    cout << "The temperature at " << depth << " kilometers in Fahrenheit is " << Fehrenheit << endl;

    /* Program 2 */
    float length_yard = 0;
    float width_yard = 0;
    cout << "Enter the length of the yard: ";
    cin >> length_yard;
    cout << "Enter the width of the yard: ";
    cin >> width_yard;
    float area_yard = length_yard * width_yard;
    float length_house = 0;
    float width_house = 0;
    cout << "Enter the length of the house: ";
    cin >> length_house;
    cout << "Enter the width of the house: ";
    cin >> width_house;
    float area_house = length_house * width_house;
    float area_grass = area_yard - area_house;
    float time_grass = area_grass / 2;
    cout << "The time required to cut the grass is " << time_grass << " seconds" << endl;
    return 0;
}