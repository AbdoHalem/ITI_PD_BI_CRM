// A simple Class Decorator that logs a message when the class is defined
function Logger(constructor: Function) {
    console.log("Class is being created...");
    console.log(constructor);
}

// Applying the decorator to a class using the @ symbol
@Logger
class Person {
    name: string;

    constructor(name: string) {
        this.name = name;
        console.log("Person object initialized.");
    }
}

// When you run this code, the Logger decorator will execute automatically
let person1 = new Person("Abdo");