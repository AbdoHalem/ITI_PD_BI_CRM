#include <iostream>

using namespace std;

class Queue{
    int arr[5] = {0};
    int Tail;
public:
    Queue(){Tail = -1;}
    int Enqueue(int d);
    int Dequeue();
};

int Queue::Enqueue(int d){
    int added = 0;
    if(Tail > 4){   // Full
        cout << "Queue is full" << endl;
    }
    else{
        if(Tail == -1){     // Empty
            Tail = 0;
        }
        arr[Tail++] = d;
        added = 1;
    }
    return added;
}

int Queue::Dequeue(){
    int deleted = 0;
    if(Tail != 0){
        // Shift the elements
        for(int i = 0; i < Tail; i++){
            arr[i] = arr[i+1];
        }
        deleted = 1;
        Tail--;
    }
    else{
        cout << "Queue is empty" << endl;
    }
    return deleted;
}

int main(){
    Queue q1;
    cout << q1.Enqueue(1) << endl;
    cout << q1.Enqueue(2) << endl;
    cout << q1.Dequeue() << endl;
    cout << q1.Dequeue() << endl;
    cout << q1.Dequeue() << endl;
    return 0;
}