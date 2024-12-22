function create(words) {
   const mainContentElement = document.getElementById('content');

   for (let word of words) {
      const newDivElement = document.createElement('div');
      const newParagraphElement = document.createElement('p');
      newParagraphElement.textContent = word;
      newParagraphElement.style.display = 'none';

      newDivElement.appendChild(newParagraphElement);      

      newDivElement.addEventListener('click', () => {
         newParagraphElement.style.display = 'block';
      })

      mainContentElement.appendChild(newDivElement);
   }
}