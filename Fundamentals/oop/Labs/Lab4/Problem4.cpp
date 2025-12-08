#include <iostream>

using namespace std;

/* Problem4:*/
int main(){
    char arr[100];
    cout << "Enter a string: ";
    cin.getline(arr, 100);
    int flag = 1;
    for(int i = 0; arr[i] != '\0'; i++){
        if(flag){
            cout << toupper(arr[i]);
            flag = 0;
        }
        else{
            cout << tolower(arr[i]);
            flag = 1;
        }
    }
    return 0;
}