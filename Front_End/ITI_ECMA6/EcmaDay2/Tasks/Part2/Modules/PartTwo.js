//& Create 2 car objects and experiment with calling  ‘accelerate’ and ‘brake’ multiple times on each of them. 
//& DATA Car1 : ‘BMW’  going at 120 km/h 
//& DATA CARA2: ‘Mercedes’ going at 95 km/h

import { Car } from "./Car_Module.js";

let BMW = new Car("BMW", 120);
let Mercedes = new Car("Mercedes", 95);

BMW.accelerate();
Mercedes.accelerate();
console.log(`BMW car speed: ${BMW.Speed}`);
console.log(`Mercedes car speed: ${Mercedes.Speed}`);

BMW.brake();
Mercedes.brake();
console.log(`BMW car speed: ${BMW.Speed}`);
console.log(`Mercedes car speed: ${Mercedes.Speed}`);
