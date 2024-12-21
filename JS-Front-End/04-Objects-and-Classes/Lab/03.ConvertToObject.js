function solve(input) {
    let person = JSON.parse(input);
    let entries = Object.entries(person);
    entries.forEach(([key, value]) => console.log(`${key}: ${value}`));
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');