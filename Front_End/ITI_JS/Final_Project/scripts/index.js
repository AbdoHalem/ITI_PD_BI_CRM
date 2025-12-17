//? Page1: Login Page
//? Page2: Register Page
//? Page3: Home Page
//? Page4: Product Page

//& Page1: Login Page
//^ Get the elements first
let userName = document.getElementById("user-name");
let password = document.getElementById("password");
let loginButton = document.getElementById("login-button");
let signUpLink = document.getElementById("signUp-link");
let nameError = document.getElementById("name-error");
let passwordError = document.getElementById("password-error");
//& Page2: Register Page
let registerBtn = document.getElementById("register-button");
//& Page3: Home Page
let sliderImg = document.getElementById("slider");
let numCards = 9;
//& Page4: Product Page
let backButton = document.getElementById('back-button');

//^ array to save the images of elements of the products
let prodImgs = [];
for(let i = 0; i < numCards; i++){
    prodImgs[i] = document.getElementById("image-"+(i+1));
}
//^ array to save the names of elements of the products
let prodNames = [];
for(let i = 0; i < numCards; i++){
    prodNames[i] = document.getElementById("image-"+(i+1)+"-name");
}
//^  Array to store all the products
let allProducts = [];
//^ Index of the current slider image
let sliderIndex = 0;

//? Page4: Product Page
/**
 * Logs the user in if their username and password match a cookie.
 * If the username does not match a cookie, displays an error message.
 * If the username matches a cookie but the password does not, displays an error message.
 * If both the username and password match a cookie, redirects the user to the home page.
 * @param {string} name - the username to log in with
 * @param {string} password - the password to log in with
 */
function Login(name, password){
    if(!HaveCookie(name)){
        nameError.style.display = "inline-block";
    }
    else{
        nameError.style.display = "none";
        let userPassword = GetCookie(name);
        if(userPassword !== String(password)){
            passwordError.style.display = "inline-block";
        }
        else{
            passwordError.style.display = "none";
            window.location.href = "home.html";
        }
    }
}

// 1. Only add event listener to signUpLink if it exists (Login Page)
//^ Redirects the user to the register page
if(signUpLink){
    signUpLink.addEventListener("click", () => {
        window.location.href = "register.html";
    });
}

// 2. Only add event listener to loginButton if it exists (Login Page)
//^ redirects the user to the home page
if (loginButton) {
    loginButton.addEventListener("click", () => {
        if(userName && password) {
            Login(userName.value, password.value);
        }
    });
}
// 3. Only add event listener to Enter Key if we are on Login Page
//^ Event listener for the enter key
if (userName && password){
    document.addEventListener("keydown", (event) => {
        if(event.key === "Enter"){
            Login(userName.value, password.value);
        }
    });
}

/**
 * Registers the user with the given name and password.
 * If the name does not match a valid regex, displays an error message.
 * If the password does not match a valid regex, displays an error message.
 * If both the name and password match a valid regex, sets the cookie and redirects the user to the login page.
 * @param {string} name - the username to register with
 * @param {string} password - the password to register with
 */
function Register(name, password){
    let namePattern = /^[a-zA-Z0-9._-]+$/;
    let passPattern = /^(?=.*[A-Z])(?=.*[._%+&#@-])[a-zA-Z0-9._%+&#@-]+$/;
    if(!namePattern.test(name)){
        nameError.style.display = "inline-block";
    }
    else{
        nameError.style.display = "none";
        if(!passPattern.test(password)){
            passwordError.style.display = "inline-block";
        }
        else{
            passwordError.style.display = "none";
            //^ Sets the cookie
            SetCookie(name, password, 7);
            //^ Redirects the user to the login page
            window.location.href = "index.html";
        }
    }
}

// 4. Only add event listener to registerBtn if it exists (Register Page)
//^ Redirects the user to the login page
if (registerBtn) {
    registerBtn.addEventListener("click", () => {
        if(userName && password){
            Register(userName.value, password.value);
        }
    });
}

// 5. Only add event listener to Enter Key if we are on Register Page
//^ Event listener for the enter key
if (userName && password){
    document.addEventListener("keydown", (event) => {
        if(event.key === "Enter"){
            Register(userName.value, password.value);
        }
    });
}

//& Page3: Home Page
/**
 * Fetches products from the Fake Store API and executes a given callback function with the data.
 * @param {function} callback - function to execute with the data
 */
function GetProducts(callback){
    let url = "https://fakestoreapi.com/products";
    let xhr = new XMLHttpRequest();
    //^ Open the request
    xhr.open('GET', url);
    //^ Send the request
    xhr.send("");
    xhr.onreadystatechange = function(){
        //^ Check the response status
        if(xhr.readyState === 4 && xhr.status === 200){
            let data = xhr.responseText;
            data = JSON.parse(data);    //* Now, data is an array of objects
            // console.log(data[0]);    //^ Log the first object
            //! Instead of returning data (which won't work because xmlhttprequest is asynchronous), 
            //^ we call the callback function and pass the data to it.
            if(callback){
                callback(data);
            }
        }
    }
}

// let allProducts = [];   //* Array to store all the products
// let sliderIndex = 0;    //* Index of the current slider image

/**
 * Shows the products on the home page.
 * Fetches products from the Fake Store API, displays the products in the home page, and starts the slider.
 * This function is called only after the data has arrived from the server.
 */
function ShowProducts(){
    //^ We call GetProducts and pass a function that defines what to do with the data
    GetProducts(function(products){
        //~ This code runs ONLY after data arrives from the server
        allProducts = products;
        for(let i = 0; i < numCards; i++){
            //^ Check if product exists to avoid errors if API returns fewer items
            if(products[i]) {
                prodImgs[i].src = products[i].image;
                prodNames[i].innerText = products[i].title;
            }
        }
        StartSlider();
    });
}

//^ Check if we are on the home page to display the products
document.addEventListener("DOMContentLoaded", () => {
    const path = window.location.pathname;
    if(path.includes("home.html")){
        ShowProducts();
    } 
});

function StartSlider(){
    sliderImg.src = allProducts[sliderIndex].image;
    setInterval(() => {
        sliderIndex = (sliderIndex+1) % numCards;
        sliderImg.src = allProducts[sliderIndex].image;
    }, 3000);
}

// Add click event to all product cards to navigate to product page
if(prodImgs){
    let cards = document.querySelectorAll('.image');
    cards.forEach((card, index) => {
        card.addEventListener('click', () => {
            // Store only the product index in localStorage
            localStorage.setItem('selectedProductIndex', index);
            // Navigate to product page
            window.location.href = "product.html";
        });
    });
}

// Page 4: Product Page - Load product details
document.addEventListener("DOMContentLoaded", () => {
    const path = window.location.pathname;
    if(path.includes("product.html")){
        //^ Add back button functionality
        // let backButton = document.getElementById('back-button');
        if(backButton) {
            backButton.addEventListener('click', () => {
                window.location.href = "home.html";
            });
        }
        
        //^ Fetch products from API
        GetProducts(function(products) {
            //^ Get the stored product index
            let productIndex = localStorage.getItem('selectedProductIndex');
            
            if(productIndex !== null && products[productIndex]) {
                let product = products[productIndex];
                
                //^ Display product information
                let productImage = document.getElementById('product-image');
                let productTitle = document.getElementById('product-title');
                let productPrice = document.getElementById('product-price');
                let productDescription = document.getElementById('product-description');
                let productCategory = document.getElementById('product-category');
                let productRating = document.getElementById('product-rating');
                
                if(productCategory) {productCategory.innerText = "Category: " + product.category;}
                if(productRating) {productRating.innerText = "Rating: " + product.rating.rate + "/5";}
                if(productImage) {productImage.src = product.image;}
                if(productTitle) {productTitle.innerText = product.title;}
                if(productPrice) {productPrice.innerText = "Price: $" + product.price;}
                if(productDescription) {productDescription.innerText = product.description;}
            }
        });
    } 
});