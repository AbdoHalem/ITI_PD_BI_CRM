//? Task1.1
// let radius = prompt("Enter the radius of the circle:");
// let area = Math.PI * Math.pow(radius, 2);
// alert("The area of the circle is: " + area);

//? Task1.2
// let angle = prompt("Enter the angle in degrees:");
// let cos_res = Math.cos(angle * Math.PI / 180.0);
// document.write("The cosine of " + angle + " degrees is: " + cos_res + "<br>");

//? Task1.3
// let value = prompt("Enter a number:");
// alert("The square root of " + value + " is "+ Math.sqrt(value));


//? Task2
// let num1 = prompt("Enter start number: ");
// let num2 = prompt("Enter end number: ");
// for(let i = num1; i <= num2; i++){
//     if(i%2 === 1){console.log("odd", i);}
// }

//? Task3
// let tips = ["Js is a front-end and also back-end language.",
//             "Js have different types of functions.",
//             "tip 3", "tip 4", "tip 5", "tip 6", "tip 7",
//             "tip 8", "tip 9", "tip 10"
// ]
// console.log(tips[Math.round(Math.random()*10)]);

//? Task4
// let mathExpr = prompt("Enter a mathematical expression: ");
function evalExpression(expr){
    let elements = expr.split(" ");
    console.log("expression is", elements);
    let numbers = [];
    let operators = [];

    for(let i = 0; i < elements.length; i++){
        // if(elements[i] === "+" || elements[i] === "-" || elements[i] === "*" || elements[i] === "/"){
        //* using regex
        if(/^[*/+-]$/.test(elements[i])){    
            operators.push(elements[i]);
        }else{
            numbers.push(elements[i]);
        }
    }

    let res = 0;
    for(let i = 0; i < operators.length; i++){
        let firstOperand;
        if(i === 0){firstOperand = parseFloat(numbers[i]);}
        else{firstOperand = res;}
        switch(operators[i]){
            case "+":
                res = firstOperand + parseFloat(numbers[i+1]);
                break;
            case "-":
                res = firstOperand - parseFloat(numbers[i+1]);
                break;
            case "*":
                res = firstOperand * parseFloat(numbers[i+1]);
                break;
            case "/":
                res = firstOperand / parseFloat(numbers[i+1]);
                break;
            default:
                break;
        }
    }
    return res;
}
// alert("You entered: " + mathExpr + "\nThe result is: " + evalExpression(mathExpr));

//? Task5
//* a-
let students = [{name: "Halem", degree: 95},
    {name: "Ahmed", degree: 89},
    {name: "Sayed", degree: 58},]

// console.log("Students who are above 90:");
// let above90 = students.find((student) => student.degree >= 90).name;
// console.log(above90);

//* b-
// console.log("Students who are less than 60:");
// let less60 = students.filter((student) => student.degree < 60);
// let namesLess60 = less60.map((student) => student.name);
// console.log(namesLess60);

//* c-
// students.push({name: "Gamal", degree: 85});
// for(let i in students){
//     console.log(students[i].name + " ---> " + students[i].degree);
// }

//* d-
// students.pop();
// for(let i of students){
//     console.log(i.name + " ===> " + i.degree);
// }

//* e-
// students.sort((a,b) => a.name.localeCompare(b.name));
// console.log("After sorting in alphabetical order by name:");
// for(let i of students){
//     console.log(i.name + " ===> " + i.degree);
// }

//* f-
// students.splice(2, 0, {name: "Salem", degree: 80}, {name: "Khaled", degree: 55});
// console.log("After adding two students at index 1:");
// for(let i of students){
//     console.log(i.name + " ===> " + i.degree);
// }

//* g-
// students.splice(3, 1);
// console.log("After removing the student at index 2:");  
// for(let i of students){
//     console.log(i.name + " ===> " + i.degree);
// }

//& /////////////////////////////////////////////////

//? Task6
//* solution 1 --> arguments object
function reverseParam(){
    let args = Array.from(arguments);
    let reversed = args.reverse();
    return reversed;
}
console.log(reverseParam(1,2,3,4,5));
//* solution 2 --> rest parameters
const reverseParam2 = (...args)=>{
    return args.reverse();
}
console.log(reverseParam2(1,2,3,4,5));

function func(a, b){
    if(arguments.length !== 2){
        throw new Error("You should enter two arguments");
    }
    else{
        console.log(a + b);
    }
}

try{
    func(1, 2)
    func(1);
}catch(err){
    console.error(err);
}

