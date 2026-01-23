//& 1- Create  Shape Base Abstract Class which contains color property  as private with set 
//&and get,PrintColor and CalcArea and Calcperimeter methods which will return Zero in Shape Base.
class Shape{
    #color = 0;
    constructor(_color){
        this.#color = _color;
    };
    //^ Setters & Getters
    set_color(_value){
        this.#color = _value;
    }
    get_color(){
        return this.#color;
    }
    //^ Methods
    PrintColor(){
        return this.#color;
    }
    CalcArea(){
        return 0;
    }
    CalcPerimeter(){
        return 0;
    }
}

export {Shape};
