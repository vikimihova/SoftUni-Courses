function solve(number) {
    if (number < 100) {
        console.log(`${number}% ` + generatePercentageBar(number));
        console.log('Still loading...');        
    } else {
        console.log('100% Complete!');
        console.log(generatePercentageBar(number))
    }

    function generatePercentageBar(number) {
        return `[${('%'.repeat(number/10)).padEnd(10, '.')}]`;
    }
}

solve(30);