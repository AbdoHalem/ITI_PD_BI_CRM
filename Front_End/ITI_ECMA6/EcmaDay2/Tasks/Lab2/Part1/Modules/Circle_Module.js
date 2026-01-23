//& 4-create Circle Class with private fields (radius and x,y ) with set and get properies  
//& -Circle class inherit from Shape class with override toString
import {Shape} from "./Shape_Base_Module.js"

class Circle extends Shape{
    #radius = 0;
    #x = 0;
    #y = 0;
    constructor(_radius, _x, _y, _color){
        super(_color);
        this.Radius = _radius;
        this.X = _x;
        this.Y = _y;
    }
    //^ Set & Get Accessories
    set Radius(_value){
        if(_value <= 0){
            throw Error("Radius must be > 0");
        }
        else{
            this.#radius = _value;
        }
    }
    get Radius(){
        return this.#radius;
    }
    set X(_value){
        this.#x = _value;
    }
    get X(){
        return this.#x;
    }
    set Y(_value){
        this.#y = _value;
    }
    get Y(){
        return this.#y;
    }
    //^ Override methods
    CalcArea(){
        return Math.PI * this.#radius * this.#radius;
    }
    CalcPerimeter(){
        return 2* Math.PI * this.#radius; 
    }
    toString(){
        console.log(`Circle Data => Color: ${this.PrintColor()} Area: ${this.CalcArea()} Perimeter: ${this.CalcPerimeter()}`);
    }
}