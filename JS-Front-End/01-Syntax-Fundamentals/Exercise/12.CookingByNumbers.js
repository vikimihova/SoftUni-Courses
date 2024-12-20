function solve(inputNumber, operation1, operation2, operation3, operation4, operation5) {

    let number = Number(inputNumber);
    let operations = operation1[0] + operation2[0] + operation3[0] + operation4[0] + operation5[0];

    for (let i = 0; i < operations.length; i++) {
        switch(operations[i]) {
            case 'c':
                number /= 2;
                break;
            case 'd':
                number = Math.sqrt(number);
                break;
            case 's':
                number++;
                break;
            case 'b':
                number *= 3;
                break;
            case 'f':
                number = number * 0.8;
                break;
        }

        console.log(number);
    }    
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');