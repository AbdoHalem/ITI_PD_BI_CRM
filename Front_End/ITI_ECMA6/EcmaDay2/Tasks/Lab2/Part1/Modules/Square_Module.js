//& 3- Creat Square Class Which inherits from Rect Class - override CalcArea , calcperimeter , 
//& printColor , toString which will display color , area and perimeter in rect and square classes
import {Rectangle} from "./Rectangle_Module.js";

class Square extends Rectangle{
    static numSquares = 0;
    constructor(_side, _color){
        super(_side, _side, _color);
        //* Isolate num of rectangles from num of squares
        Rectangle.numShapes--;  
        Square.numSquares++;
    }
    toString(){
        console.log(`Square Data => Color: ${this.PrintColor()} Area: ${this.CalcArea()} Perimeter: ${this.CalcPerimeter()}`);
    }
    //^ Static methods
    static CountSquare(){
        return this.numSquares;
    }
}
export {Square};