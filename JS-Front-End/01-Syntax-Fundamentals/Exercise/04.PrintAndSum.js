function solve(start, end) {
    let sequence = '';
    let sum = 0;

    for (let i = start; i <= end; i++) {
        sequence += i + ' ';
        sum += i;
    }   

    console.log(sequence.trimEnd());
    console.log(`Sum: ${sum}`);
}

solve(3, 8);