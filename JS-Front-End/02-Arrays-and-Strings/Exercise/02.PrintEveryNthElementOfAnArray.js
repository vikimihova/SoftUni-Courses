function solve(array, n) {
    let printedArray = [];

    for (let i = 0; i < array.length; i += n) {
        printedArray.push(array[i]);
    }

    return printedArray;
}

solve(['5', '20', '31', '4', '20'], 2);