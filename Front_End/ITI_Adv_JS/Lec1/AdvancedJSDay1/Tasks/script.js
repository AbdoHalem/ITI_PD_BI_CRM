//? Task1
let todoList = {
    tasks: [],
    addTask: function(task){
        this.tasks.push(task);
    },
    removeTask: function(task){
        this.tasks.pop(task);
    },
    listTasks: function(){
        console.log(this.tasks);
    }
}

todoList.addTask("Task 1");
todoList.addTask("Task 2");
todoList.addTask("Task 3");
todoList.listTasks();
todoList.removeTask();
todoList.listTasks();

//? Task2
let userProfile = {
    name: "",
    age: 0,
    address: {
        street: "",
        city: ""
    },
    getFullAddress: function(){
        return `${this.address.street}, ${this.address.city}`;
    }
}

let userOperations = {
    arrUsers: [],
    addUser: function(name, age, street, city){
        let userProfile = {
            name: name,
            age: age,
            address: {
                street: street,
                city: city
            },
            getFullAddress: function(){
                return `${this.address.street}, ${this.address.city}`;
            }
        }
        this.arrUsers.push(userProfile);
    },
    SortingbyName: function(){
        //* sort() modifies the array in place
        this.arrUsers.sort((a, b) => a.name.localeCompare(b.name));
    },
    SortingbyAge: function(){
        this.arrUsers.sort((a, b) => a.age - b.age);
    },
    FilterbyAge: function(minAge){
        //* filter() returns a new array, it does NOT change arrUsers
        return this.arrUsers.filter((user) => user.age > minAge);
    }
}


userOperations.addUser("Halem", 24, "Khairallah", "Alexandria");
userOperations.addUser("Ahmed", 23, "Awamy", "Alexandria");
userOperations.addUser("Khaled", 22, "Hanouvil", "Alexandria");
console.log("--- 1. Initial State (Insertion Order) ---");
// console.log(userOperations.arrUsers);
// Using JSON.stringify to see the SNAPSHOT at this exact moment
console.log(JSON.parse(JSON.stringify(userOperations.arrUsers)));
console.log("--- 2. Sorted by Name (A-Z) ---");
userOperations.SortingbyName();
console.log(JSON.parse(JSON.stringify(userOperations.arrUsers)));
// console.log(userOperations.arrUsers);
console.log("--- 3. Sorted by Age (Youngest First) ---");
userOperations.SortingbyAge();
console.log(JSON.parse(JSON.stringify(userOperations.arrUsers)));
// console.log(userOperations.arrUsers);
console.log("--- 4. Filtered (Age > 23) ---");
// We must print the RETURN value of the function
let filteredResult = userOperations.FilterbyAge(23);
console.log(filteredResult);
