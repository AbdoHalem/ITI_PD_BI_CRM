"use strict";
//& ==================== Task 1 ====================
//? Task a
// Declaring variables with specific types
let employeeName = "Abdo";
let employeeAge = 24;
let isEmployed = true;
// Declaring an array of strings
let programmingLanguages = ["JavaScript", "C#", "TypeScript"];
// employeeName = 100; // Error: Type 'number' is not assignable to type 'string'.
//? Task b
// Defining a variable that can be either a string or a number
let studentId;
// Both assignments are completely valid
studentId = 12345;
studentId = "ITI-56789";
// We can also use it in arrays
let mixedArray = ["Test", 1, 2, "Demo"];
//? Task c
// This function takes two numbers and MUST return a number
function calculateDiscount(price, discountPercentage) {
    let discountAmount = price * (discountPercentage / 100);
    return price - discountAmount;
}
// Correct usage
let finalPrice = calculateDiscount(1000, 15);
// This will cause an error because arguments must be numbers
// calculateDiscount("1000", "15");
//? Task d
// Defining a numeric Enum for Days of the Week
// By default, Sunday is 0, Monday is 1, and so on...
var DaysOfWeek;
(function (DaysOfWeek) {
    DaysOfWeek[DaysOfWeek["Sunday"] = 0] = "Sunday";
    DaysOfWeek[DaysOfWeek["Monday"] = 1] = "Monday";
    DaysOfWeek[DaysOfWeek["Tuesday"] = 2] = "Tuesday";
    DaysOfWeek[DaysOfWeek["Wednesday"] = 3] = "Wednesday";
    DaysOfWeek[DaysOfWeek["Thursday"] = 4] = "Thursday";
    DaysOfWeek[DaysOfWeek["Friday"] = 5] = "Friday";
    DaysOfWeek[DaysOfWeek["Saturday"] = 6] = "Saturday";
})(DaysOfWeek || (DaysOfWeek = {}));
// You can also assign specific values (String Enum)
var UserRole;
(function (UserRole) {
    UserRole["Admin"] = "ADMIN";
    UserRole["Instructor"] = "INSTRUCTOR";
    UserRole["Student"] = "STUDENT";
})(UserRole || (UserRole = {}));
// Using the Enums in variables
let today = DaysOfWeek.Thursday;
let myRole = UserRole.Student;
// Checking the value
if (myRole === UserRole.Student) {
    console.log("Welcome to the ITI Lab!");
}
//& ==================== Task 2 ====================
class Point2D {
    // Properties for x and y coordinates
    x;
    y;
    // Constructor to initialize the coordinates
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    // Method to calculate the distance between current point and another Point2D
    calculateLength(otherPoint) {
        let deltaX = this.x - otherPoint.x;
        let deltaY = this.y - otherPoint.y;
        return Math.sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}
let p1 = new Point2D(0, 0);
let p2 = new Point2D(3, 4);
console.log(`Distance between p1 and p2: ${p1.calculateLength(p2)}`);
//& ==================== Task 3 ====================
class Point3D extends Point2D {
    z;
    constructor(x, y, z) {
        super(x, y); //* Call parent constructor
        this.z = z;
    }
    calculateLength(otherPoint) {
        let deltaX = this.x - otherPoint.x;
        let deltaY = this.y - otherPoint.y;
        let deltaZ = this.z - otherPoint.z;
        return Math.sqrt(Math.pow(deltaX, 2) + Math.pow(deltaY, 2) + Math.pow(deltaZ, 2));
    }
}
let p3 = new Point3D(0, 0, 0);
let p4 = new Point3D(3, 4, 5);
console.log(`Distance between p3 and p4: ${p3.calculateLength(p4)}`);
