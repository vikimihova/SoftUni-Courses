function solve(city) {
    let entries = Object.entries(city);

    entries.forEach(([key, value]) => console.log(`${key} -> ${value}`));
}

solve({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
}
);