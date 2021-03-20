class Parking {
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.capacity === this.vehicles.length) {
            throw new Error('Not enough parking space.');
        }

        this.vehicles.push({ carModel, carNumber, payed: false });

        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this.vehicles.find(x => x.carNumber === carNumber);

        if (!car) {
            throw new Error('The car, you\'re looking for, is not found.');
        }

        if (car.payed === false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        let index = this.vehicles.indexOf(car);
        this.vehicles = this.vehicles.splice(index, 1);

        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this.vehicles.find(x => x.carNumber === carNumber);
 
        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }
 
        if (car.payed === true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        if (carNumber !== undefined) {
            let car = this.vehicles.find(x => x.carNumber === carNumber);

            return `${car.carModel} == ${car.carNumber} - ${car.payed ? 'Has payed' : 'Not payed'}`;
        }

        let result = [];

        result.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`);

        let sorted = this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));

        for (const car of sorted) {
            result.push(`${car.carModel} == ${car.carNumber} - ${car.payed ? 'Has payed' : 'Not payed'}`);
        }

        return result.join('\n');
    }
}

//Example input
const parking = new Parking(12);
console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());
console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));