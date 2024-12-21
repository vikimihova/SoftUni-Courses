function solve(stock, delivery) {
    let store = {};

    for (let i = 0; i < stock.length; i += 2) {
        store[stock[i]] = Number(stock[i + 1]);
    }

    for (let i = 0; i < delivery.length; i += 2) {
        if (store[delivery[i]]){
            store[delivery[i]] += Number(delivery[i + 1]);
        } else {
            store[delivery[i]] = Number(delivery[i + 1]);
        }        
    }

    for (let product in store) {
        console.log(`${product} -> ${store[product]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);