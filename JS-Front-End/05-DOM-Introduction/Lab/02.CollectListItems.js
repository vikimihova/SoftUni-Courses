function extractText() {
    const listItems = document.querySelectorAll('ul li');
    const textArea = document.getElementById('result');

    for (let item of listItems) {
        textArea.value += item.textContent + '\n';
    }    
}