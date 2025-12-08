#include <iostream>
#include <cmath>
#include <windows.h>

using namespace std;



/* Problem1 */
// int main(){ 
//     int speed = 0;
//     cout << "Enter the automobile speed in mph: ";
//     cin >> speed;
//     if(speed > 65){
//         cout << "SPEEDING" << endl;
//     }
//     return 0;
// }
/*=================================================*/

/* Problem2 */
// int main() {   
//     int Richter = 0;
//     cout << "Enter the Richter scale number of the earthquake: ";
//     cin >> Richter;
//     if(Richter < 5 && Richter >= 0){
//         cout << "Little or no damage" << endl;
//     }
//     else if(Richter >= 5 && Richter < 5.5){
//         cout << "Some damage" << endl;
//     }
//     else if(Richter >= 5.5 && Richter < 6.5){
//         cout << "Serious damage: walls may crack or fall" << endl;
//     }
//     else if(Richter >= 6.5 && Richter < 7.5){
//         cout << "Disaster: most buildings destroyed" << endl;
//     }
//     else{
//         cout << "Catastrophe: most buildings destroyed" << endl;
//     }
//     return 0;
// }
/*=================================================*/

/* Problem3 */
// int main(){
//     float x = 0;
//     float y = 0;
//     cout << "Enter the x value: ";
//     cin >> x;
//     cout << "Enter the y value: ";
//     cin >> y;

//     if(x == 0){
//         cout << "The point (" << x << "," << y << ") is on the y-axis" << endl;
//     }
//     else if (y == 0)
//     {
//         cout << "The point (" << x << "," << y << ") is on the x-axis" << endl;
//     }
//     else if(x > 0){
//         if(y > 0){
//             cout << "The point (" << x << "," << y << ") is in Quadrant 1" << endl;
//         }
//         else{
//             cout << "The point (" << x << "," << y << ") is in Quadrant 4" << endl;
//         }
//     }
//     else{
//         if(y > 0){
//             cout << "The point (" << x << "," << y << ") is in Quadrant 2" << endl;
//         }
//         else{
//             cout << "The point (" << x << "," << y << ") is in Quadrant 3" << endl;
//         }
//     }
//     return 0;
// }
/*=================================================*/

/* Problem4 */
// int main(){
//     char color;
//     cout << "Enter a letter of the cylinder color (Y/y, O,o, B,b, G,g): ";
//     cin >> color;
//     color = tolower(color);
//     switch(color){
//         case 'y':
//             cout << "The cylinder contains hydrogen" << endl;
//             break;
//         case 'o':
//             cout << "The cylinder contains ammonia" << endl;
//             break;
//         case 'b':
//             cout << "The cylinder contains carbon monoxide" << endl;
//             break;
//         case 'g':
//             cout << "The cylinder contains oxygen" << endl;
//             break;
//         default:
//             cout << "Invalid color" << endl;
//     }
//     return 0;
// }
/*=================================================*/

/* Problem5 */
// int main(){
//     float x1 = 0, x2 = 0;
//     float a, b , c;
//     cout << "Enter coefficient a: ";    
//     cin >> a;    
//     cout << "Enter coefficient b: ";    
//     cin >> b;    
//     cout << "Enter coefficient c: ";    
//     cin >> c;
//     float discriminant = b*b - 4*a*c;
//     if(discriminant < 0){
//         cout << "The equation has no real roots." << endl;
//     }
//     else if(discriminant == 0){
//         x1 = -b / (2*a); x2 = x1;
//         cout << "This equation has one possible solution x = " << x1 << endl;
//     }
//     else{
//         x1 = (-b + sqrt(discriminant)) / (2*a);
//         x2 = (-b - sqrt(discriminant)) / (2*a);
//         cout << "The roots of the quadratic equation are: " << x1 << " and " << x2 << endl;
//     }
//     return 0;
// }
/*=================================================*/

/* Problem6: Magic Box */
// void gotoxy(int x, int y) {
//     COORD coord;
//     coord.X = x * 4 - 1;  // Multiply by 4 to space numbers
//     coord.Y = y - 1;
//     SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
// }

// int main(){
//     int size = 0, row = 0, col = 0;

//     while(size%2 == 0 || size <= 0){
//         cout << "Enter the size of the magic box (odd number): ";
//         cin >> size;
//     }
    
//     for(int i = 1; i <= size*size; i++){
//         if(i == 1){
//             row = 1;
//             col = (size+1)/2;
//             // gotoxy(col, row);
//             cout << i << "==> (" << row << "," << col << ")" << endl;
//         }
//         else{
//             if((i-1)%size == 0){
//                 row++;
//                 if(row > size){row = 1;}
//                 // gotoxy(col, row);
//                 cout << i << "==> (" << row << "," << col << ")" << endl;
//             }
//             else{
//                 row--;
//                 col--;
//                 if(row < 1){row = 1;}
//                 if(col < 1){col = 1;}
//                 // gotoxy(col, row);
//                 cout << i << "==> (" << row << "," << col << ")" << endl;
//             }
//         }
//     }
//     cin >> row;// To keep the console window open
//     return 0;
// }
/*=================================================*/

/* Problem7: approximation Approximation
 * The value for π can be determined by the series equation:
 * π = 4(1 - 1/3 + 1/5 - 1/7 + 1/9 - ...)
 */
// int main(){
//     int terms = 0;
//     cout << "Enter how many terms of the series equation to use in approximation: ";
//     cin >> terms;
    
//     double approximation = 0.0;
//     int denominator = 1;
//     int sign = 1;
    
//     for(int i = 0; i < terms; i++) {
//         approximation += sign * (4.0 / denominator);
//         denominator += 2;  
//         sign = -sign;
//     }
    
//     cout << fixed;  // Use fixed-point notation
//     cout.precision(10);  // Show 10 decimal places
//     cout << "The approximation of pi using " << terms << " terms is: " << approximation << endl;
//     cout << "The actual value of pi is:                    3.1415926536" << endl;
//     return 0;
// }
/*=================================================*/

/* Problem8: Take five numbers and find the min and max numbers */

int main(){
    int number = 0;
    int min = 0, max = 0;
    cout << "Enter number1: ";
    cin >> number;
    min = number;
    max = number;

    for(int i = 2; i <= 5; i++){
        cout << "Enter number" << i << ": ";
        cin >> number;
        if(number <= min){
            min = number;
        }
        else if(number >= max){
            max = number;
        }
    }
    
    cout << "The minimum number is: " << min << endl;
    cout << "The maximum number is: " << max << endl;
    return 0;
}