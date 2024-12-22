function lockedProfile() {
    const buttonElements = document.querySelectorAll('.profile button');
    
    Array.from(buttonElements).forEach(x => x.addEventListener('click', (event) => {
        const hiddenInfoElement = event.target.parentElement.querySelector('.profile div');
        const lockCheckbox = event.target.parentElement.querySelector('input[value="lock"]');

        if (!lockCheckbox.checked && event.target.textContent == 'Show more') {
            hiddenInfoElement.style.display = 'block';
            event.target.textContent = 'Hide it';    
        } else if (!lockCheckbox.checked && event.target.textContent == 'Hide it') {
            hiddenInfoElement.style.display = 'none';
            event.target.textContent = 'Show more';    
        }
    }))
}