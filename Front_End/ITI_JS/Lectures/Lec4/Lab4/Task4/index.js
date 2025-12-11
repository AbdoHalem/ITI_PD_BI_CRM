//? Task4
const paragraphDiv = document.getElementById("paragraph-section");
const text = document.getElementById("paragraph-text");
const buttonsDiv = document.getElementById("control-section"); //^ buttonsDiv

//^ Create radio buttons to control the style of the paragraph text
//& Create an array of radio button objects
const radioButtons = [
    { value: "bold", label: "Bold" },
    { value: "dark", label: "Dark" },
    { value: "white", label: "White" },
];
//^ Create radio buttons
radioButtons.forEach((radioButton) => {
    const radio = document.createElement("input");
    radio.type = "radio";
    radio.name = "style";
    radio.value = radioButton.value;
    radio.id = radioButton.value;

    radio.addEventListener("change", handleRadioChange);

    const label = document.createElement("label");
    label.htmlFor = radioButton.value;
    label.textContent = radioButton.label;

    buttonsDiv.appendChild(radio);
    buttonsDiv.appendChild(label);
});

//^ Create a function to handle the change event of the radio buttons
function handleRadioChange() {
    const selectedStyle = document.querySelector('input[name="style"]:checked').value;
    
    if (selectedStyle === "bold") {
        text.style.fontWeight = "bold";
        text.style.color = "black";
        text.style.backgroundColor = "white";
    } else if (selectedStyle === "dark") {
        text.style.fontWeight = "normal";
        text.style.color = "white";
        text.style.backgroundColor = "black";
    } else if (selectedStyle === "white") {
        text.style.fontWeight = "normal";
        text.style.color = "black";
        text.style.backgroundColor = "white";
    }
}

