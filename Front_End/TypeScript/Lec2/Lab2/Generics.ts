// Generic function that accepts an argument of type T and returns the same type T
function returnItem<T>(item: T): T {
    return item;
}

// Using the generic function with a string
let stringResult = returnItem<string>("Hello ITI");
console.log(stringResult);

// Using the same generic function with a number
let numberResult = returnItem<number>(100);
console.log(numberResult);

// Generic Class example
class Box<T> {
    content: T;

    constructor(value: T) {
        this.content = value;
    }

    getContent(): T {
        return this.content;
    }
}

let stringBox = new Box<string>("This is a string box");
let numberBox = new Box<number>(2026);

console.log(stringBox.getContent());
console.log(numberBox.getContent());
