function RoadRadar(speed, area){
    let output = '',
        speedLimit = 0;
    
    switch (area.toLowerCase()) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break; 
        case 'residential':
            speedLimit = 20;
            break;
    }

    if (speed > speedLimit) {
        let overSpeed = speed - speedLimit,
            severity = '';
        
        if (overSpeed <= 20){
            severity = 'speeding';
        } else if (overSpeed <= 40){
            severity = 'excessive speeding';
        } else {
            severity = 'reckless driving';
        }

        output = `The speed is ${overSpeed} km/h faster than the allowed speed of ${speedLimit} - ${severity}`;
    } else {
        output = `Driving ${speed} km/h in a ${speedLimit} zone\n`;
    }

    return output;
}

console.log(RoadRadar(40, 'city'));
console.log(RoadRadar(21, 'residential'));
console.log(RoadRadar(120, 'interstate'));
console.log(RoadRadar(200, 'motorway'));