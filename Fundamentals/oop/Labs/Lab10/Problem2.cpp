#include <iostream>
using namespace std;

class Base {
protected:
    int z;
public:
    Base(){z = 0;}
    Base(int m){z = m;}
    void SetZ(int m){z = m;}
    int GetZ(){return z;}
};

class Base1: public Base {
protected:
    int x;
public:
    Base1(){x = 0;}
    Base1(int m): Base(m){x = m;}
    void SetX(int m){x = m;}
    int GetX(){return x;}
};

class Base2: public Base {
protected:
    int y;
public:
    Base2(){y = 0;}
    Base2(int m): Base(m){y = m;}
    void SetY(int m){y = m;}
    int GetY(){return y;}
};

class Derived: public Base1, public Base2{
public:
    Derived(int m, int n): Base1(m), Base2(n){}
    // int Product(){return x * y * Base1::z;}
    int Product(){return x * y * z;}
    // int Sum(){return x + y + Base2::z;}
    int Sum(){return x + y + z;}

};

int main() {
    Derived d(3, 4);
    cout << d.Product() << endl;
    cout << d.Sum() << endl;
    return 0;
}