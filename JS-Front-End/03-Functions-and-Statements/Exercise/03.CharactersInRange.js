function solve(char1, char2) {
    let characters = [];

    if (char1 > char2) {
        characters = getCharacters(char2, char1);
    } else {
        characters = getCharacters(char1, char2);
    }

    console.log(characters.join(' '))

    function getCharacters(start, end) {
        let characters = [];
        for (let i = start.charCodeAt(0) + 1; i < end.charCodeAt(0); i++) {
            characters.push(String.fromCharCode(i));
        }

        return characters;
    }
}

solve('a','d');
solve('#',':');