function solve(n) {
    for (let i = 0; i < n; i++) {
        let currentLine = generateLine(n);
        console.log(currentLine.join(' '));
    }

    function generateLine(n) {
        let array = [];
        for (let i = 0; i < n; i++) {
            array.push(n);
        }
        return array;
    }
}

solve(3);