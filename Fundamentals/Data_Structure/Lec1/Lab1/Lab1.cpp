#include <iostream>
#include <string.h>
using namespace std;

struct Node{
    char Name[20];
    int ID;
    Node* pNext;
    Node* pPrev;
};

class StudentList{
    Node* pHead;
    Node* pTail;
    Node* CreateNode(const char *name, int id);
    // int length;
public:
    StudentList(){pHead = pTail = NULL; /*length = 0;*/}
    ~StudentList(){
        Node* Next = pHead;
        while(Next != NULL){
            Node* temp = Next;
            Next = Next->pNext;
            delete temp;
        }
    }
    int AddStudent(const char *name, int id);
    int InsertStudent(const char *name, int id, int loc);
    Node* SearchStudent(int id);
};

Node* StudentList::CreateNode(const char *name, int id){
    Node *student = new(Node);
    if(student != NULL){
        // length += 1;
        strcpy(student->Name, name);
        student->ID = id;
        student->pNext = NULL;
        student->pPrev = NULL;
    }
    return student;
}

int StudentList::AddStudent(const char *name, int id){
    int added = 0;
    Node* ptr = CreateNode(name, id);
    if(ptr != NULL){
        added = 1;
        if(pHead == NULL){
            pHead = pTail = ptr;
        }
        else{   // Insert at tail
            pTail->pNext = ptr;
            ptr->pPrev = pTail;
            pTail = ptr;
        }
    }
    return added;
}

int StudentList::InsertStudent(const char *name, int id, int loc){
    int inserted = 0;
    Node *ptr = CreateNode(name, id);
    if(ptr != NULL){
        inserted = 1;
        if(pHead == NULL){  // List is empty
            pHead = pTail = ptr;
        }
        else{   // List is not empty
            if(loc == 0){   // Insert at first node
                ptr->pNext = pHead;
                pHead->pPrev = ptr;
                pHead = ptr;
            }
            else {
                Node *temp = pHead;
                for(int i = 0; i < loc-1 && temp->pNext != NULL; i++){// Stop at tail
                    temp = temp->pNext;
                }
                if(temp == pTail){  // Insert at last node
                    pTail->pNext = ptr;
                    ptr->pPrev = pTail;
                    pTail = ptr;
                }
                else{
                    ptr->pNext = temp->pNext;
                    ptr->pPrev = temp;
                    temp->pNext->pPrev = ptr;
                    temp->pNext = ptr;
                }

            }
        }
    }
    return inserted;
}

Node* StudentList::SearchStudent(int id){
    Node *temp = pHead;
    for(int i = 0; temp->ID != id && temp->pNext != NULL; i++){
        temp = temp->pNext;
    }
    if(temp->ID == id){
        return temp;
    }
    else{
        return NULL;
    }
}

int main(){
    StudentList stud;
    stud.AddStudent("Halem", 1);
    stud.AddStudent("Ahmed", 2);
    stud.InsertStudent("Mohamed", 3, 1);
    stud.InsertStudent("Ali", 4, 4);
    Node* student = stud.SearchStudent(4);
    if(student == NULL){
        cout << "Not found";
        return 0;
    }
    else{
        cout << student->Name;
    }
    return 0;
}