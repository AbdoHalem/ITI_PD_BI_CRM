//? Part 1
//& - Create Person Object Contains the following Properties: ID:1, Name : ”Empty” 
let person = {
    ID: 1,
    Name: "Empty"
}
//& - Create  Employee object which contains Salary property  with set and get using 
//& defineProperty  and set  this value with bouns  20% //& and make it’s prototype Person Object
let Employee = Object.create(person);
Object.defineProperties(Employee, {
    "Salary":{
        set(_value){
            this._s = _value * 1.2;
        },
        get(){
            return this._s;
        }
    }
})
Employee.Salary = 10000;
console.log(Employee.Salary);

console.log(Employee.ID);

//? Part 2
//& Create HREmployee object which contains location Property and make it’s Prototype Employee object
let HREmployee = Object.create(Employee, {
    "Location": {
        value: "Alexandria"
    }
});

//& --  Test prototype chain in console for HREmployee and Employee objects  
console.log(HREmployee.__proto__)
console.log(Employee.__proto__)

//& -- Try to access person ID and Person Name using HREmployee object - 
console.log("Person ID from HREmployee", HREmployee.ID)
console.log("Person Name from HREmployee", HREmployee.Name)

//& -- Define Name And ID Properties with values For HREmployee Object then test if it 
//& accessible with person object  
Object.defineProperties(HREmployee, {
    "Name":{
        value: "Halem"
    },
    "ID":{
        value: 1234
    }
})
console.log(person.Name, person.ID)
//& -- Define Age Property with Person Object and test if it accessible with HREmployee Object 
Object.defineProperty(person, "Age", {
    value: 24
})
console.log(HREmployee.Age)
//& --After Try previous, try create the previous objects again but using defineProperties to 
//& create each object proporty

