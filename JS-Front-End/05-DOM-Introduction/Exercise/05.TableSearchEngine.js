function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const searchText = document.getElementById('searchField').value;
      const tableCells = document.querySelectorAll('table tbody td');
      const tableCellsArray = Array.from(tableCells);

      tableCellsArray.forEach(x => x.parentElement.className = '');

      for (let cell of tableCellsArray) {
         if (cell.textContent.includes(searchText)) {
            let tableRowOfCurrentCell = cell.parentElement;
            tableRowOfCurrentCell.className = 'select';
         }
      }
   }
}