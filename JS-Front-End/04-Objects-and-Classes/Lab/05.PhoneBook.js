function solve(people) {
    let phoneBook = {};

    for (let line of people) {
        let [name, phoneNumber] = line.split(' ');

        phoneBook[name] = phoneNumber;
    }

    for (let name in phoneBook) {
        console.log(`${name} -> ${phoneBook[name]}`);
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);