function attachEvents() {
    const loadButtonElement = document.getElementById('btnLoad');
    const createButtonElement = document.getElementById('btnCreate');   
    const phonebookUlElement = document.getElementById('phonebook');
    const personInputElement = document.getElementById('person');
    const phoneInputElement = document.getElementById('phone');

    const phonebookUrl = 'http://localhost:3030/jsonstore/phonebook';

    loadButtonElement.addEventListener('click', async () => {
        phonebookUlElement.innerHTML = '';

        const response = await fetch(phonebookUrl);
        const phonebookObject = await response.json();

        const phonebookEntries = Object.values(phonebookObject)
            .forEach(entry => {
                let person = entry.person;
                let phone = entry.phone;
                let id = entry._id;
                const entryText = `${person}: ${phone}`;

                const newButtonElement = document.createElement('button');
                newButtonElement.textContent = 'Delete';
                
                const newListItem = document.createElement('li');
                newListItem.textContent = entryText;
                newListItem.id = id;

                newListItem.appendChild(newButtonElement);
                phonebookUlElement.appendChild(newListItem);

                newButtonElement.addEventListener('click', async () => {
                    const response = await fetch(`${phonebookUrl}/${id}`, {
                         method: 'DELETE',
                    });

                    phonebookUlElement.removeChild(newListItem);
                });
            });     

        deleteButtonElements = document.querySelectorAll('.dltBtn');  
    });

    createButtonElement.addEventListener('click', async () => {
        const person = personInputElement.value;
        const phone = phoneInputElement.value;
        const entryObject = { person, phone };

        const response = await fetch(phonebookUrl, {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(entryObject),
        });
        const result = await response.json();
        const id = result._id;

        const newButtonElement = document.createElement('button');
        newButtonElement.textContent = 'Delete';
                
        const newListItem = document.createElement('li');
        newListItem.textContent = `${result.person}: ${result.phone}`;
        newListItem.id = id;

        newListItem.appendChild(newButtonElement);
        phonebookUlElement.appendChild(newListItem);

        newButtonElement.addEventListener('click', async () => {
            const response = await fetch(`${phonebookUrl}/${id}`, {
                    method: 'DELETE',
            });

            phonebookUlElement.removeChild(newListItem);
        });

        personInputElement.value = '';
        phoneInputElement.value = '';
    });
    
}

attachEvents();