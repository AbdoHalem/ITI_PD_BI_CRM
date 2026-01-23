//? Part 2
//& 1-Use a constructor function to implement A Car . 
//& A Car has a Name and a Speed property. The Speed property is the Current Speed of the Car in Km/h
function Car(_name, _speed){
    this.name = _name;
    this.speed = _speed;
}

//& Using Prototype to: 
//& 2- Implement an ‘accelerate’  method will increase the car’s speed by 10,and log then new speed to console;
Car.prototype.accelerate = function(){
    this.speed += 10;
    console.log(`Current speed is: ${this.speed}`);
}
//& 3-Implement a ‘brake’ method that will decrease the car’s speed by 5,and log the new speed to the console;
Car.prototype.brake = function(){
    this.speed -= 5;
    console.log(`Current speed is: ${this.speed}`);
}

//& Create 2 car objects and experiment with calling  ‘accelerate’ and ‘brake’ multiple times on each of them. 
//& DATA Car1 : ‘BMW’  going at 120 km/h 
//& DATA CARA2: ‘Mercedes’ going at 95 km/h
let BMW = new Car("BMW", 115);
let Mercedes = new Car("Mercedes", 90);

BMW.accelerate();
Mercedes.accelerate();
BMW.brake();
Mercedes.brake();

//? Part 3
//& 1-Use A constructor function to implement an Electric Car (Called EV) as a CHILD “class”  
//& of Car Besides a Name and Current Speed ,the EV also has the Current battery charge in % (‘charge’ property )
function EVCar(_name, _speed, _charge){
    Car.call(this, _name, _speed);
    this.charge = _charge;
}
//^ Make EVCar inherits from Car
EVCar.prototype = Object.create(Car.prototype);
EVCar.prototype.constructor = EVCar;

//& 2-Implement a ‘chargeBattery’  method which takes an arguments ‘chargeTo’ and sets the battery charge to  this value;
EVCar.prototype.ChargeBattery = function(chargeTo){
    this.charge = chargeTo;
}
//& 3-Implment an ‘accelerate’ method that will  increase the car’s speed by 20, and decrease 
//& the charge by 1% ,then log  a message like this : ‘Tesla going  at 149 km/h, with a charge of 22%’;
EVCar.prototype.accelerate = function(chargeTo){
    this.speed += 20;
    this.charge -= 1;
    console.log(`${this.name} is going at ${this.speed} km/h, with a charge of ${this.charge}`);
}

//& 4- Create an electric car object and experiment with calling ‘acceleracte ‘,’brake’ and ‘chargeBattery
let Tesla = new EVCar("Tesla", 100, 24);
Tesla.accelerate();
