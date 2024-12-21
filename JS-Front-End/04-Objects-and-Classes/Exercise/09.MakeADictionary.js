function solve(arrJSON) {
    let dictionary = {};

    for (let strJSON of arrJSON) {
        let currentObj = JSON.parse(strJSON);

        let objEntries = Object.entries(currentObj);
        let currentTerm = objEntries[0][0];
        let currentDefinition = objEntries[0][1];

        dictionary[currentTerm] = currentDefinition;
    }

    let entries = Object.entries(dictionary).sort((a, b) => a[0].localeCompare(b[0]));

    entries.forEach(entry => console.log(`Term: ${entry[0]} => Definition: ${entry[1]}`));
}

solve([
    '{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}',
    '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."} ',
    '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."} ',
    '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."} ',
    '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."} '
    ]
);