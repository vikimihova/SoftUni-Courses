function solve(input, iterations) {
    let result = '';

    for (let i = 0; i < iterations; i++) {
        result = repeatText(result)
    }

    function repeatText(text) {
        return text + input;
    }

    console.log(result);
}

solve("abc", 3);
solve("String", 2);