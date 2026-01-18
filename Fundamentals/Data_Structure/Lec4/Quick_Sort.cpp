#include <iostream>

using namespace std;

int Partition(int arr[], int start, int end){
    int pivot = arr[end];
    int i = start - 1;
    for(int j = start; j < end; j++){
        if(arr[j] < pivot){     //* put smaller elements at left of pivot
            i++;
            swap(arr[i], arr[j]);
        }
    }
    //* put the pivot element at index i + 1
    i++;
    swap(arr[i], arr[end]);
    //* Return the index of pivot element
    return i;
}

void QuickSort(int arr[], int start, int end){
    if(end <= start){return;}   //? Base Case
    //* Get index of the pivot
    int pivot = Partition(arr, start, end);
    //* Recursion calls for smaller elements
    QuickSort(arr, start, pivot-1);
    //* Recursion calls for equal or greater elements
    QuickSort(arr, pivot + 1, end);
}


int main(){
    int arr[6] = {10, 7, 8, 9, 1, 5};
    QuickSort(arr, 0, 6);
    for(int i: arr){
        cout << i << "  ";
    }
    return 0;
}