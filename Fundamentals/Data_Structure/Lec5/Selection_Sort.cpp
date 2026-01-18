#include <iostream>

using namespace std;

void SelectionSort(int arr[], int n){
    for(int i = 0; i < n; i++){
        int min_index = i;
        for(int j = i+1; j < n; j++){
            if(arr[j] <= arr[min_index]){
                min_index = j;
            }
        }
        swap(arr[i], arr[min_index]);
    }
}

int main(){
    int arr[] = {4, 3, 7, 1, 6, 2};
    SelectionSort(arr, sizeof(arr) / sizeof(arr[0]));
    for(int i: arr){
        cout << i << "  ";
    }
    return 0;
}