#include <iostream>

using namespace std;

/* Abstract Class */
class Shape{
protected:
    int dim1, dim2;
public:
    /* Constructors */
    Shape(){dim1 = dim2 = 0;}
    Shape(int a){dim1 = dim2 = a;}
    Shape(int a, int b){dim1 = a; dim2 = b;}
    /* Setters */
    void SetDim1(int a){dim1 = a;}
    void SetDim2(int b){dim2 = b;}
    /* Getters */
    int GetDim1(){return dim1;}
    int GetDim2(){return dim2;}
    /* Methods */
    virtual float Area() = 0;     // Pure virtual function
};

class Circle : public Shape{
public:
    Circle(){}
    Circle(int r): Shape(r){}
    float Area() override {return 3.14 * dim1 * dim2;}
};

class Triangle : public Shape{
public:
    Triangle(){}
    Triangle(int b, int h): Shape(b, h){}
    float Area() override {return 0.5 * dim1 * dim2;}
};

class Rectangle : public Shape{
public:
    Rectangle(){}
    Rectangle(int w, int h): Shape(w, h){}
    float Area() override {return 1.0 * dim1 * dim2;}
};

class Square : public Rectangle{
public:
    Square(){}
    Square(int w): Rectangle(w, w){}
};

class GeoShape{
    int NumShapes;
public:
    /* Constructors */
    GeoShape(){NumShapes = 0;}
    GeoShape(int n){NumShapes = n;}
    /* Methods */
    float TotalArea(Shape* S[]){
        float total = 0.0;
        for(int i = 0; i < NumShapes; i++){
            total += S[i]->Area();
        }
        return total;
    }

};

int main(){
    Rectangle R(4, 5);
    Square S(4);
    Shape *p_shapes[2] = {&R, &S};
    GeoShape G(2);
    cout << "Total Area: " << G.TotalArea(p_shapes) << endl;
    return 0;
}