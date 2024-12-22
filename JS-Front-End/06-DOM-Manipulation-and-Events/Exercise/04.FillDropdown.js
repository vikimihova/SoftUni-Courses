function addItem() {
    const dropdownElement = document.getElementById('menu');
    const newItemTextElement = document.getElementById('newItemText');
    const newItemValueElement = document.getElementById('newItemValue');

    const newItemText = newItemTextElement.value;
    const newItemValue = newItemValueElement.value;

    let newOption = document.createElement('option');
    newOption.textContent = newItemText;
    newOption.value = newItemValue;

    dropdownElement.appendChild(newOption);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}