function toggle() {
    const buttonElement = document.querySelector('span.button');
    const hiddenTextElement = document.getElementById('extra');

    if (buttonElement.textContent === 'More') {
        hiddenTextElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else {
        hiddenTextElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}