function solve(townsArray) {
    for (let townEntry of townsArray) {
        let [townsName, latitudeValue, longitudeValue] = townEntry.split(' | ');

        let currentTown = {
            town: townsName,
            latitude: Number(latitudeValue).toFixed(2),
            longitude: Number(longitudeValue).toFixed(2),
        }

        console.log(currentTown);
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);