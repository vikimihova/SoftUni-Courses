function subtract() {
    // console.log('TODO:...');

    const num1 = document.getElementById('firstNumber').value;
    const num2 = document.getElementById('secondNumber').value;
    const divElement = document.getElementById('result');

    const result = Number(num1) - Number(num2);

    divElement.textContent = result;
}