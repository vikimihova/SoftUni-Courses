function solve(inputNumber, ...operations) { // rest operator ...

    let number = Number(inputNumber);

    for (let i = 0; i < operations.length; i++) {
        switch(operations[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = number * 0.8;
                break;
        }

        console.log(number);
    }    
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');