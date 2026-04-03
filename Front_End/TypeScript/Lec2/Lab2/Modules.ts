// Importing the function and the class from mathUtils.ts
import { addNumbers, Calculator } from './mathUtils.js';

// Using the imported function
let sum = addNumbers(10, 5);
console.log(`Sum: ${sum}`);

// Using the imported class
let calc = new Calculator();
console.log(`Multiplication: ${calc.multiply(4, 5)}`);