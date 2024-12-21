function solve(array) {
    array.sort((a, b) => a - b);
    let arrayMixedOrder = [];

    while (array.length > 0) {
        firstNumber = array.shift();
        lastNumber = array.pop();

        arrayMixedOrder.push(firstNumber);

        if (lastNumber) {
            arrayMixedOrder.push(lastNumber);
        }       
    }

    return arrayMixedOrder;
}

solve([1, 65, 3, 52, 52, 48, 63, 31, -3, 18, 56]);