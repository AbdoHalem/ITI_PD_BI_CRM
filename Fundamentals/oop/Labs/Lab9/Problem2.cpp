#include <iostream>
#include <cmath>

using namespace std;

/* Point Class */
class Point{
    int X, Y;
public:
    /* Default Constructor */
    Point(){X = 0; Y = 0;}
    /* Parameterized Constructor */
    Point(int m){X = Y = m;}
    Point(int x, int y){X = x; Y = y;}
    /* Destructor */
    ~Point(){cout << "Point Destructor called" << endl;}

    /* Setters */
    void SetX(int x){X = x;}
    void SetY(int y){Y = y;}
    /* Getters */
    int GetX(){return X;}
    int GetY(){return Y;}
};

/* Rectangle Class: Composition */
class Rectangle_c{
    Point P1, P2;
    int Length, Width;
public:
    /* Default Constructor */
    Rectangle_c(){P1 = Point(); P2 = Point();}
    /* Parameterized Constructor */
    Rectangle_c(int x1, int y1, int x2, int y2): P1(x1, y1), P2(x2, y2)
    {
        Length = abs(x2 - x1);
        Width = abs(y2 - y1);
    }
    /* Destructor */
    ~Rectangle_c(){cout << "Rectangle Destructor called" << endl;}

    /* Setters */
    void SetP1(int x1, int y1){
        P1.SetX(x1); P1.SetY(y1);
        Length = abs(P2.GetX() - x1);
        Width = abs(P2.GetY() - y1);
    }
    void SetP2(int x2, int y2){
        P2.SetX(x2); P2.SetY(y2);
        Length = abs(x2 - P1.GetX());
        Width = abs(y2 - P1.GetY());
    }
    /* Getters */
    int GetLength(){return Length;}
    int GetWidth(){return Width;}
    int GetArea(){return Length * Width;}
};

/* Circle Class: Association */
class Circle_a{
    Point *Center, *P2;
    float Radius;
public:
    /* Default Constructor */
    Circle_a(){Center = P2 = NULL; Radius = 0;}
    /* Parameterized Constructor */
    Circle_a(Point *center, Point *p2){
        this->Center = center;
        this->P2 = p2;
        if(center != NULL && p2 != NULL){
            Radius = sqrt(pow(p2->GetX() - center->GetX(), 2) + pow(p2->GetY() - center->GetY(), 2));
        }
        else{
            Radius = 0;
        }
        
    }
    /* Destructor */
    ~Circle_a(){cout << "Circle Destructor called" << endl;}

    /* Setters */
    void SetCenter(Point *center){
        this->Center = center;
        if(center != NULL && P2 != NULL){
            Radius = sqrt(pow(P2->GetX() - center->GetX(), 2) + pow(P2->GetY() - center->GetY(), 2));
        }
        else{
            Radius = 0;
        }
    }
    void SetP2(Point *p2){
        this->P2 = p2;
        if(Center != NULL && p2 != NULL){
            Radius = sqrt(pow(p2->GetX() - Center->GetX(), 2) + pow(p2->GetY() - Center->GetY(), 2));
        }
        else{
            Radius = 0;
        }
    }

    /* Getters */
    Point* GetCenter(){return Center;}
    Point* GetP2(){return P2;}
    float GetRadius(){return Radius;}

    /* Methods */
    double GetArea(){return 3.14 * Radius * Radius;}
};

int main(){
    Rectangle_c rect(0, 0, 10, 10);
    cout << "Length: " << rect.GetLength() << endl;
    cout << "Width: " << rect.GetWidth() << endl;
    cout << "Area: " << rect.GetArea() << endl;
    rect.SetP1(5, 5);
    cout << "Length: " << rect.GetLength() << endl;
    cout << "Width: " << rect.GetWidth() << endl;
    cout << "Area: " << rect.GetArea() << endl;
    cout << "===============================================" << endl;
    // ================================================
    // Point p1(0, 0), p2(10, 10);
    Point* p1 = new Point(0, 0), *p2 = new Point(10, 10);
    // Circle_a circle(&p1, &p2);
    Circle_a circle(p1, p2);
    cout << "Radius: " << circle.GetRadius() << endl;
    cout << "Area: " << circle.GetArea() << endl;
    // p2.SetX(5);
    p2->SetX(5);
    // p2.SetY(5);
    p2->SetX(5);
    // circle.SetP2(&p2);
    circle.SetP2(p2);
    cout << "Radius: " << circle.GetRadius() << endl;
    cout << "Area: " << circle.GetArea() << endl;
    delete p1;
    delete p2;
    cout << "End of program" << endl << endl;
    return 0;
}