function sumTable() {
    const priceElements = document.querySelectorAll('table td:last-child:not(#sum)');
    const sumElement = document.getElementById('sum');

    let sum = 0;

    const priceElementsArray = Array.from(priceElements);
    priceElementsArray.forEach(x => sum += Number(x.textContent));

    sumElement.textContent = sum;
}