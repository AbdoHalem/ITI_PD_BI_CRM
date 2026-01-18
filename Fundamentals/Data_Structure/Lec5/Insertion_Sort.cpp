#include <iostream>

using namespace std;

void InsertionSort(int arr[], int n){
    for(int i = 1; i < n; i++){
        int key = arr[i];
        int j = i - 1;
        while(arr[j] > key && j >= 0){
            arr[j+1] = arr[j];
            j--;
        }
        arr[j+1] = key;
    }
}

int main(){
    int arr[] = {4, 3, 7, 1, 6, 2};
    InsertionSort(arr, sizeof(arr) / sizeof(arr[0]));
    for(int i: arr){
        cout << i << "  ";
    } 
    return 0;
}