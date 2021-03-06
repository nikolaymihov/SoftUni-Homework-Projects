function carFactory(carDetails){
    let newCar = {};

    newCar.model = carDetails.model;
    newCar.engine = createEngine(carDetails.power);
    newCar.carriage = { type: carDetails.carriage, color: carDetails.color};
    newCar.wheels = createWheels(carDetails.wheelsize);

    return newCar;
    
    function createEngine(hp){
        let engine = {};

        if (hp <= 90) {
            engine.power = 90;
            engine.volume = 1800;
        } else if (hp <= 120) {
            engine.power = 120;
            engine.volume = 2400;
        } else if (hp <= 200) {
            engine.power = 200;
            engine.volume = 3500;
        }

        return engine;
    } 

    function createWheels(wheelsize) {
        let newSize = wheelsize % 2 == 0 ? wheelsize - 1 : wheelsize;
        let wheels = new Array(4).fill(newSize);
        
        return wheels;
    }
}

console.log(carFactory({ model: 'VW Golf II',
             power: 90,
             color: 'blue',
             carriage: 'hatchback',
             wheelsize: 14 }));

console.log(carFactory({ model: 'Opel Vectra',
             power: 110,
             color: 'grey',
             carriage: 'coupe',
             wheelsize: 17 }));
           