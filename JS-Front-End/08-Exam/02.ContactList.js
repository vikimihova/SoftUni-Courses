window.addEventListener("load", solve);

function solve() {
  // get input fields
  const nameInputField = document.getElementById('name');
  const phoneInputField = document.getElementById('phone');
  const categoryInputField = document.getElementById('category');

  // get Add Button
  const addButton = document.getElementById('add-btn');

  // get Ul check-list
  const checkListUlElement = document.getElementById('check-list');

  // get Ul contact-list
  const contactListUlElement = document.getElementById('contact-list'); 
  
  // add Event-Listener on Add Button
  addButton.addEventListener('click', () => {
      // get input values
      const contactName = nameInputField.value;
      const phone = phoneInputField.value;  
      const category = categoryInputField.value;

      // check if input is an empty string, do nothing
      if (!contactName || !phone || !category) {
          return;
      }
      
      // add li Element in check-list
      const liElement = document.createElement('li');

      const articleElement = document.createElement('article');
      const namePElement = document.createElement('p');
      namePElement.textContent = `name:${contactName}`;
      const phonePElement = document.createElement('p');
      phonePElement.textContent = `phone:${phone}`;
      const categoryPElement = document.createElement('p');
      categoryPElement.textContent = `category:${category}`;
      articleElement.appendChild(namePElement);
      articleElement.appendChild(phonePElement);
      articleElement.appendChild(categoryPElement);

      const buttonsDivElement = document.createElement('div');
      buttonsDivElement.classList.add('buttons');
      const editBtn = document.createElement('button');
      editBtn.classList.add('edit-btn');
      const saveBtn = document.createElement('button');
      saveBtn.classList.add('save-btn');
      buttonsDivElement.appendChild(editBtn);
      buttonsDivElement.appendChild(saveBtn);

      liElement.appendChild(articleElement);
      liElement.appendChild(buttonsDivElement);

      checkListUlElement.appendChild(liElement);   
      
      // clear input values
      nameInputField.value = '';
      phoneInputField.value = '';
      categoryInputField.value = '';

      // add Event/Listener on Edit Button
      editBtn.addEventListener('click', () => {
          // set input values
          nameInputField.value = contactName;
          phoneInputField.value = phone;
          categoryInputField.value = category;
    
          // delete Li Element from Ul
          liElement.remove();
      });              

      // add Event/Listener on Save Button
      saveBtn.addEventListener('click', () => {
          // delete Edit and Save Buttons
          buttonsDivElement.remove();

          // add Delete Button
          const deleteBtn = document.createElement('button');
          deleteBtn.classList.add('del-btn');
          liElement.appendChild(deleteBtn);                        

          // move contact to Ul contact-list
          contactListUlElement.appendChild(liElement);

          // add Event-Listener on Delete Button
          deleteBtn.addEventListener('click', () => {
            // delete Li Element from Contact-list
            liElement.remove();            
          })
      })              
  })  
}
      
      
      
          
      

  
  

  

  



  