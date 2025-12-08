// Task1
for(let i = 1; i <= 6; i++){
    // document.write("<h" + i + ">Hello World</h" + i + ">");
    document.write(`<h${i}>Welcome to my page</h${i}>`);
}

// Task2
function tempStatus(temp){
    temp >= 30 ? document .write("Hot<br>") : document.write("Cold<br>");
}
tempStatus(35);
tempStatus(25);

// Task3
let sum = 0;
while(true){
    if(sum > 100){
        console.log("Sum: " + sum + "<br>");
        break
    }
    let userInput = Number(prompt("Enter a number (or 0 to stop):"));
    if(typeof userInput === 'number' && userInput !== 0){
        sum += userInput;
    }else{
        console.log("Sum: " + sum);
        break;
    }
}