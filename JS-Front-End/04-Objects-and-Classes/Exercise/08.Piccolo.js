function solve(carNumberArray) {
    let parkingLot = {};
    let numberPattern = /[0-9]+/g;

    for (let line of carNumberArray) {
        let [direction, carPlate] = line.split(', ');

        if (direction == 'IN' && !parkingLot[carPlate]){
            parkingLot[carPlate] = Number(carPlate.match(numberPattern));
        }

        if (direction == 'OUT' && parkingLot[carPlate]){
            delete parkingLot[carPlate];
        }
    }

    let sortedParkingLotPlates = Object.entries(parkingLot).sort((a, b) => a[1] - b[1]);

    if (sortedParkingLotPlates.length == 0) {
        return console.log(`Parking Lot is Empty`);
    }
    
    for (let carPlate of sortedParkingLotPlates) {
        console.log(carPlate[0]);
    }
}

function solve2(carNumberArray) {
    let parkingLot = new Set();

    for (let line of carNumberArray) {
        let [direction, carPlate] = line.split(', ');

        if (direction == 'IN') {
            parkingLot.add(carPlate);
        } else {
            parkingLot.delete(carPlate);
        }
    }

    if (parkingLot.size == 0) {
        return console.log(`Parking Lot is Empty`);
    }

    Array.from(parkingLot)
    .sort((a, b) => a.localeCompare(b))
    .forEach(carPlate => console.log(carPlate));
}

solve2(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
);

solve2(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);