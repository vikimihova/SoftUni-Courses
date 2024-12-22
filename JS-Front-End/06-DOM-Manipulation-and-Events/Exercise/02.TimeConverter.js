function attachEventsListeners() {
    const buttonElements = document.querySelectorAll('input[type="button"]');
    const daysFieldElement = document.getElementById('days');
    const hoursFieldElement = document.getElementById('hours');
    const minutesFieldElement = document.getElementById('minutes');
    const secondsFieldElement = document.getElementById('seconds');

    Array.from(buttonElements).forEach(x => x.addEventListener('click', (event) => {
        const parentDivElement = event.target.parentElement;
        const inputFieldElement = parentDivElement.querySelector('input[type="text"]');
        const inputValue = Number(inputFieldElement.value);

        let days = 0;

        if (inputFieldElement.id == 'days') {
            days = inputValue;
        } else if (inputFieldElement.id == 'hours') {
            days = inputValue / 24;
        } else if (inputFieldElement.id == 'minutes') {
            days = inputValue / 1440;
        } else if (inputFieldElement.id == 'seconds') {
            days = inputValue / 86400;
        }

        daysFieldElement.value = days;
        hoursFieldElement.value = days * 24;
        minutesFieldElement.value = days * 1440;
        secondsFieldElement.value = days * 86400;        
    }))
}