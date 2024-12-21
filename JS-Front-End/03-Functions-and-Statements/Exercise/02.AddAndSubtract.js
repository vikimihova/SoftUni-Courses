function solve(num1, num2, num3) {
    let sum = (a, b) => a + b;
    let subtract = (a, b) => a - b;

    let result = subtract(sum(num1, num2), num3);
    console.log(result);
}

solve(23, 6, 10);