function solve(num1, num2, num3) {
    let smallestNumber = compareTwoNumbers(compareTwoNumbers(num1, num2), num3);

    console.log(smallestNumber)

    function compareTwoNumbers(a, b) {
        if (a <= b) {
            return a;
        } else {
            return b;
        }
    }
}

solve(600, 342, -223);