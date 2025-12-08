// Task 4
alert("Welcome to my site!");

let userName = prompt("Please enter your name:");
document.write("<h1>Welcome, " + userName + "!</h1>");

// Task 5
function Divisible(x, y, z){
    if(x%y === 0 && x%z === 0){
        document.write("<h3>" + x + " is divisible by " + y + " and " + z + ".</h3>");
    }
    else if(x%y === 0){
        document.write("<h3>" + x + " is divisible by " + y + "only.</h3>");
    }
    else if(x%z === 0){
        document.write("<h3>" + x + " is divisible by " + z + "only.</h3>");
    }else{
        document.write("<h3>" + x + " is not divisible by " + y + " or " + z + ".</h3>");
    }
}
Divisible(15, 3, 5);
Divisible(10, 3, 5);
Divisible(9, 3, 5);
Divisible(7, 3, 5);
