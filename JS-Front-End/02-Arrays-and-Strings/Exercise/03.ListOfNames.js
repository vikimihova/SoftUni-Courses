function solve(names) {
    let sortedNames = names.sort((a, b) => a.localeCompare(b));

    for (let i = 0; i < sortedNames.length; i++) {
        let runningNumber = i + 1;
        console.log(runningNumber + '.' + sortedNames[i]);
    }
}

solve(["John", "Bob", "christina", "Ema"]);