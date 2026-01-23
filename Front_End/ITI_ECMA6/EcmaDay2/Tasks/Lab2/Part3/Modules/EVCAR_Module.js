//& 1-Create  Electric Car (Called EV) as a CHILD “class”  of Car Besides a Name and Current 
//& Speed ,the EV also has the Current battery charge in % (‘charge’ property )
//& 2-Implement a ‘chargeBattery’  method which takes an arguments ‘chargeTo’ and sets the battery charge to  this value;
//& 3-Implment an ‘accelerate’ method that will  increase the car’s speed by 20, and decrease 
//& the charge by 1% ,then log  a message like this : ‘Tesla going  at 149 km/h, with a charge of 22%’;
import {Car} from "./../../Part2/Modules/Car_Module.js";
class EVCar extends Car{
    #charge = 0;
    constructor(_name, _speed, _charge){
        super(_name, _speed);
        this.ChargeBattery(_charge);
    }
    //^ Setters & Getters Methods
    ChargeBattery(chargeTo){
        if(chargeTo < 0){
            throw Error("Battery charge must be >= 0");
        }
        else{
            this.#charge = chargeTo;
        }
    }
    get_charge(){
        return this.#charge;
    }
    accelerate(){
        this.Speed += 20;
        this.#charge -= 1;
        console.log(`${this.Name} going at ${this.Speed} km/h, with a charge of ${this.#charge}%`); 
    }

}

export {EVCar};