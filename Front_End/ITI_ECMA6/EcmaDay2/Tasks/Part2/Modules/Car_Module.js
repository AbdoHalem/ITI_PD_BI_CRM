//& Create A Car Class  has a Serial ,Name and a Speed property As private .  
//& The SerialID for car create Unique random Number for each car  
//& The Speed property is the Current Speed of the Car in Km/h
//& 2- Implement an ‘accelerate’  method will increase the car’s speed by 10,and log then new speed to console; 
//& 3-Implement a ‘brake’ method that will decrease the car’s speed by 5,and log the new speed to the console;

class Car{
    //* Private members
    #serial = 0;
    #name = 0;
    #speed = 0;
    //^ Static members
    static numCars = 0;
    constructor(_name, _speed){
        this.set_serial();
        this.Name = _name;
        this.Speed = _speed;
        Car.numCars++;
    }
    //^ Set & Get Methods
    set_serial(){
        this.#serial = Math.random() * 100 + Math.random() * 100; 
    }
    get_serial(){
        return this.#serial;
    }
    //^ Set & Get Accessories
    set Name(_val){
        this.#name = _val;
    }
    get Name(){
        return this.#name;
    }
    set Speed(_val){
        if(_val < 0){
            throw Error("Speed must be > 0!");
        }
        else{
            this.#speed = _val;
        }
    }
    get Speed(){
        return this.#speed;
    }
    //^ Methods
    accelerate(){
        this.#speed += 10;
        console.log(`New Speed is: ${this.#speed} Km/h`);
    }
    brake(){
        this.#speed -= 5;
        console.log(`New Speed is: ${this.#speed} Km/h`);
    }
    PrintCar(){
        console.log(`Serial ID of this car is: ${this.#serial}`);
        console.log(`Total number of cars is: ${Car.numCars}`);
    }
}

export {Car};