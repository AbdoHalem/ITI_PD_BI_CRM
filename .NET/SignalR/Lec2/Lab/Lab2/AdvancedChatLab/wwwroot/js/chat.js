"use strict";

// Establish connection to the SignalR Hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub").build();

// Helper function to append messages to the chat board
function appendToBoard(message, color = "black") {
    const board = document.getElementById("chatBoard");
    const p = document.createElement("p");
    p.style.color = color;
    p.textContent = message;
    board.appendChild(p);
    board.scrollTop = board.scrollHeight; // Auto-scroll to the bottom
}

// Listeners for incoming Hub calls (Must match exactly the method names sent from ChatHub)
connection.on("ReceiveNotification", function (senderName, roomName, message) {
    appendToBoard(`[${roomName}] ${senderName}: ${message}`, "gray");
});

connection.on("ReceiveRoomMessage", function (senderName, roomName, message) {
    appendToBoard(`[${roomName}] ${senderName}: ${message}`, "blue");
});

connection.on("ReceivePrivateMessage", function (senderName, message) {
    appendToBoard(`[Private from ${senderName}]: ${message}`, "purple");
});

connection.on("RoomCreatedNotification", function (roomName) {
    appendToBoard(`[Alert]: A new room named '${roomName}' was just created!`, "red");

    // Dynamically add the new room to the dropdown without refreshing the page
    const roomSelect = document.getElementById("roomSelect");
    const option = document.createElement("option");
    option.value = roomName;
    option.text = roomName;
    roomSelect.appendChild(option);
});

// Start the connection
connection.start().then(function () {
    console.log("SignalR Connected!");
}).catch(function (err) {
    return console.error(err.toString());
});

// UI Event Listeners for invoking Hub and Controller methods

// Join Room Button
document.getElementById("btnJoinRoom").addEventListener("click", function (e) {
    const roomName = document.getElementById("roomSelect").value;
    if (roomName) {
        // Call JoinRoom method in ChatHub
        connection.invoke("JoinRoom", roomName).catch(function (err) {
            return console.error(err.toString());
        });
    }
});

// Send Public Message Button
document.getElementById("btnSendPublic").addEventListener("click", function (e) {
    const roomName = document.getElementById("roomSelect").value;
    const message = document.getElementById("publicMessage").value;
    if (roomName && message) {
        // Call SendMessageToRoom method in ChatHub
        connection.invoke("SendMessageToRoom", roomName, message).catch(function (err) {
            return console.error(err.toString());
        });
        document.getElementById("publicMessage").value = "";
    }
});

// Send Private Message Button
document.getElementById("btnSendPrivate").addEventListener("click", function (e) {
    const receiverId = document.getElementById("userSelect").value;
    const message = document.getElementById("privateMessage").value;
    if (receiverId && message) {
        // Call SendPrivateMessage method in ChatHub
        connection.invoke("SendPrivateMessage", receiverId, message).catch(function (err) {
            return console.error(err.toString());
        });
        document.getElementById("privateMessage").value = "";
    }
});

// Create Room Button (Calls Controller via AJAX, which then triggers Hub)
document.getElementById("btnCreateRoom").addEventListener("click", function (e) {
    const roomName = document.getElementById("newRoomName").value;
    if (roomName) {
        // Use Fetch API to call the MVC action
        fetch(`/Chat/CreateRoom?roomName=${encodeURIComponent(roomName)}`, {
            method: 'POST'
        })
            .then(response => {
                if (response.ok) {
                    document.getElementById("newRoomName").value = "";
                } else {
                    alert("Error creating room!");
                }
            });
    }
});

