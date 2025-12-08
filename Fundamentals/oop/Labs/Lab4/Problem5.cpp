#include <iostream>
#include <cstring>
#include <iomanip>

using namespace std;

int main(){
    char number[10];
    cout << "Enter a number: ";
    cin.getline(number, 10);
    int sum = 0;
    for(int i = 0; number[i] != '\0'; i++){
        if(number[i] >= '0' && number[i] <= '9'){
            sum += toascii(number[i]) - 48;
        }
    }
    cout << "Sum of digits in your number is: " << sum << "\n";
    cout << "Average of digits in your number is: " << fixed << setprecision(2) << sum /(float)strlen(number) << "\n";
    return 0;
}