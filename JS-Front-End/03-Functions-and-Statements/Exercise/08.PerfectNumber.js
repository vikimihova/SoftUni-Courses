function solve(number) {
    let divisorsSum = 1;

    for (let i = 2; i <= number / 2; i++) {
        if (checkProperDivisor(number, i)) {
            divisorsSum += i;
        }
    }

    if (number === divisorsSum) {
        console.log("We have a perfect number!");
    } else {
        console.log("It's not so perfect.");
    }   
    

    function checkProperDivisor(num, divisor) {
        return num % divisor == 0;
    }
}

solve(1236498);