function solve(speed, area) {

    let speedLimit;
    let difference;
    let speedStatus;

    switch (area){
        case 'motorway': speedLimit = 130; break;
        case 'interstate': speedLimit = 90; break;
        case 'city': speedLimit = 50; break;
        case 'residential': speedLimit = 20; break;
    }

    difference = speed - speedLimit;

    if (difference <= 20){
        speedStatus = 'speeding';
    } else if (difference <= 40) {
        speedStatus = 'excessive speeding';
    } else {
        speedStatus = 'reckless driving';
    }

    if (difference <= 0) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${speedStatus}`);
    }
}

solve(40, 'city');
solve(120, 'interstate');