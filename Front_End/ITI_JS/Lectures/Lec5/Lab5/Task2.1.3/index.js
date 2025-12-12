//?Task2: Browser Object Model (BOM)
//? Task2.1: Window Object
//? 2.1.3: Scrollable advertising

let win;
let message = "Hello<br>ITI<br>engineers!<br>";
for (let i = 0; i < 7; i++) {
    message += message + "<br>";
}
function OpenWindow() {
    let w = 300;
    let h = 300;
    let left = (screen.width - w) / 2;
    let top = (screen.height - h) / 2;
    let features = `width=${w},height=${h},scrollbars=yes,left=${left},top=${top}`;
    win = window.open("win.html", "", features);
    win.focus();
    win.onload = function() {
        win.document.body.innerHTML = message;  //* fill content
        //^ scroll event
        win.onscroll = function() {
            if ((win.innerHeight + win.scrollY) >= win.document.body.scrollHeight){
                CloseWindow();
            }
        };
    };
}
OpenWindow();

function CloseWindow() {
    win.close();
}
