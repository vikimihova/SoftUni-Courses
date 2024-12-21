function solve(line) {
    let wordPool = line.toLowerCase().split(' ');

    let wordCounter = {};

    for (let word of wordPool) {
        if(wordCounter[word]){
            wordCounter[word]++;
        } else {
            wordCounter[word] = 1;
        }
    }

    let allWordCounts = Object.entries(wordCounter);
    let result = [];
    allWordCounts.filter(word => word[1] % 2 != 0).forEach(word => result.push(word[0]));

    console.log(result.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');