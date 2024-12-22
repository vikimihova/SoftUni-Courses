function generateReport() {
    const checkboxElements = document.querySelectorAll('th input');
    const rowElements = document.querySelectorAll('table tbody tr');
    const outputElement = document.getElementById('output');

    const checkboxElementsArray = Array.from(checkboxElements);
    const rowElementsArray = Array.from(rowElements);

    const rowObjectsArray = rowElementsArray
        .map(rowElement => {            
            let rowObject = {};

            let cells = rowElement.children;            
            for (let i = 0; i < cells.length; i++) {
                if (checkboxElementsArray[i].checked) {
                    let columnName = checkboxElementsArray[i].getAttribute('name');
                    rowObject[columnName] = cells[i].textContent;
                }
            }

            return rowObject;
        })

    outputElement.value = JSON.stringify(rowObjectsArray, null, 2);
}