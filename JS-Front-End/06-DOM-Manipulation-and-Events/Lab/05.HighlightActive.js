function focused() {
    const inputElements = document.querySelectorAll('input[type="text"]');
    const inputElementArray = Array.from(inputElements);

    inputElementArray.forEach(x => x.addEventListener('focus', (event) => {
        event.target.parentElement.setAttribute('class', 'focused');
    }))

    inputElementArray.forEach(x => x.addEventListener('blur', (event) => {
        event.target.parentElement.classList.remove('focused');
    }))
}