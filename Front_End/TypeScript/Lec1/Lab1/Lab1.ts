//? Task a
// Declaring variables with specific types
let employeeName: string = "Abdo";
let employeeAge: number = 24;
let isEmployed: boolean = true;

// Declaring an array of strings
let programmingLanguages: string[] = ["JavaScript", "C#", "TypeScript"];

// employeeName = 100; // Error: Type 'number' is not assignable to type 'string'.

//? Task b
// Defining a variable that can be either a string or a number
let studentId: string | number;

// Both assignments are completely valid
studentId = 12345;
studentId = "ITI-56789";

// We can also use it in arrays
let mixedArray: (string | number)[] = ["Test", 1, 2, "Demo"];

//? Task c
// This function takes two numbers and MUST return a number
function calculateDiscount(price: number, discountPercentage: number): number {
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
enum DaysOfWeek {
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

// You can also assign specific values (String Enum)
enum UserRole {
    Admin = "ADMIN",
    Instructor = "INSTRUCTOR",
    Student = "STUDENT"
}

// Using the Enums in variables
let today: DaysOfWeek = DaysOfWeek.Thursday;
let myRole: UserRole = UserRole.Student;

// Checking the value
if (myRole === UserRole.Student) {
    console.log("Welcome to the ITI Lab!");
}
