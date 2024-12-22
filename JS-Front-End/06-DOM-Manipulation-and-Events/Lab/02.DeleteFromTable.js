function deleteByEmail() {
    const inputElement = document.querySelector('input[type="text"]');
    const cellElements = document.querySelectorAll('table tbody tr td:last-child');
    const resultElement = document.getElementById('result');
    
    const searchedValue = inputElement.value;

    const foundCellElement = Array.from(cellElements).find(x => x.textContent == searchedValue);

    if (foundCellElement) {
        foundCellElement.parentElement.remove();
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    }

    inputElement.value = '';
}