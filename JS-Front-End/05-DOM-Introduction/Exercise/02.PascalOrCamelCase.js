function solve() {
  const text = document.getElementById('text').value;
  const namingConvention = document.getElementById('naming-convention').value;
  const resultElement = document.getElementById('result');

  let textArray = text.toLowerCase().split('');

  let result = '';

  if (namingConvention == 'Camel Case') {

    for (let i = 0; i < textArray.length; i++) {
      if (textArray[i] == ' '){
        let nextLetter = textArray[i + 1].toUpperCase();

        textArray.splice(i, 1);

        textArray[i] = nextLetter;
      }

      result = textArray.join('');
    }

  } else if (namingConvention == 'Pascal Case') {
    let firstLetter = textArray[0].toUpperCase();
    textArray[0] = firstLetter;

    for (let i = 0; i < textArray.length; i++) {
      if (textArray[i] == ' '){
        let nextLetter = textArray[i + 1].toUpperCase();

        textArray.splice(i, 1);

        textArray[i] = nextLetter;        ;
      }

      result = textArray.join('');
    }    

  } else {
    result = 'Error!';
  }

  resultElement.textContent = result;
}