function solve() {
   const addButtonElements = document.querySelectorAll('button.add-product');
   const checkoutButtonElement = document.querySelector('button.checkout');
   const textareaElement = document.querySelector('textarea');

   let totalPrice = 0;
   let listOfProducts = new Set();

   Array.from(addButtonElements).forEach(x => x.addEventListener('click', (event) => {
      const productElement = event.target.parentElement.parentElement;
      const productTitle = productElement.querySelector('.product-title').textContent;
      const productPrice = Number(productElement.querySelector('.product-line-price').textContent);

      listOfProducts.add(productTitle);
      totalPrice += productPrice; 

      textareaElement.textContent += `Added ${productTitle} for ${productPrice.toFixed(2)} to the cart.\n`;
   }))

   checkoutButtonElement.addEventListener('click', (event) => {
      let products = Array.from(listOfProducts).join(', ');
      textareaElement.textContent += `You bought ${products} for ${totalPrice.toFixed(2)}.`;

      Array.from(addButtonElements).forEach(x => x.setAttribute('disabled', 'disabled'));
      event.target.setAttribute('disabled', 'disabled');
   })
}