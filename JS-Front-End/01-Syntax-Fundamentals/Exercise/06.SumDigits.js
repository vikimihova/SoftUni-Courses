function solve(num) {
    let sum = 0;

    while (num !== 0) {
        let currentDigit = num % 10;
        sum += currentDigit;

        num -= currentDigit;
        num /= 10;
    }

    console.log(sum);
}

solve(245678);