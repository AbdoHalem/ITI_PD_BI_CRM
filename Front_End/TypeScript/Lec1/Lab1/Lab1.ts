//& ==================== Task 1 ====================
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

//& ==================== Task 2 ====================
class Point2D{
    // Properties for x and y coordinates
    x: number;
    y: number;
    // Constructor to initialize the coordinates
    constructor(x: number, y: number){
        this.x = x;
        this.y = y;
    }
    // Method to calculate the distance between current point and another Point2D
    calculateLength(otherPoint: Point2D): number{
        let deltaX = this.x - otherPoint.x;
        let deltaY = this.y - otherPoint.y;
        return Math.sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}
 let p1: Point2D = new Point2D(0, 0);
 let p2: Point2D = new Point2D(3, 4);
 console.log(`Distance between p1 and p2: ${p1.calculateLength(p2)}`);

//& ==================== Task 3 ====================
class Point3D extends Point2D{
    z: number;

    constructor(x: number, y: number, z: number){
        super(x, y);    //* Call parent constructor
        this.z = z;
    }
    // Overloading or creating a new method to calculate length with 3 points
    calculateLength(otherPoint: Point3D): number {
        let deltaX = this.x - otherPoint.x;
        let deltaY = this.y - otherPoint.y;
        let deltaZ = this.z - otherPoint.z;
        return Math.sqrt(Math.pow(deltaX, 2) + Math.pow(deltaY, 2) + Math.pow(deltaZ, 2));
    }
}

let p3: Point3D = new Point3D(0, 0, 0);
let p4: Point3D = new Point3D(3, 4, 5);
console.log(`Distance between p3 and p4: ${p3.calculateLength(p4)}`);
