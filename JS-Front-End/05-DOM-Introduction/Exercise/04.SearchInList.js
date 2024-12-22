function search() {
   const listElement = document.getElementById('towns');
   const match = document.getElementById('searchText').value;
   const resultElement = document.getElementById('result');

   const townListArray = Array.from(listElement.children);

   townListArray.forEach(x => x.style.fontWeight = 'normal');
   townListArray.forEach(x => x.style.textDecoration = 'none');
   let resultsCount = 0;

   for (let townListElement of townListArray) {
      if (townListElement.textContent.includes(match)) {
         townListElement.style.textDecoration = 'underline';
         townListElement.style.textDecorationColor = 'white';
         townListElement.style.fontWeight = 'bold';

         resultsCount++;
      }
   }

   resultElement.textContent = `${resultsCount} matches found`;
}
