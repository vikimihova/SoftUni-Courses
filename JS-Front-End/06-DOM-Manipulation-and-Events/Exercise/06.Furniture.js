function solve() {

  const textareaElements = document.querySelectorAll('#exercise textarea');
  const inputTextarea = textareaElements[0];
  const outputTextarea = textareaElements[1];

  const buttonElements = document.querySelectorAll('#exercise button');
  const generateButton = buttonElements[0];
  const buyButton = buttonElements[1];

  const tableBodyElement = document.querySelector('table tbody');

  generateButton.addEventListener('click', () => {

    const furnitures = JSON.parse(inputTextarea.value);  
    console.log(furnitures);

    for (const furniture of furnitures) {
      let imageElement = document.createElement('img');
      imageElement.src = furniture.img;
      let imageCellElement = document.createElement('td');
      imageCellElement.appendChild(imageElement);

      let namePElement = document.createElement('p');
      namePElement.textContent = furniture.name;
      let productNameCellElement = document.createElement('td');
      productNameCellElement.appendChild(namePElement);

      let pricePElement = document.createElement('p');
      pricePElement.textContent = furniture.price;     
      let priceCellElement = document.createElement('td');
      priceCellElement.appendChild(pricePElement);

      let decFactorPElement = document.createElement('p');
      decFactorPElement.textContent = furniture.decFactor;
      let decFactorCellElement = document.createElement('td');
      decFactorCellElement.appendChild(decFactorPElement);

      let checkboxElement = document.createElement('input');
      checkboxElement.type = 'checkbox';
      let checkboxCellElement = document.createElement('td');
      checkboxCellElement.appendChild(checkboxElement);

      let newRowElement = document.createElement('tr');
      newRowElement.appendChild(imageCellElement);
      newRowElement.appendChild(productNameCellElement);
      newRowElement.appendChild(priceCellElement);
      newRowElement.appendChild(decFactorCellElement);
      newRowElement.appendChild(checkboxCellElement);

      tableBodyElement.appendChild(newRowElement);
  }});    

    buyButton.addEventListener('click', (e) => {
      let checkboxElements = document.querySelectorAll('table tbody tr td input');
      let boughtFurniture = []; //a Set instead?
      let totalPrice = 0;
      let totalDecFactor = 0;

      for (let checkbox of checkboxElements) {
        if (checkbox.checked) {
          let furnitureRowElement = checkbox.parentElement.parentElement;
          let furnitureData = furnitureRowElement.children;
          let furnitureName = furnitureData[1].querySelector('p').textContent;
          let furniturePrice = Number(furnitureData[2].querySelector('p').textContent);
          let furnitureDecFactor = Number(furnitureData[3].querySelector('p').textContent);

          boughtFurniture.push(furnitureName);
          totalPrice += furniturePrice;
          totalDecFactor += furnitureDecFactor;
        }
      }

      let avgDecFactor = totalDecFactor / boughtFurniture.length;

      outputTextarea.value += `Bought furniture: ${boughtFurniture.join(', ')}\n`;
      outputTextarea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
      outputTextarea.value += `Average decoration factor: ${avgDecFactor}`; 
    })
}