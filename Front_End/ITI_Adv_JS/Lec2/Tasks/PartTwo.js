//? Part 2
//& Create Employee object (name,age,department,salary) contains 
//& setters , getters for salary (salary is private) and toString function to display Employee data on console 
//& - Consider You  have Array Of Employees 

//* Factory Function to create Employee objects
function createEmployee(name, age, department, sal) {
    // This variable is private because it's not a property of the returned object
    // It's captured by the getter and setter closures
    let _salary = sal;
    return {
        name: name,
        age: age,
        department: department,
        // Setter for salary
        setSalary: function(value) {
            _salary = value;
        },
        // Getter for salary
        getSalary: function() {
            return _salary;
        },
        // toString function to display data
        toString: function() {
            return `Employee: [Name: ${this.name}, Age: ${this.age}, Dept: ${this.department}, Salary: ${_salary}]`;
        }
    };
}

//* Create an Array of Employees
let employees = [
    createEmployee("Ahmed", 25, "IT", 15000),
    createEmployee("Mona", 30, "HR", 20000),
    createEmployee("Ali", 28, "Sales", 18000)
];
//& Q1: Create a function that returns another function that Take Emp and Return it’s Name
function fun1(){
    return function(Emp){
        return Emp.name;
    }
}
let funGetName = fun1();
console.log(funGetName(employees[0]));

//& Q2: Create a counter function that increases every time it’s called.
function fun2(){
    let counter = 0;
    return function(){
        counter++;
        return counter;
    }
}
let increaseCounter = fun2();
console.log(increaseCounter());
console.log(increaseCounter());
console.log(increaseCounter());

//& Q3: Create a function that tracks how many times a button is clicked each Time Clicked To 
//& change Body Background.
let btn = document.getElementById("btn");
function trackClicks(){
    let clickCount = 0;
    return function(){
        clickCount++;
        document.body.style.backgroundColor = `rgb(${(clickCount * 10) % 255}, 0, 0)`;
        console.log(`Button clicked ${clickCount} times`);
    }
}
btn.addEventListener("click", trackClicks());

//& Q4: Create a closure that adds a fixed number to any number.
function addFixedNumber(fixedNum){
    return function(num){
        return fixedNum + num;
    }
}
let add5 = addFixedNumber(5);
console.log(add5(10));
console.log(add5(20));

//& Q5: Create a closure that keeps track of how many employees have been added.
function employeeTracker() {
    let _count = employees.length; // Private Counter
    return function(newEmp) {
        employees.push(newEmp);
        _count++; 
        return `Total Employees is: ${_count}`;
    }
}

let addEmployee = employeeTracker();
console.log(addEmployee(createEmployee("ali", 23, "PD", 1000)));

//& Q6: Create a closure that Take a Bonus percentage and applies it To Emp Salary.
function setBonus(value){
    let bonus = value;
    return function(Emp){
        Emp.setSalary(Emp.getSalary() + bonus);
    }
}

let addBonus = setBonus(2000);
addBonus(employees[3]);
console.log(employees[3].getSalary());

//& Q7: Create a closure that remembers a department name and returns a Greeting. 
function greeting(Emp){
    let deptName = Emp.department;
    return function(){
        return `Hello ${deptName} Department!`;
    }
}
let greetDepartment = greeting(employees[3]);
console.log(greetDepartment());

//& Q8: Use map to get an array of employee names.
let empNames = employees.map(function(emp) {
    return emp.name;
});
console.log("Employee Names:", empNames);

//& Q9: Use filter to get only employees who earn more than 4500. 
let highEarners = employees.filter(function(emp) {
    return emp.getSalary() > 4500;
});

console.log("High Earners:", highEarners.map(e => e.name));

//& Q10: Use reduce to calculate the total Salaries. 
let totalSalaries = employees.reduce(function(acc, emp) {
    return acc + emp.getSalary();
}, 0);
console.log("Total Salaries:", totalSalaries);

//& Q11: Create a pure function that increases an employee salary by 10%. 
function increaseSalaryPure(emp) {
    return createEmployee(emp.name, emp.age, emp.department, emp.getSalary() * 1.10);
}

let originalEmp = employees[0];
let upgradedEmp = increaseSalaryPure(originalEmp);
console.log("Original Emp:", originalEmp.getSalary());
console.log("Upgraded Emp:", upgradedEmp.getSalary());

//& Q12: Add a new employee to EmpArray immutably(without changing  the original use map). 
let newEmployee = createEmployee("Samy", 40, "Admin", 5000);
let newEmpList = [...employees, newEmployee];
console.log("Original Array Length:", employees.length);
console.log("New Array Length:", newEmpList.length);

//& Q13: Write a higher-order function applyBonus(fn). 
function applyBonus(calcFn, emp) {
    let bonusAmount = calcFn(emp.getSalary());
    emp.setSalary(emp.getSalary() + bonusAmount);
}
let tenPercentBonus = (salary) => salary * 0.1;
applyBonus(tenPercentBonus, employees[1]);
console.log("Mona's Salary after higher-order function:", employees[1].getSalary());

//& Q14: Filter employees by department using a reusable curried function. 
const filterByDept = (deptName) => {
    return (emp) => emp.department === deptName;
}
let itFilter = filterByDept("IT");
let itEmployees = employees.filter(itFilter);
console.log("IT Employees:", itEmployees.map(e => e.name));

//& Q15: Use map to update salaries (+5%) without modifying the original.
let richEmployees = employees.map(function(emp) {
    return createEmployee(emp.name, emp.age, emp.department, emp.getSalary() * 1.05);
});

console.log("First Emp Original:", employees[0].getSalary());
console.log("First Emp Rich:", richEmployees[0].getSalary());