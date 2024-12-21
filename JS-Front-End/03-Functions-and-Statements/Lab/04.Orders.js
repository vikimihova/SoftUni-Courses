function solve(product, quantity) {
    let finalPrice = getSinglePrice(product) * quantity;
    console.log(finalPrice.toFixed(2));

    function getSinglePrice(product) {
        switch(product) {
            case 'water':
                return 1.00;
            case 'coffee':
                return 1.50;
            case 'coke':
                return 1.40;
            case 'snacks':
                return 2.00;
        }
    }
}

solve("water", 5);
solve("coffee", 2);