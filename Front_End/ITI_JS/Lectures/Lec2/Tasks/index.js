//? Task1.1
// let str = prompt("Enter a string:");
// let char = prompt("Enter a character to count its occurrences:");
// let caseSensitive = prompt("Should the count be case-sensitive? (yes/no):").toLowerCase();

function countChar(string, ch, sensitive){
    let count = 0;
    if(sensitive === 'no'){
        string = string.toLowerCase();
        ch = ch.toLowerCase();
    }
    let index = 0;
    let length = string.length;
    for(let i = 0; i < length; i++){
        index = string.indexOf(ch);
        if(index !== Number(-1)){
            count++;
            string = string.slice(index + 1, );
            i = index + 1;
            console.log(string, count);
        }
    }
    return count;
}

// let occurrences = countChar(str, char, caseSensitive);
// confirm(`The character "${char}" occurs ${occurrences} times in the ${str} string.`);

//? Task1.2
// let sentence = prompt("Enter a string: ");
// let sensitive = confirm("Should the palindrome be case-sensitive? (OK for Yes / Cancel for No)");
// console.log(sensitive);
function isPalindrome(str, sensitive){
    let res;
    if(!sensitive){
        str = str.toLowerCase();
    }
    let reversedStr = str.split("").reverse().join("");
    if(reversedStr === str){
        res = true;
    }
    else{
        res = false;
    }
    return res;
}
// let palinResult = isPalindrome(sentence, sensitive);
// alert(`The string "${sentence}" is ${palinResult ? '' : 'not '}a palindrome.`);

//? Task1.3
// let sentence = prompt("Enter a sentense: ");

function getLargestStr(sentence){
    let arr = sentence.split(" ");
    let index = 0;
    for(let i = 1; i < arr.length; i++){
        if(arr[i].length > arr[index].length){
            index = i;
        }
    }
    return arr[index];
}
// let largestStr = getLargestStr(sentence);
// alert(`The largest word in the sentence is: "${largestStr}"`);

//? Task1.4
let valid = 0;
let name;
while(!valid){
    name = prompt("Enter your full name: ");
    let pattern = /^[A-Za-z\s]+$/;
    if(pattern.test(name)){
        valid = 1;
    }
    else{
        alert("Invalid name. Please enter alphabetic characters only.");
    }
}
// alert(`Welcome, ${name}!`);

let phone_num;
valid = 0;
while(!valid){
    phone_num = prompt("Enter your phone number: ");
    let pattern = /^\d{8}$/;
    if(pattern.test(phone_num)){
        valid = 1;
    }
    else{
        alert("Invalid phone number. Please enter an 8-digit number.");
    }
}
// alert(`Welcome, ${phone_num}!`);

let mobile_num;
valid = 0;
while(!valid){
    mobile_num = prompt("Enter your mobile number: ");
    let pattern = /^01[012]\d{8}$/;
    if(pattern.test(mobile_num)){
        valid = 1;
    }
    else{
        alert("Invalid phone number. Please enter an 11-digit number.");
    }
}

let email;
valid = 0;
while(!valid){
    email = prompt("Enter your email: ");
    let pattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if(pattern.test(email)){
        valid = 1;
    }
    else{
        alert("Invalid phone number. Please enter an 8-digit number.");
    }
}
// alert(`Welcome, ${email}!`);

document.body.innerHTML = `<h1>Welcome, ${name}!</h1>
<p>Phone Number: ${phone_num}</p>
<p>Mobile Number: ${mobile_num}</p>
<p>Email: ${email}</p>`;