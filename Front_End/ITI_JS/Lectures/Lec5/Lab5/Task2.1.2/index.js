//?Task2: Browser Object Model (BOM)
//? Task2.1: Typing message
//? 2.1.2

let win;
let message = "Welcome";

function OpenWindow() {
    win = window.open("win.html", "", "width=400, height=400");
    win.focus();
}
OpenWindow();

function CloseWindow() {
    clearInterval(intervalID);
    win.close();
}
let i = 0;
let intervalID = setInterval(() => {
    if (i == message.length) {
        setTimeout(() => {
            CloseWindow();
        }, 500);
    }else{
        win.document.write(message[i++]);
    }
}, 500);

