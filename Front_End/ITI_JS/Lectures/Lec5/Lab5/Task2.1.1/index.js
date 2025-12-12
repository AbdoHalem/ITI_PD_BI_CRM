//?Task2: Browser Object Model (BOM)
//? Task2.1: Window Object
//? 2.1.1
let win;
let intervalID;
let y = 0;
let step = 100;

function OpenWindow(){
    if(win && !win.closed){
        return;
    }
    
    win = open("win.html","","width=150,height=150");
    win.focus();
    
    if(intervalID){
        clearInterval(intervalID);
    }
    y = 0;
    step = 100;
    intervalID = setInterval(()=>{
        MoveWindow();
    }, 1000);
}

function MoveWindow(){
    if(!win || win.closed){
        clearInterval(intervalID);
        return;
    }
    
    y += step;
    win.moveBy(0, step);
    
    if(y >= screen.height - 200){
        step = -100;  
    }
    if(y <= 0){
        step = 100;
    }
    
    win.focus();
}

function CloseWindow(){
    if(win && !win.closed){
        win.close();
    }
    if(intervalID){
        clearInterval(intervalID);
        intervalID = null;
    }
}

