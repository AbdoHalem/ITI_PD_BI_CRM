#include <iostream>
#include <cstring>

using namespace std;

class Person{
protected:
    char Name[20];
    int ID;
public:
    Person(){Name[0] = '\0'; ID = 0;}
    Person(const char* name, int id){strcpy(Name, name); ID = id;}
    /* Setters */
    void SetName(const char* name){strcpy(Name, name);}
    void SetID(int id){ID = id;}
    /* Getters */
    char* GetName(){return Name;}
    int GetID(){return ID;}
    /* Methods */
    void Print(){
        cout << "Person Name: " << Name << endl;
        cout << "Person ID: " << ID << endl;
    }
};

class Customer: public Person{
    float Purchase;
public:
    Customer(){Purchase = 0;}
    Customer(const char* name, int id, float purchase):Person(name, id){
        Purchase = purchase;
    }
    /* Setters */
    void SetPurchase(float purchase){Purchase = purchase;}
    /* Getters */
    float GetPurchase(){return Purchase;}
    /* Methods */
    void Print(){
        cout << "Customer Name: " << GetName() << endl;
        cout << "Customer ID: " << GetID() << endl;
        cout << "Customer Purchase: " << GetPurchase() << endl;
    }
};

class Employee: public Person{
    float Salary;
public:
    Employee(){Salary = 0;}
    Employee(const char* name, int id, float purchase):Person(name, id){
        Salary = purchase;
    }
    /* Setters */
    void SetPurchase(float purchase){Salary = purchase;}
    /* Getters */
    float GetPurchase(){return Salary;}
    /* Methods */
    void Print(){
        cout << "Employee Name: " << GetName() << endl;
        cout << "Employee ID: " << GetID() << endl;
        cout << "Employee Purchase: " << GetPurchase() << endl;
    }
};

int main()
{
    Employee emp("Abdo", 123, 10000.0);
    emp.Print();
    Customer cust("Ahmed", 456, 500.0);
    cust.Print();
    return 0;
}