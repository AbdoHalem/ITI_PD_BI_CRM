#include <iostream>

using namespace std;

int BinarySearch(int arr[], int n, int key){
    int start = 0;
    int end = n-1;
    while(start <= end){
        int mid = (start + end) / 2;
        if(arr[mid] == key){
            return mid;
        }
        else if(arr[mid] > key){
            end = mid - 1;
        }
        else{
            start = mid + 1;
        }
    }
    return -1;
}

int main(){
    int arr[] = { 2, 3, 4, 10, 40 };
    int x = 10;
    int result = BinarySearch(arr, 5, x);
    if(result == -1) cout << "Element is not present in array";
    else cout << "Element is present at index " << result;
    return 0;
}