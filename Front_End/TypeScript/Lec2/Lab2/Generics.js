"use strict";
// Generic function that accepts an argument of type T and returns the same type T
function returnItem(item) {
    return item;
}
// Using the generic function with a string
let stringResult = returnItem("Hello ITI");
console.log(stringResult);
// Using the same generic function with a number
let numberResult = returnItem(100);
console.log(numberResult);
// Generic Class example
class Box {
    content;
    constructor(value) {
        this.content = value;
    }
    getContent() {
        return this.content;
    }
}
let stringBox = new Box("This is a string box");
let numberBox = new Box(2026);
console.log(stringBox.getContent());
console.log(numberBox.getContent());
