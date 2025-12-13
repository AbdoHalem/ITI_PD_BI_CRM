//Task7
//? Task7: Create a registration form with HTML5 form validation
//^ Helper function to handle borders and background colors
//& Requirement 14: Change background to gray if invalid, white if valid
function setValidationStatus(inputElement, isValid) {
    if (isValid) {
        inputElement.style.backgroundColor = "white";
        // Optionally reset border color if needed
        inputElement.style.border = "1px solid #ccc"; 
    } else {
        inputElement.style.backgroundColor = "gray"; 
    }
}

//^ Helper function to check form validity
function checkFormValidity() {
    // Re-evaluating submit button state based on all flags
    // Note: Since we moved validation to 'blur', these flags update only after user leaves fields.
    if (termsBox.checked && nameValid && emailValid && confirmPasswordValid) {
        submitBtn.disabled = false;
    } else {
        submitBtn.disabled = true;
    }
}

//^ Handle user full name
let nameInput = document.getElementById("name-text");
let nameErrorMsg = document.getElementById("name-error");
let pattern = /^[A-Za-z\s]+$/
let nameValid = false;
//* add event listener to check name
// Requirement 11: Show blue border on focus
nameInput.addEventListener("focus", function() {
    this.style.border = "solid 1px blue";
});

// Requirement 11: Remove blue border on blur (will be overwritten if invalid logic runs below, but standard behavior)
// Requirement 12: Validate on lost focus (blur)
nameInput.addEventListener("blur", function() {
    // Reset basic border first
    this.style.border = "1px solid #ccc";

    let name = this.value;
    // Condition: Not empty AND more than 3 letters
    // Regex matches alphabetic characters and spaces
    if (name !== "" && name.length > 3 && pattern.test(name)) {
        nameValid = true;
        nameErrorMsg.style.display = "none";
        setValidationStatus(this, true);
    } else {
        nameValid = false;
        // Show invalid message
        nameErrorMsg.style.display = "inline-block";
        setValidationStatus(this, false);

        // Requirement 12: focus and select all text
        this.focus();
        this.select();
    }
    checkFormValidity();
});

// nameInput.addEventListener("input", function(){
//     let name = nameInput.value;
//     if (pattern.test(name)) {
//         nameValid = true;
//         invalidMsg.style.display = "none";
//     }
//     else {
//         nameValid = false;
//         //* display the message beside the input field
//         invalidMsg.style.display = "inline-block";
//     }
// })

//^ Handle user email
let emailInput = document.getElementById("email-text");
let emailErrorMsg = document.getElementById("email-error");
let pattern2 = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
let emailValid = false;
//* add event listener to check email
emailInput.addEventListener("input", function(){
    let email = emailInput.value;
    if (pattern2.test(email)) {
        emailValid = true;
        emailErrorMsg.style.display = "none";
    }
    else {
        emailValid = false;
        emailErrorMsg.style.display = "inline-block";
    }
    checkFormValidity();
})


//^ Handle user confirm password
let passwordInput = document.getElementById("password-text");
let confirmPasswordInput = document.getElementById("confirm-password-text");
let passErrorMsg = document.getElementById("confirm-password-error");
let pattern4 = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
let confirmPasswordValid = false;
//* add event listener to check confirm password
confirmPasswordInput.addEventListener("input", function(){
    let confirmPassword = confirmPasswordInput.value;
    if (confirmPassword === passwordInput.value) {
        confirmPasswordValid = true;
        passErrorMsg.style.display = "none";
    }
    else {
        confirmPasswordValid = false;
        passErrorMsg.style.display = "inline-block";
    }
    checkFormValidity();
})

//^ Handle Checkbox
let termsBox = document.getElementById("checkbox-text");
let submitBtn = document.getElementById("submit-button");
// let validTerms = false;
termsBox.addEventListener("change", function(){
    checkFormValidity();
})
//^ Handle Submit
//* After successful submit, go to another page

submitBtn.addEventListener("click", function(){
    let page = window.open("win.html");
    page.onload = function() {
        page.document.body.innerHTML = "<h1>Thank you, " + nameInput.value + " for registering in our website</h1>";
    };
    // page.document.write("Thank you, "+ nameInput.value + " for registering in our website");
})