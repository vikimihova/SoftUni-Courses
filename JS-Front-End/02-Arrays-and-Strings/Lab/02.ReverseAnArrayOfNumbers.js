function solve(numberOfElements, array) {
    let newArray = [];

    for (let i = 0; i < numberOfElements; i++) {
        newArray.push(array.shift());
    }

    newArray = newArray.reverse();

    console.log(newArray.join(' '));
}

solve(3, [10, 20, 30, 40, 50]);
solve(4, [-1, 20, 99, 5]);