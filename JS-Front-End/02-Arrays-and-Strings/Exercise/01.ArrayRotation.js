function solve(array, numberOfRotations) {

    for (let i = 0; i < numberOfRotations; i++) {
        let currentElement = array.shift();
        array.push(currentElement);
    }

    console.log(array.join(' '));
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);