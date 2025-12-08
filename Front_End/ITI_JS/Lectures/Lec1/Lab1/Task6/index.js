// Task 6
let userName;
while(true){
    userName = prompt("Enter your name:");
    if (userName === null || userName.trim() === "") {
        alert("Input cannot be empty. Please enter your name.");
    }
    else if(!isNaN(userName)){
        alert("Invalid input. Please enter a valid name.");
    }
    else{
        break;
    }
}
let userbirth;
while(true){
    userbirth = prompt("Enter your birth year:");
    if (userbirth === null || userbirth.trim() === "") {
        alert("Input cannot be empty. Please enter your name.");
    }
    else if(isNaN(userbirth)){
        alert("Invalid input. Please enter a valid age.");
    }
    else if(userbirth > 2010){
        alert("Invalid input. Please enter a valid age.");
    }
    else{
        age = Number(userbirth);
        break;
    }
}
document.write(`<h1>Name: ${userName} <br> Birth Year: ${userbirth} <br> Age: ${2025 - age}</h1>`);