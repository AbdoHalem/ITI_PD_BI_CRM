//& 4- Create an electric car object and experiment with calling ‘acceleracte ‘,’brake’ and ‘chargeBattery’ 
//& (charge to 90%). Notice what  happens when you ‘ accelerate  
//& DATA CAR 1 :’ Tesla’  going at 120 km/h , with a charge  of 23%

import { EVCar } from "./EVCAR_Module.js";

let electricCar = new EVCar("Tesla", 100, 90);

electricCar.accelerate();