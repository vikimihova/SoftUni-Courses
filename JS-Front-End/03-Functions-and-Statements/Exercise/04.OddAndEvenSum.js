function primitiveSolve(input) {
    let oddSum = 0;
    let evenSum = 0;
    let inputText = input.toString();
    let inputLength = inputText.length;
    let add = (a, b) => a + b;

    for (let i = 0; i < inputLength; i++) {
        determineDigitTypeSum(Number(inputText[i]));
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);

    function determineDigitTypeSum(num){
        if (num % 2 != 0) {
            oddSum = add(oddSum, num);
        } else {
            evenSum = add(evenSum, num);
        }
    }
}

function solve(number) {
    let oddSum = 0;
    let evenSum = 0;
    let positiveDigit = a => a % 2 === 0;

    while (number > 0) {
        let lastDigit = getLastDigit(number);
        number = removeLastDigit(number);

        if (positiveDigit(lastDigit)) {
            evenSum += lastDigit;
        } else {
            oddSum += lastDigit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);

    function getLastDigit(num) {
        return num % 10;
    }

    function removeLastDigit(num) {
        return (num - getLastDigit(num)) / 10;
    }
}

solve(1000435);