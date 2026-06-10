// Variables to keep track of the chat history and the current image
let chatHistory = [];
let currentMode = "chat";
let lastGeneratedImageBlob = null;  // Store the last image as a file (Blob) for editing

// DOM Elements
const modeSelector = document.getElementById("modeSelector");
const chatForm = document.getElementById("chatForm");
const promptInput = document.getElementById("promptInput");
const chatPane = document.getElementById("chatPane");

modeSelector.addEventListener("change", (e) => {
    currentMode = e.target.value;
    promptInput.placeholder = currentMode === "chat" ? "Type your message..." : "Describe the image you want to generate...";
});

// Form Submission
chatForm.addEventListener("submit", async (e) => {
    e.preventDefault();
    const promptText = promptInput.value.trim();
    if (!promptText) return;

    promptInput.value = "";     //* Clear the input after grabbing the text

    appendMessage(promptText, "user");  //* Show the user's message

    if (currentMode === "chat") {
        await handleChatMode(promptText);
    }
    else{
        await handleImageMode(promptText);
    }
});

//? Chat Mode Logic
async function handleChatMode(promptText) {
    // Add user message to history
    chatHistory.push({ role: "user", content: promptText });

    try{
        const response = await fetch("https://api.fireworks.ai/inference/v1/chat/completions", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${CHAT_API_KEY}`,
                "Accept": "application/json"
            },
            body: JSON.stringify({
                model: "accounts/fireworks/models/gpt-oss-20b",
                messages: chatHistory   //* Send the chat history
            })
        });

        const data = await response.json();
        const AiResponse = data.choices[0].message.content;

        //* Show the AI's response and add it to the history
        appendMessage(AiResponse, "ai");
        chatHistory.push({ role: "assistant", content: AiResponse });
    }
    catch(error){
        console.error("Error in chat API:", error);
        appendMessage("Error fetching chat response. Check console.", "ai");
    }
}

//? Image Mode Logic
async function handleImageMode(promptText) {
    const isEditRequest = lastGeneratedImageBlob &&
        (promptText.toLowerCase().includes("edit") ||
        promptText.toLowerCase().includes("change") ||
        promptText.includes("تعديل"));

    if (isEditRequest) {
        appendMessage("Editing the previous image...", "ai");
        await editExistingImage(promptText);
    }
    else{
        appendMessage("Generating a new image...", "ai");
        await generateNewImage(promptText);
    }
}


//? Helper function to append text messages to the chat pane
function appendMessage(text, sender) {
    const div = document.createElement("div");
    //* Align right for user, left for AI
    div.className = sender === "user" ? "d-flex justify-content-end mb-3" : "d-flex justify-content-start mb-3";
    
    const msgDiv = document.createElement("div");
    msgDiv.className = sender === "user" ? "msg msg-user" : "msg msg-ai";
    msgDiv.textContent = text;
    
    div.appendChild(msgDiv);
    chatPane.appendChild(div);
    chatPane.scrollTop = chatPane.scrollHeight; //* Auto-scroll to the latest message
}


//? Helper function to append images to the chat pane
function appendImage(url) {
    const div = document.createElement("div");
    div.className = "d-flex justify-content-start mb-3";
    
    const img = document.createElement("img");
    img.src = url;
    img.className = "generated-image";
    
    div.appendChild(img);
    chatPane.appendChild(div);
    chatPane.scrollTop = chatPane.scrollHeight;
}


//? Function to generate a new image
async function generateNewImage(promptText){
    try{
        const response = await fetch("https://api.fireworks.ai/inference/v1/image_generation/accounts/fireworks/models/stable-diffusion-xl-1024-v1-0",{
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${IMAGE_API_KEY}`,
                "Accept": "image/*",
            },
            body: JSON.stringify({
                prompt: promptText,
                width: 1024,
                height: 1024,
            })
        });

        // Check if the response was successful before parsing
        if(!response.ok) {
            const errorText = await response.text();
            throw new Error(`API Error: ${response.status} - ${errorText}`);
        }

        // Read the response as a file (Blob) instead of JSON
        const imageBlob = await response.blob();

        // Create a local URL for the downloaded blob so the <img> tag can display it
        const imageUrl = URL.createObjectURL(imageBlob);
        appendImage(imageUrl);

        // Bonus logic: Store the last image for future editing
        lastGeneratedImageBlob = imageBlob;
    }
    catch(error){
        console.error("Image Gen Error:", error);
        appendMessage(`Failed to generate image: ${error.message}`, "ai");
    }
}

//? Function to edit the existing image based on the user's prompt
async function editExistingImage(promptText){
    try{
        // 1. Convert the saved Blob into a Base64 string as required by Fireworks AI
        const reader = new FileReader();
        reader.readAsDataURL(lastGeneratedImageBlob);
        
        reader.onloadend = async () => {
            // The result includes the header (e.g., "data:image/png;base64,"), we need to extract just the base64 part
            const base64ImageUrl = reader.result;
            const base64Data = base64ImageUrl.split(',')[1];
            try{
                const response = await fetch("https://api.fireworks.ai/inference/v1/image_generation/accounts/fireworks/models/stable-diffusion-xl-1024-v1-0", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        "Authorization": `Bearer ${IMAGE_API_KEY}`,
                        "Accept": "image/*"
                    },
                    body: JSON.stringify({
                        image: base64Data,  // Sending the original image as base64 for modification
                        prompt: promptText,
                        width: 1024,
                        height: 1024,
                        prompt_strength: 0.3
                    })
                });

                if(!response.ok) {
                    const errorText = await response.text();
                    throw new Error(`API Error: ${response.status} - ${errorText}`);
                }

                // Read the edited response as a Blob
                const editedImageBlob = await response.blob();

                // Create local URL
                const editedImageUrl = URL.createObjectURL(editedImageBlob);
                appendImage(editedImageUrl);

                //* Update the stored Blob with the new edited image
                lastGeneratedImageBlob = editedImageBlob;
            }
            catch (innerError) {
                console.error("Inner Image Edit Error:", innerError);
                appendMessage(`Failed to edit image: ${innerError.message}`, "ai");
            }
        };       
    }
    catch(error){
        console.error("Image Edit Error:", error);
        appendMessage(`Failed to edit image: ${error.message}`, "ai");
    }
}