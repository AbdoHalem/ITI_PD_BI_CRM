//& 2- Create Rectangle Class Which inherits from Shape Abstract Class  
//& define Width and Height Properties for Rect Class  as private with set and get  
//& Not with zero or minus value print validation message to user
import {Shape} from "./Shape_Base_Module.js";
class Rectangle extends Shape{
    #width = 0;
    #height = 0;
    static numShapes = 0;
    constructor(_width, _height, _color){
        super(_color)
        this.Width = _width;
        this.Height = _height;
        Rectangle.numShapes++;
    }
    //^ Set & Get Accessories
    set Width(_value){
        if(_value <= 0){
            throw Error("Width must be > 0");
        }
        else{
            this.#width = _value;
        }
    }
    get Width(){
        return this.#width;
    }
    set Height(_value){
        if(_value <= 0){
            throw Error("Height must be > 0");
        }
        else{
            this.#height = _value;
        }
    }
    get Height(){
        return this.#height;
    }
    //^ Override shape methods
    CalcArea(){
        return this.#width * this.#height;
    }
    CalcPerimeter(){
        return (this.#width + this.#height) * 2;
    }
    toString(){
        console.log(`Rectangle Data => Color: ${this.PrintColor()} Area: ${this.CalcArea()} Perimeter: ${this.CalcPerimeter()}`);
    }
    //^ Static methods
    static CountRectangle(){
        return this.numShapes;
    }
}


export {Rectangle};