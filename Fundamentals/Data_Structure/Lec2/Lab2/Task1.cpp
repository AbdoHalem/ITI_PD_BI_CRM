#include <iostream>

using namespace std;

/* Stcack LinkedList */
struct Node{
    int data;
    Node *pPrev;
};

class Stack{
    Node *Top;
    Node* CreateNode(int d);
    int Length;
public:
    Stack(){Top = NULL; Length = 0;}
    int Push(int d);
    Node* Pop();
};

Node* Stack::CreateNode(int d){
    Node *ptr = new(Node);
    if(ptr){
        ptr->data = d;
        ptr->pPrev = Top;
        Top = ptr;
    }
    return ptr;
}

int Stack::Push(int d){
    int added = 0;
    Node *ptr = CreateNode(d);
    if(ptr != NULL){
        added = 1;
        ptr->pPrev = Top;
        Top = ptr;
    }
    return added;
}

Node* Stack::Pop(){
    Node *node = NULL; 
    if(Top != NULL){
        node = Top;
        // Node* temp = Top;
        Top = Top->pPrev; 
    }
    else{
        cout << "Stack is empty!" << endl;
    }
    return node;
}

int main(){
    Stack st1;
    st1.Push(1);
    st1.Push(2);
    Node* node = st1.Pop();
    cout << node->data;
    return 0;
}