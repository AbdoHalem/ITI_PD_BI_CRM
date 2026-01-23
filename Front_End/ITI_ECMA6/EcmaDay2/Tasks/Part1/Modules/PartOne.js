//? Part One
//& Create array of Shapes which will contains set of objects from rect and square classes then display it’s areas

import { Rectangle } from "./Rectangle_Module.js";
import { Square } from "./Square_Module.js";

let arrShapes = [new Square(4, "green"), new Rectangle(3, 4, "red")];
console.log(`Square Area: ${arrShapes[0].CalcArea()}`)
console.log(`Recatnagle Area: ${arrShapes[1].CalcArea()}`)

//& 5- Create static property and static method inside  Rect and Square classes to get number 
//& of objects created from rect and square Types
console.log(`Number of rectangles: ${Rectangle.CountRectangle()}`)
console.log(`Number of squares: ${Square.CountSquare()}`)
