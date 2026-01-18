#include <iostream>

using namespace std;

struct Node{
    int Data;
    Node* pNext;
    Node* pPrev;
};

class Doubly_LinkedList{
    Node* pHead;
    Node* pTail;
    Node* CreateNode(int data);
    Node* Split(Node* head);
    Node* Merge(Node* head1, Node* head2);
    Node* Merge_Sort(Node* head);
public:
    Doubly_LinkedList(){pHead = pTail = NULL;}
    ~Doubly_LinkedList();
    Node* getHead(){return pHead;}
    int AddNode(int data);
    int InsertNode(int data, int loc);
    void PrintList(Node* head = NULL);
    Node* SearchNode(int data);
    void Sort();
};

/**
 * @brief Destructor for Doubly_LinkedList class
 * 
 * Destructor for Doubly_LinkedList class. It deletes all the nodes in the doubly linked list.
 * 
 * @note This function is automatically called when an object of Doubly_LinkedList class is destroyed.
 */
Doubly_LinkedList::~Doubly_LinkedList(){
    Node* Next = pHead;
    while(Next != NULL){
        Node* temp = Next;
        Next = Next->pNext;
        delete temp;
    }
}

/**
 * @brief Creates a new node in the doubly linked list with the given data
 * 
 * Creates a new node in the doubly linked list with the given data. If the node is successfully created, it returns a pointer to the new node. Otherwise, it returns NULL.
 * 
 * @param data The data to add to the new node
 * @return Node* Pointer to the new node if created successfully, NULL otherwise
 */
Node* Doubly_LinkedList::CreateNode(int data){
    Node *node = new(Node);
    if(node != NULL){
        // length += 1;
        node->Data = data;
        node->pNext = NULL;
        node->pPrev = NULL;
    }
    return node;
}

/**
 * @brief Adds a new node to the doubly linked list with the given data
 * 
 * @param data The data to add to the new node
 * @return int 1 if added successfully, 0 otherwise
 * 
 * This function adds a new node to the doubly linked list with the given data.
 * If the list is empty, the new node becomes the head and tail of the list.
 * If the list is not empty, the new node is inserted at the tail of the list.
 */
int Doubly_LinkedList::AddNode(int data){
    int added = 0;
    Node* ptr = CreateNode(data);
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

/**
 * @brief Inserts a new node with the given data at the specified location in the doubly linked list
 * 
 * @param data The data to insert into the new node
 * @param loc The location to insert the new node (0 for first node, length for last node)
 * @return int 1 if inserted successfully, 0 otherwise
 * 
 * This function inserts a new node with the given data at the specified location in the doubly linked list.
 * If the list is empty, the new node becomes the head and tail of the list.
 * If the location is 0, the new node is inserted at the first node.
 * If the location is equal to the length of the list, the new node is inserted at the last node.
 * If the location is between 0 and the length of the list, the new node is inserted at the specified location.
 */
int Doubly_LinkedList::InsertNode(int data, int loc){
    int inserted = 0;
    Node *ptr = CreateNode(data);
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

/**
 * @brief Prints the doubly linked list
 * 
 * Prints the doubly linked list starting from the given head (or the head of the list if head is NULL)
 * 
 * @param head Pointer to the head of the doubly linked list (optional)
 */
void Doubly_LinkedList::PrintList(Node* head){
    Node *pTemp = (head == NULL) ? pHead : head;
    while(pTemp != NULL){
        cout << pTemp->Data << " -> ";
        pTemp = pTemp->pNext;
    }
    cout << endl;
}

/**
 * @brief Searches for a node in the doubly linked list with the given data
 * 
 * @param data The data to search for
 * @return Node* Pointer to the node with the given data if found, NULL otherwise
 */
Node* Doubly_LinkedList::SearchNode(int data){
    Node *temp = pHead;
    for(int i = 0; temp->Data != data && temp->pNext != NULL; i++){
        temp = temp->pNext;
    }
    if(temp->Data == data){
        return temp;
    }
    else{
        return NULL;
    }
}
/**
 * @brief Split the Linkedlist into two halves and return the head of the second half 
 * 
 * @param head Pointer to the head of the Linkedlist
 * @return Node* Head pointer of the second half
 */
Node* Doubly_LinkedList::Split(Node* head){
    //* Check if the Linkedlist is empty or has only one node
    if (head == nullptr || head->pNext == nullptr) {
        return nullptr; 
    }
    Node *pSlow = head;
    Node *pFast = head;
    while(pFast !=nullptr && pFast->pNext != nullptr){
        pSlow = pSlow->pNext;
        pFast = pFast->pNext->pNext;
    }
    //* Split the linked list in two halves
    pSlow->pPrev->pNext = nullptr;
    pSlow->pPrev = nullptr;
    //* Return the head of the second half
    return pSlow;
}

/**
 * @brief Merge two sorted doubly linked lists into a single sorted doubly linked list
 * 
 * This function takes two sorted doubly linked lists, and merges them into a single sorted doubly linked list.
 * The function works by comparing the data of the two lists, and connecting the nodes in the correct order.
 * The function also handles the backward links (Prev) for the doubly linked list.
 * 
 * @param first Pointer to the head of the first doubly linked list
 * @param second Pointer to the head of the second doubly linked list
 * @return Node* Pointer to the head of the merged doubly linked list
 */
Node* Doubly_LinkedList::Merge(Node* first, Node* second) {
    //? 1. If first is empty, return second
    if (!first) return second;
    //? 2. If second is empty, return first
    if (!second) return first;
    //? 3. Compare data
    if (first->Data <= second->Data) {
        //* First is smaller, so it comes first.
        //* Recursively merge the rest of the list starting from first->next
        first->pNext = Merge(first->pNext, second);
        //* Connect the backward link (Prev) for Doubly Linked List
        if (first->pNext != nullptr) {
            first->pNext->pPrev = first; 
        }
        first->pPrev = nullptr; //* Ensure head prev is null
        return first;
    } else {
        //* Second is smaller
        second->pNext = Merge(first, second->pNext);
        //* Connect the backward link (Prev) for Doubly Linked List
        if (second->pNext != nullptr) {
            second->pNext->pPrev = second;
        }
        second->pPrev = nullptr;
        return second;
    }
}

/**
 * @brief Sorts the doubly linked list using Merge Sort algorithm
 * 
 * @param head1 Pointer to the head of the doubly linked list
 * @return Node* Pointer to the head of the sorted doubly linked list
 * 
 * This function takes a pointer to the head of the doubly linked list as input and returns a pointer to the head of the sorted doubly linked list. It uses the Merge Sort algorithm to sort the list. The algorithm recursively splits the list into two halves, sorts each half, and then merges the sorted halves into a single sorted list.
 */
Node* Doubly_LinkedList::Merge_Sort(Node* head1){
    //? Base Case: If head is null or there is only one element in the list
    if (head1 == nullptr|| head1->pNext == nullptr) {
        return head1;
    }
    //* Split the list into two halves
    Node* head2 = Split(head1);
    //* Recursion for left and right halves
    head1 = Merge_Sort(head1);
    head2 = Merge_Sort(head2);
    //* Merge the two sorted halves
    return Merge(head1, head2);
}


/**
 * @brief Sorts the doubly linked list using Merge Sort algorithm
 * 
 * This function sorts the doubly linked list using the Merge Sort algorithm. It first calls the Merge_Sort function to sort the list, and then resets the pTail pointer to the end of the new sorted list.
 * 
 * @note The Merge Sort algorithm is a divide-and-conquer algorithm that splits the list into two halves, sorts each half, and then merges the sorted halves into a single sorted list.
 */
void Doubly_LinkedList::Sort() {
    pHead = Merge_Sort(pHead);
    // Reset pTail to the end of the new sorted list
    if(pHead != NULL){
        Node* temp = pHead;
        while(temp->pNext != NULL) temp = temp->pNext;
        pTail = temp;
    }
}

int	main(){
    Doubly_LinkedList list;
    list.AddNode(4);
    list.AddNode(1);
    list.AddNode(3);
    list.AddNode(7);
    list.AddNode(2);
    list.AddNode(6);
    list.AddNode(5);
    list.PrintList();
    list.Sort();      // Call the public wrapper
    list.PrintList();
    return 0;
}
