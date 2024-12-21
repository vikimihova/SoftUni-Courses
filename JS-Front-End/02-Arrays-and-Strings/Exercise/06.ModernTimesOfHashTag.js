function solve(input) {
    let splitPattern = /\s+/g;
    let validWordPattern = /#([A-Za-z]+)/;

    let words = input.split(splitPattern);

    for (let word of words) {
        if (validWordPattern.test(word)) {
            const match = word.match(validWordPattern);
            let validWord = match[1];            
            console.log(validWord);
        }
    }
}

solve('The symbol # is known #variously in English-speaking #regions as the #number sign');
solve('Nowadays everyone uses # to tag a #a word in #socialMedia.');