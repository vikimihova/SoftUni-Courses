function solve(fruit, grams, pricePerKilo) {

    let money = pricePerKilo * grams / 1000;

    console.log(`I need $${money.toFixed(2)} to buy ${(grams / 1000).toFixed(2)} kilograms ${fruit}.`)
}

solve('orange', 2500, 1.80);