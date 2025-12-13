//Task5
//? Task5: Dublicate an image when clicking on it

let headerDiv = document.getElementById("header");
let navDiv = document.getElementById("navigation");
let originalImg = document.getElementsByTagName("img")[0]; // أو headerDiv.children[0]

// Fig. c shows the top image on the right side
headerDiv.style.textAlign = "center";

// Fig. c shows the list centered
navDiv.style.textAlign = "center";
// Fig. c shows the list without bullets
document.getElementById("nav").style.listStyleType = "none";

originalImg.addEventListener("click", () => {
    headerDiv.style.textAlign = "right";
    //^ Clone the image and store it in a variable
    let clonedImg = originalImg.cloneNode(true);
    //^ Create a new div and store it in a variable
    let footerDiv = document.createElement("div");
    //^ Add a class to the new div
    footerDiv.style.textAlign = "left";
    footerDiv.appendChild(clonedImg);
    //^ Append the new div to the body
    document.body.appendChild(footerDiv);
})

