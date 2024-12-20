function solve(num) {
    let numberText = num.toString();
    let firstDigit = numberText[0];
    let sum = Number(firstDigit);
    let areEqual = true;

    for (let i = 1; i < numberText.length; i++) {
        sum += Number(numberText[i]);

        if (numberText[i] != firstDigit) {
            areEqual = false;
        }
    }

    console.log(areEqual);
    console.log(sum);
}

solve(2222);