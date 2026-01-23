//? Part 1
//& 1- Using Constructor function to create Shape Base Abstract Class which contains color property
//& And PrintColor method and CalcArea and Calcperimeter which will return Zero in Shape 
//& Base Class  Define them on Shape prototype object (Using Prototype)
function Shape(_color){
    if(this.constructor.name=="Shape"){
        throw new Error("This is Abstract Class");
    }
    this.color = _color;
}
//^ Methods Creation
Shape.prototype.PrintColor = function() { return this.color; };
Shape.prototype.CalcArea = function() { return 0; };
Shape.prototype.CalcPerimeter = function() { return 0; };

//& 2- Define Rect Class Which inherits from Shape Abstract Class (Using Prototype  inheritance)
//& Define Width and Height Properties for Rect Class
function Rectangle(_color, _width, _height){
    //* Check if the constructor is called directly from Rectangle class
    if (this.constructor.name == "Rectangle"){
        Rectangle.numRectangles++;
    }
    Shape.call(this, _color);
    this.width = _width;
    this.height = _height;
}
//^ Make Rectangle inherits from Shape
Rectangle.prototype = Object.create(Shape.prototype);
Rectangle.prototype.constructor = Rectangle;
//^ Methods Overriding
Rectangle.prototype.CalcArea = function() { return this.width * this.height; };
Rectangle.prototype.CalcPerimeter = function() { return (this.width + this.height) * 2; };
Rectangle.prototype.toString = function() {
    return `Rectangle -> Color: ${this.PrintColor()}, Area: ${this.CalcArea()}, Perim: ${this.CalcPerimeter()}`;
};
//^ Static member initialization
Rectangle.numRectangles = 0;
Rectangle.getCount = function() {
    return Rectangle.numRectangles;
};

//& 3- Define Square Class Which inherits from Rect Class - override CalcArea , 
//& calcperimeter , printColor , toString which will display color , area and perimeter in rect and square classes
function Square(_color, _side){
    Rectangle.call(this, _color, _side, _side);
    Square.numSquares++;
}
//^ Make Square inherits from Rectangle
Square.prototype = Object.create(Rectangle.prototype);
Square.prototype.constructor = Square;
//^ Methods Overriding
Square.prototype.toString = function() {
    return `Square -> Color: ${this.PrintColor()}, Area: ${this.CalcArea()}, Perim: ${this.CalcPerimeter()}`;
};
//^ Static member initialization
Square.numSquares = 0;
Square.getCount = function() {
    return Square.numSquares;
};

//& create array object which will contains set of objects from rect and square classes then display it’s areas
let arrShapes = [new Rectangle("Red", 3, 4), new Square("Green", 4, 4)];
console.log(`Rectangle Area: ${arrShapes[0].CalcArea()}`);
console.log(`Square Area: ${arrShapes[1].CalcArea()}`);

//& 4- Define static property and static method like following case for Rect and Square classes 
//& to get number of objects created from rect and square Types
console.log(`Number of Rectangles: ${Rectangle.numRectangles}`);
console.log(`Number of Squares: ${Square.numSquares}`);