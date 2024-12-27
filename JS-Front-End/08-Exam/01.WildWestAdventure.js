function solve(input) {
    let numberOfGunslingers = Number(input.shift());
    let posse = {};

    for (let i = 0; i < numberOfGunslingers; i++) {
        const [name, hp, bullets] = input.shift().split(' ');
        posse[name] = { hp: Number(hp), bullets: Number(bullets) };
    }    

    let command = input.shift();

    while (command !== 'Ride Off Into Sunset') {
        const [action, name, ...args] = command.split(' - ');
        const gunslinger = posse[name];

        if (action == 'FireShot') {
            const target = args[0];

            if (gunslinger.bullets > 0) {
                gunslinger.bullets--;
                console.log(`${name} has successfully hit ${target} and now has ${gunslinger.bullets} bullets!`);
            } else {
                console.log(`${name} doesn't have enough bullets to shoot at ${target}!`);
            }
        } 
        
        if (action == 'TakeHit') {
            const damage = Number(args[0]);
            const attacker = args[1];

            gunslinger.hp -= damage;

            if (gunslinger.hp > 0) {
                console.log(`${name} took a hit for ${damage} HP from ${attacker} and now has ${gunslinger.hp} HP!`);
            } else {
                delete posse[name];
                console.log(`${name} was gunned down by ${attacker}!`);
            }
        } 
        
        if (action == 'PatchUp') {
            const amount = Number(args[0]);

            if (gunslinger.hp == 100) {
                console.log(`${name} is in full health!`);
            } else if ((amount + gunslinger.hp) >= 100) {
                console.log(`${name} patched up and recovered ${100 - gunslinger.hp} HP!`);
                gunslinger.hp = 100;
            } else {
                console.log(`${name} patched up and recovered ${amount} HP!`);
                gunslinger.hp += amount;
            }
        } 
        
        if (action == 'Reload') {
            if (gunslinger.bullets < 6) {
                console.log(`${name} reloaded ${6 - gunslinger.bullets} bullets!`);
                gunslinger.bullets = 6;
            } else {
                console.log(`${name}'s pistol is fully loaded!`);
            }
        }

        command = input.shift();
    }

    for (let gunslinger of Object.keys(posse)) {
        console.log(gunslinger);
        console.log(` HP: ${posse[gunslinger].hp}`);
        console.log(` Bullets: ${posse[gunslinger].bullets}`);
    } 
}

solve((["2",
"Jesse 100 4",
"Walt 100 5",
"FireShot - Jesse - Bandit",
 "TakeHit - Walt - 30 - Bandit",
 "PatchUp - Walt - 20" ,
 "Reload - Jesse",
 "Ride Off Into Sunset"]));