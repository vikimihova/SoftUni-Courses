function lockedProfile() {
    const profilesUrl = 'http://localhost:3030/jsonstore/advanced/profiles';

    const mainElement = document.getElementById('main');
    const profileDivElement = document.querySelector('.profile');    

    mainElement.removeChild(profileDivElement);
    
    fetch(profilesUrl)
        .then(response => response.json())
        .then((allProfilesObject) => {
            let count = 1;

            console.log(Object.values(allProfilesObject).length);

            for (let { username, email, age } of Object.values(allProfilesObject)) {
                createNewProfile(username, email, age, count);
                count++;
            }
        }); 

    function createNewProfile(username, email, age, count) {
        const imgElement = document.createElement('img');
        imgElement.src = './iconProfile2.png';
        imgElement.classList.add('userIcon');

        const lockLabelElement = document.createElement('label');
        lockLabelElement.textContent = 'Lock';

        const lockInputType = document.createElement('input');
        lockInputType.type = 'radio';
        lockInputType.name = `user${count}Locked`;
        lockInputType.value = 'lock';
        lockInputType.checked = true;

        const unlockLabelElement = document.createElement('label');
        unlockLabelElement.textContent = 'Unlock';

        const unlockInputType = document.createElement('input');
        unlockInputType.type = 'radio';
        unlockInputType.name = `user${count}Locked`;
        unlockInputType.value = 'unlock';

        const newLineElement = document.createElement('hr');

        const usernameLabelElement = document.createElement('label');
        usernameLabelElement.textContent = 'Username';

        const usernameInputType = document.createElement('input');
        usernameInputType.type = 'text';
        usernameInputType.name = `user${count}Username`;
        usernameInputType.value = '';
        usernameInputType.disabled = true;
        usernameInputType.readOnly = true;



        const newLineElement2 = document.createElement('hr');

        const emailLabelElement = document.createElement('label');
        emailLabelElement.textContent = 'Email:';

        const emailInputType = document.createElement('input');
        emailInputType.type = 'email';
        emailInputType.name = `user${count}Email`;
        emailInputType.value = '';
        emailInputType.disabled = true;
        emailInputType.readOnly = true;

        const ageLabelElement = document.createElement('label');
        ageLabelElement.textContent = 'Age:';

        const ageInputType = document.createElement('input');
        ageInputType.type = 'text';
        ageInputType.name = `user${count}Age`;
        ageInputType.value = '';
        ageInputType.disabled = true;
        ageInputType.readOnly = true;

        const divHiddenElements = document.createElement('div');
        divHiddenElements.classList.add(`user${count}Username`);
        divHiddenElements.classList.add('hiddenInfo');

        divHiddenElements.appendChild(newLineElement2);
        divHiddenElements.appendChild(emailLabelElement);
        divHiddenElements.appendChild(emailInputType);
        divHiddenElements.appendChild(ageLabelElement);
        divHiddenElements.appendChild(ageInputType);




        const buttonElement = document.createElement('button');
        buttonElement.textContent = 'Show more';

        const profileDivElement = document.createElement('div');
        profileDivElement.classList.add('profile');
        profileDivElement.appendChild(imgElement);
        profileDivElement.appendChild(lockLabelElement);
        profileDivElement.appendChild(lockInputType);
        profileDivElement.appendChild(unlockLabelElement);
        profileDivElement.appendChild(unlockInputType);
        profileDivElement.appendChild(newLineElement);
        profileDivElement.appendChild(usernameLabelElement);
        profileDivElement.appendChild(usernameInputType);
        profileDivElement.appendChild(divHiddenElements);
        profileDivElement.appendChild(buttonElement);


        usernameInputType.value = username;
        emailInputType.value = email;
        ageInputType.value = age;      
        
        buttonElement.addEventListener('click', (event) => {
            if (!lockInputType.checked && event.target.textContent == 'Show more') {
                divHiddenElements.classList.remove('hiddenInfo');
                event.target.textContent = 'Hide it';    
            } else if (!lockInputType.checked && event.target.textContent == 'Hide it') {
                divHiddenElements.classList.add('hiddenInfo');
                event.target.textContent = 'Show more';    
            }
        })

        mainElement.appendChild(profileDivElement);
    }
}