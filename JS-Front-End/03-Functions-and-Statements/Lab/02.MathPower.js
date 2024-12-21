function solve(number, power) {
    let result = number;

    function raiseNumber(result) {
        return result * number;
    }

    for (let i = 1; i < power; i++) {
        result = raiseNumber(result);
    }

    console.log(result);
}

solve(2,8);
solve(3,4);