function solve(num1, num2, num3) {
    let multiply = (a, b) => a * b;
    let result = multiply(multiply(num1, num2), num3);

    if (result < 0) {
        console.log('Negative');
    } else {
        console.log('Positive');
    }
}

solve(5, 12, -15);