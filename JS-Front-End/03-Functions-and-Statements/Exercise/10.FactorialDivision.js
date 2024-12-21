function solve(num1, num2) {
    let factorial1 = calculateFactorial(num1);
    let factorial2 = calculateFactorial(num2);

    console.log(`${(factorial1/factorial2).toFixed(2)}`);

    function calculateFactorial(num) {
        let factorial = 1;
        for (let i = 1; i <= num; i++) {
            factorial *= i;
        }
        return factorial;
    }
}

solve(5, 2);
solve(6, 2);