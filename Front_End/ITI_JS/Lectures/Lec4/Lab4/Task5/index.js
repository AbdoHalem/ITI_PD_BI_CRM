//Task6
//~ B.1
document.addEventListener("keydown", (e) => {
    console.log(e.key);        //* prints the key that is pressed
    console.log(e.keyCode);    //* prints the key ascii code
    alert("The ASCII code of " + e.key + " is " + e.keyCode)
});

//~ B.2
document.addEventListener("contextmenu", (e) => {
    e.preventDefault();
    alert("Right click is disabled")
});