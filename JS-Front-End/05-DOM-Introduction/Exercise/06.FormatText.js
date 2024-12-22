function solve() {
  const inputElement = document.getElementById('input');
  const outputElement = document.getElementById('output');

  const sentencesArray = inputElement.value.split('.').filter(x => !!x);

  let paragraphsArray = [];

  for (let i = 0; i < sentencesArray.length; i++) {
    let currentIndexOfParagraphsArray = Math.floor(i / 3);

    if (i / 3 == 0 || i % 3 == 0) {
      paragraphsArray[currentIndexOfParagraphsArray] = [];      
    }

    paragraphsArray[currentIndexOfParagraphsArray] += sentencesArray[i].trim() + '. ';
  }

  for (let paragraph of paragraphsArray) {
    outputElement.innerHTML += '<p>' + `${paragraph.trim()}` + '</p>\n';
  }
}