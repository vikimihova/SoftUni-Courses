function solve(num1, num2, operation) {
    let result = generateOperation(operation)(num1, num2);

    console.log(result);

    function generateOperation(operation) {
        switch(operation) {
            case 'multiply':
                return (a, b) => a * b;
            case 'divide': 
                return (a, b) => a / b;
            case 'add':
                return (a, b) => a + b;
            case 'subtract':
                return (a, b) => a - b;
        }
    }
}

solve(5, 5, 'multiply');
solve(40, 8, 'divide');
solve(12, 19, 'add');
solve(50, 13, 'subtract');