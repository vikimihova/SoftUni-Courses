class Vehicle {
    #parts = {};

    constructor(type, model, parts, fuel) {
        this.type = type;
        this.model = model;
        this.parts = parts;
        this.fuel = Number(fuel);
    }

    set parts(value) {
        this.#parts = {
            engine: value.engine,
            power: value.power,
            quality: value.engine * value.power,
        }
    }

    get parts() {
        return this.#parts;
    }

    drive(fuelLoss) {
        this.fuel -= fuelLoss;        
    }
}

function solve() {
    let parts = { engine: 6, power: 100 };

    let vehicle = new Vehicle('a', 'b', parts, 200);
    vehicle.drive(100);
    console.log(vehicle.fuel);
    console.log(vehicle.parts.quality); 

    
}

solve();