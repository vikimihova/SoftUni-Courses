function encodeAndDecodeMessages() {
    const textareaElements = document.querySelectorAll('textarea');
    const senderTextarea = textareaElements[0];
    const receiverTextarea = textareaElements[1];

    const buttonElements = document.querySelectorAll('button');
    const sendButton = buttonElements[0];
    const receiveButton = buttonElements[1];

    sendButton.addEventListener('click', (event) => {
        let message = senderTextarea.value;

        let encodedMessage = Array.from(message).map((character) => {
            let charValue = character.charCodeAt(0);
            return String.fromCharCode(charValue + 1);
        })

        senderTextarea.value = '';
        receiverTextarea.value = encodedMessage.join('');
    })

    receiveButton.addEventListener('click', (event) => {
        let encodedMessage = receiverTextarea.value;

        let decodedMessage = Array.from(encodedMessage).map((character) => {
            let charValue = character.charCodeAt(0);
            return String.fromCharCode(charValue - 1);
        })

        receiverTextarea.value = decodedMessage.join('');
    })



}