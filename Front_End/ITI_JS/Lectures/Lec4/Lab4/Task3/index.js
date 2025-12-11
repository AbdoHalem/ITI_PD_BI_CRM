//? Task3
const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const tasksList = document.getElementById("tasksList");

addBtn.addEventListener("click", () => {
    const taskText = taskInput.value;
    //^ if the user didn't enter a task
    if (!taskText) {
        alert("Please enter a task");
        return;
    }
    //^ Create new div for this task
    const taskDiv = document.createElement("div");
    //^ Create new span for this task
    const taskSpan = document.createElement("span");
    taskSpan.textContent = taskText;
    //^ Create done button
    const doneBtn = document.createElement("button");
    doneBtn.style.margin = "10px";
    doneBtn.textContent = "Done";
    //^ put the done button at rigth of the span
    taskSpan.appendChild(doneBtn);
    doneBtn.addEventListener("click", () => {
        // taskDiv.classList.add('completed');
        taskDiv.style.color = "green";
    });
    
    //^ Create delete button
    const deleteBtn = document.createElement("button");
    deleteBtn.textContent = "Delete";
    //^ put the delete button at rigth of the span
    taskSpan.appendChild(deleteBtn);
    deleteBtn.addEventListener("click", () => {
        taskDiv.remove();
    });

    taskDiv.appendChild(taskSpan);
    tasksList.appendChild(taskDiv);
    taskInput.value = "";
});