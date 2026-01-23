//& 1- Define an array of numbers (only let is allowed)
let arrNums= [5, 2, 4, 1, 90, 8];

//& Sort them ascending then descending (using array sort method and Arrow functions)
arrNums.sort((a, b) => a - b);
console.log(arrNums);
arrNums.sort((a, b) => b - a);
console.log(arrNums);

//& Filter numbers larger than 50 (using array filter method and Arrow functions)
let filteredNums = arrNums.filter((a) => a > 50);
console.log(filteredNums);

//& Display Max and Min Numbers (using math methods and spread operator)
console.log(`Max number: ${Math.max(...arrNums)}`);
console.log(`Min number: ${Math.min(...arrNums)}`);

//& 2- Define javascript function that takes only 2 arguments operator and any 
//& numbers of integers (using Rest operator) then display the result of operation on 
//& console on one line  (using substitution $ with bactecks ` ) as follow “result of sum operation for 3,1,6,3 is 13”
function sum(num1, num2, ...restNums){
    let sum = num1 + num2 + restNums.reduce((acc, current) => acc + current, 0);
    console.log(`Result of sum operation for ${[num1, num2, ...restNums].join(",")} is ${sum}`);
}

//& 3- Create constant project anonymouse object after takeing properties names 
//& and values  from user  (using object literals ) Note: names are projectId , projectName ,duration and printData which console.log all project data
let projectId = 1234;
let projectName = "New Website";
let duration = 6;
const project = {
    projectId,
    projectName,
    duration,
    printData(){
        console.log(`Project ID: ${this.projectId}, Project Name: ${this.projectName}, Duration: ${this.duration}`);
    }
};
project.printData();