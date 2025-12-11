//? Task2
//& Associative Array of Images of name image and describe each image
let images = [
    {   "name":"image.jfif",
        "description": "flower"},
    {   "name":"tree.webp",
        "description": "tree"}
    ]

let div = document.getElementById("imageContainer");
let img = document.getElementById("slideshow");
let describe = document.getElementById("description");
img.setAttribute("src", images[0].name);    //* Set the source of the image
img.setAttribute("alt", images[0].description);     //* Set the alt text of the image
describe.textContent = images[0].description;   //* Set the text content of the paragraph

let nexBtn = document.getElementById("nextBtn");
let prevBtn = document.getElementById("prevBtn");
let currentIndex = 0;
nexBtn.onclick = function(){
    currentIndex++;
    if(currentIndex >= images.length){
        currentIndex = 0;
    }
    img.setAttribute("src", images[currentIndex].name);
    img.setAttribute("alt", images[currentIndex].description);
    describe.textContent = images[currentIndex].description;
}
prevBtn.onclick = function(){
    currentIndex--;
    if(currentIndex < 0){
        currentIndex = images.length - 1;
    }
    img.setAttribute("src", images[currentIndex].name);
    img.setAttribute("alt", images[currentIndex].description);
    describe.textContent = images[currentIndex].description;
}
