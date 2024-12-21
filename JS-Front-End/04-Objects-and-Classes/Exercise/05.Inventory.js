function solve(input) {
    let heroes = [];

    for (let line of input) {
        let [name, levelValue, ...itemsArray] = line.split(' / ');

        let currentHero = {
            name,
            level: Number(levelValue),
            items: itemsArray[0].split(', '),
        }

        heroes.push(currentHero);
    }

    for (let hero of heroes.sort((a, b) => a.level - b.level)) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);
    }
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);