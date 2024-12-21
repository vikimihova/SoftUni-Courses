function solve(wordsPool) {
    let wordsToFind = wordsPool.shift().split(' ');

    let wordCounter = {};

    for (let word of wordsToFind) {
        wordCounter[word] = 0;
    }

    for (let word of wordsPool) {
        if (wordsToFind.includes(word)) {
            wordCounter[word] += 1;
        }
    }

    let wordCounterArray = Object.entries(wordCounter);

    wordCounterArray.sort((a, b) => b[1] - a[1]).forEach(word => console.log(`${word[0]} - ${word[1]}`));
}

solve(['is the', 'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']);