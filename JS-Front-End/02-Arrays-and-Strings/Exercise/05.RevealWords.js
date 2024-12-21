function solve(hiddenWords, text) {
    let words = hiddenWords.split(', ');
    let revealedWords = text;

    for (let i = 0; i < words.length; i++) {
        revealedWords = revealedWords.replace('*'.repeat(words[i].length), words[i]);
    }

    console.log(revealedWords);
}

solve('great, learning', 'softuni is ***** place for ******** new programming languages');