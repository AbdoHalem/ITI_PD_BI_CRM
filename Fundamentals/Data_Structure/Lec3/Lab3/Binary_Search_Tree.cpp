#include <iostream>
using namespace std;

struct Node{
    int Data;
    Node *pLeft;
    Node *pRight;
};

class BS_Tree{
    Node *Root;             //* Pointer to the root node of the tree
    Node* createNode(int data);     //* Method to create new node
    void deleteTree(Node *root);
public:
    BS_Tree(int data): Root(createNode(data)){}    //* Constructor
    ~BS_Tree();                        //* Destructor
    Node *getRoot(){return Root;}
    void addNode(int data);            //* Method to add new node
    void traversInOrder(Node* root);
    void traversPreOrder(Node* root);
    void traversPostOrder(Node* root);
};

BS_Tree::~BS_Tree(){
    //? Delete delete the tree nodes from the memory
    deleteTree(Root);
}

/**
 * @brief Delete using PostOrder Traverse algorithm to delete children first, then parent
 * 
 * @param root 
 */
void BS_Tree::deleteTree(Node* root){
    //? Base case of the recursion
    if(root == nullptr){
        return;
    }
    //* 1. Traverse left child
    deleteTree(root->pLeft);
    //* 2. Traverse right child
    deleteTree(root->pRight);
    //* 3. Process the root
    delete root;
}

Node* BS_Tree::createNode(int data){
    Node *ptr = new(Node);
    if(ptr){
        ptr->Data = data;
        ptr->pLeft = ptr->pRight = nullptr;
    }
    return ptr;
}

void BS_Tree::addNode(int data){
    Node *ptr = createNode(data);
    if(ptr){
        Node *pTemp = Root;
        while(pTemp != nullptr){
            if(data <= pTemp->Data){     //* Go to the left child
                if(pTemp->pLeft == nullptr){
                    pTemp->pLeft = ptr;
                    break;
                }
                else{
                    pTemp = pTemp->pLeft;
                }
            }
            else{
                if(pTemp->pRight == nullptr){
                    pTemp->pRight = ptr;
                    break;
                }
                else{
                    pTemp = pTemp->pRight;
                }
            }
        }
    }
}

void BS_Tree::traversInOrder(Node* root){
    //? Base case of the recursion
    if(root == nullptr){
        return;
    }
    //* 1. Traverse left child
    traversInOrder(root->pLeft);
    //* 2. Process the root
    cout << root->Data << ", ";
    //* 3. Traverse right child
    traversInOrder(root->pRight);
}

void BS_Tree::traversPreOrder(Node* root){
    //? Base case of the recursion
    if(root == nullptr){
        return;
    }
    //* 1. Process the root
    cout << root->Data << ", ";
    //* 2. Traverse left child
    traversPreOrder(root->pLeft);
    //* 3. Traverse right child
    traversPreOrder(root->pRight);
}

void BS_Tree::traversPostOrder(Node* root){
    //? Base case of the recursion
    if(root == nullptr){
        return;
    }
    //* 1. Traverse left child
    traversPostOrder(root->pLeft);
    //* 2. Traverse right child
    traversPostOrder(root->pRight);
    //* 3. Process the root
    cout << root->Data << ", ";
}


int main(){
    BS_Tree tree(5);    //* Root Node data is 5
    tree.addNode(2);
    tree.addNode(3);
    tree.addNode(1);
    tree.addNode(7);
    tree.addNode(6);
    // tree.addNode(8);
    cout << "InOrder traversing: " << endl;
    tree.traversInOrder(tree.getRoot());
    cout << endl << "PreOrder traversing: " << endl;
    tree.traversPreOrder(tree.getRoot());
    cout << endl << "PostOrder traversing: " << endl;
    tree.traversPostOrder(tree.getRoot());
    return 0;
}