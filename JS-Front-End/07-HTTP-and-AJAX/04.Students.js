function attachEvents() {
    const studentsUrl = 'http://localhost:3030/jsonstore/collections/students';

    const tableBodyElement = document.querySelector('#results tbody');
    const firstNameInputElement = document.querySelector('input[name=firstName]');
    const lastNameInputElement = document.querySelector('input[name=lastName]');
    const facultyNumberInputElement = document.querySelector('input[name=facultyNumber]');
    const gradeInputElement = document.querySelector('input[name=grade]');
    const submitBtnElement = document.getElementById('submit');

    loadStudents();

    submitBtnElement.addEventListener('click', async () => {
      const firstName = firstNameInputElement.value;
      const lastName = lastNameInputElement.value;
      const facultyNumber = facultyNumberInputElement.value;
      const grade = gradeInputElement.value;

      const newStudent = { firstName, lastName, facultyNumber, grade };

      const addStudentResponse = await fetch(studentsUrl, {
          method: 'POST',
          header: { 'Content-type': 'application/json' },
          body: JSON.stringify(newStudent),
      })

      createNewStudentRow(firstName, lastName, facultyNumber, grade);

      firstNameInputElement.value = '';
      lastNameInputElement.value = '';
      facultyNumberInputElement.value = '';
      gradeInputElement.value = '';
  })

    async function loadStudents() {
        const response = await fetch(studentsUrl);
        const allStudentsObject = await response.json();

        Object.values(allStudentsObject).forEach(({ firstName, lastName, facultyNumber, grade }) => createNewStudentRow(firstName, lastName, facultyNumber, grade));
    }

    function createNewStudentRow(firstName, lastName, facultyNumber, grade) {
        const firstNameTdElement = document.createElement('td');
        const lastNameTdElement = document.createElement('td');
        const facultyNumberTdElement = document.createElement('td');
        const gradeTdElement = document.createElement('td');

        firstNameTdElement.textContent = firstName;
        lastNameTdElement.textContent = lastName;
        facultyNumberTdElement.textContent = facultyNumber;
        gradeTdElement.textContent = grade;

        const newRowElement = document.createElement('tr');
        newRowElement.appendChild(firstNameTdElement);
        newRowElement.appendChild(lastNameTdElement);
        newRowElement.appendChild(facultyNumberTdElement);
        newRowElement.appendChild(gradeTdElement);

        tableBodyElement.appendChild(newRowElement);  
    }  
}

attachEvents();