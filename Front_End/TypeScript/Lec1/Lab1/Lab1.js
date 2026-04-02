"use strict";
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
