function solve(people) {
    let addressBook = {};

    for (let line of people) {
        let [name, address] = line.split(':');

        addressBook[name] = address;
    }
    
    let addressBookArray = Object.entries(addressBook);
    addressBookArray.sort((a, b) => a[0].localeCompare(b[0]));

    for (let line of addressBookArray) {
        console.log(`${line[0]} -> ${line[1]}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);