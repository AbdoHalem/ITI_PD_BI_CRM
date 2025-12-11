//? Task1: Create a function that adds an image to the DOM
function AddImage(imageSrc){
    let div = document.createElement("div");
    let img = document.createElement("img");
    img.setAttribute("src", imageSrc);
    div.insertBefore(img, div.firstChild);  //* insertBefore --> to add elem inside another elem at specific position
    // div.appendChild(img);   //* appendChild --> to add elem inside another elem at the end
    document.body.appendChild(div); //* appendChild --> to add elem inside another elem
    console.log(div.childNodes.length); //* to count number of child nodes
    //& we should use setTimeout to delay removal of image by 3 seconds
    div.removeChild(img); //* removeChild --> to remove specific child node
}
AddImage("image.jfif");
