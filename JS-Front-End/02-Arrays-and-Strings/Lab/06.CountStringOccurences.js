function solve(text, searchWord) {
    let splitPattern = /\s+/g;
    let textArray = text.split(splitPattern);
    let count = 0;
    
    for (let word of textArray) {
        if (word === searchWord) {
            count++;
        }
    }

    console.log(count);
}

solve('This is a word and it also is a sentence', 'is');
solve('softuni is great place for learning new programming languages', 'softuni');