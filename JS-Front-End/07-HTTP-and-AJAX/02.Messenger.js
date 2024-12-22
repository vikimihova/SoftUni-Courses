function attachEvents() {
    const requestsUrl = 'http://localhost:3030/jsonstore/messenger'; 

    const textareaElement = document.getElementById('messages');
    const nameElement = document.querySelector('#controls input[name=author]');
    const messageElement = document.querySelector('#controls input[name=content]');
    const submitButtonElement = document.getElementById('submit');
    const refreshButtonElement = document.getElementById('refresh');

    submitButtonElement.addEventListener('click', async () => {
        const author = nameElement.value;
        const content = messageElement.value;
        const messageObject = { author, content };

        const response = await fetch(requestsUrl, {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(messageObject),
        });

        nameElement.value = '';
        messageElement.value = '';
    })

    refreshButtonElement.addEventListener('click', async () => {
        textareaElement.textContent = '';

        const response = await fetch(requestsUrl);
        const messagesObject = await response.json();

        const messagesData = Object.values(messagesObject)
            .map(({ author, content }) => `${author}: ${content}`);

        textareaElement.textContent = messagesData.join('\n');
    })
}

attachEvents();