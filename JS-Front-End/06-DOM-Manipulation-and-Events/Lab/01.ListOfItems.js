function addItem() {
    const listElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    const input = inputElement.value;

    const newListItemElement = document.createElement('li');
    newListItemElement.textContent = input;
    listElement.appendChild(newListItemElement);

    inputElement.value = '';
}