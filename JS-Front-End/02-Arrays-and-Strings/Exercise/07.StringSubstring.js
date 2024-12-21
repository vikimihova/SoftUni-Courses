function solve(wantedWord, text) {
    const splitPattern = /\s+/g;
    const words = text.toLowerCase().split(splitPattern);

    if(words.includes(wantedWord.toLowerCase())) {
        console.log(wantedWord);
    } else {
        console.log(`${wantedWord} not found!`);
    }
}

solve('javascrIpt', 'JavaScript is the best programming language');
solve('python', 'JavaScript is the pythonbest programming language');