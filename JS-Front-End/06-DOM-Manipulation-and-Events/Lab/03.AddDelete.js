function addItem() {
    const listElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    const input = inputElement.value;

    const newListItemElement = document.createElement('li');
    newListItemElement.textContent = input;    

    const deleteElement = document.createElement('a');
    deleteElement.textContent = '[Delete]';
    deleteElement.setAttribute('href', '#');

    newListItemElement.appendChild(deleteElement);
    listElement.appendChild(newListItemElement);    

    deleteElement.addEventListener('click', () => {
        newListItemElement.remove();
    })
    
    inputElement.value = '';
}