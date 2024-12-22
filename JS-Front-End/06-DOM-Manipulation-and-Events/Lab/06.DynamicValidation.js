function validate() {
    const inputElement = document.getElementById('email');

    const validEmailPattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

    inputElement.addEventListener('change', (event) => {
        if (!validEmailPattern.test(inputElement.value)) {
            event.target.classList.add('error');
        } else {
            event.target.classList.remove('error');
        }
    })    
}