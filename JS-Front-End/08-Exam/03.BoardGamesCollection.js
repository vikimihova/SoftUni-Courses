function solve() {
    const gamesUrl = `http://localhost:3030/jsonstore/games`;

    // get all Buttons Load, Add and Edit
    const loadBtn = document.getElementById('load-games');
    const addBtn = document.getElementById('add-game');
    const editBtn = document.getElementById('edit-game');

    // get input fields
    const gameNameField = document.getElementById('g-name');
    const gameTypeField = document.getElementById('type');
    const maxPlayersField = document.getElementById('players');

    // get div games-list
    const divGamesList = document.getElementById('games-list');

    // declare currentId null
    let currentId = null;

    // load all Games external function
    const loadGames = async () => {
        // fecth all games
        const response = await fetch(gamesUrl);
        const allGamesObject = await response.json();

        // clear DOM Div ELement
        divGamesList.innerHTML = '';

        // add each game to games-list
        for (let game of Object.values(allGamesObject)) {
            // get games parameters
            const gameName = game.name;
            const gameType = game.type;
            const maxPlayers = game.players;
            const gameId = game._id;

            // console.log(gameName);
            // console.log(gameType);
            // console.log(maxPlayers);
            // console.log(gameId);
            // console.log('\n');

            // create game div element
            const divClassBoardGame = document.createElement('div');
            divClassBoardGame.classList.add('board-game');
            //that consists of
            const divClassContent = document.createElement('div');
            divClassContent.classList.add('content');
            //and
            const divClassButtonsContainer = document.createElement('div');
            divClassButtonsContainer.classList.add('buttons-container');


            // populate the divClassContent with
            const gameNamePar = document.createElement('p');
            gameNamePar.textContent = gameName;
            const gameTypePar = document.createElement('p');
            gameTypePar.textContent = gameType;
            const maxPlayersPar = document.createElement('p');
            maxPlayersPar.textContent = maxPlayers;
            divClassContent.appendChild(gameNamePar);
            divClassContent.appendChild(gameTypePar);
            divClassContent.appendChild(maxPlayersPar);


            // populate the divButtonsContainer with
            const changeBtn = document.createElement('button');
            changeBtn.classList.add('change-btn');
            changeBtn.textContent = 'Change';
            const deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete-btn');
            deleteBtn.textContent = 'Delete';
            divClassButtonsContainer.appendChild(changeBtn);
            divClassButtonsContainer.appendChild(deleteBtn);

            // attach divClassCOntent and divClassButtonsContainer to main game div element
            divClassBoardGame.appendChild(divClassContent);
            divClassBoardGame.appendChild(divClassButtonsContainer);

            // attach main game div element to div games-list
            divGamesList.appendChild(divClassBoardGame);

            // add Event-Listner to Change Button
            changeBtn.addEventListener('click', () => {
                // set input fields values again
                gameNameField.value = gameName;
                gameTypeField.value = gameType;
                maxPlayersField.value = maxPlayers;

                // set currentId value
                currentId = gameId;

                // activate Edit Button
                editBtn.removeAttribute('disabled');

                // dectivate Add Button
                addBtn.setAttribute('disabled', 'disabled');
            })
                
            // add Event-Listener to Delete Button
            deleteBtn.addEventListener('click', async () => {
                // delete request for gameId
                await fetch(`${gamesUrl}/${gameId}`, {
                    method: 'DELETE',                    
                })

                // load all games again
                await loadGames();
            })          
        }     

        // deactivate edit Button
        editBtn.setAttribute('disabled', 'disabled');
    }      

    // set Event-Listener on Load Button (external function load Games)     
    loadBtn.addEventListener('click', loadGames);

    // set Event-Listener on Add Button
    addBtn.addEventListener('click', async () => {
        // get input values
        const gameName = gameNameField.value;
        const gameType = gameTypeField.value;
        const maxPlayers = maxPlayersField.value;

        // post a game to server
        const response = await fetch(gamesUrl, {
            method: 'POST',
            headers: { 'content-type': 'application/json' },
            body: JSON.stringify({
                name: gameName,
                type: gameType,
                players: maxPlayers,
            })
        })

        // clear input fields
        gameNameField.value = '';
        gameTypeField.value = '';
        maxPlayersField.value = '';

        // load all games again
        await loadGames();
    })
        

    // set Event-Listner on Edit Button
    editBtn.addEventListener('click', async () => {
        // get input values
        const newGameName = gameNameField.value;
        const newGameType = gameTypeField.value;
        const newMaxPlayers = maxPlayersField.value;

        console.log(newMaxPlayers);

        console.log(currentId);
        
        // Put request for gameid
        const response = await fetch(`${gamesUrl}/${currentId}`, {
            method: 'PUT',
            headers: { 'content-type': 'application/json' },
            body: JSON.stringify({
                name: newGameName,
                type: newGameType,
                players: newMaxPlayers,
                _id: currentId,
            })
        })

        // load all Games again
        await loadGames();

        // clear input fields
        gameNameField.value = '';
        gameTypeField.value = '';
        maxPlayersField.value = '';

        // gameid = null
        currentId = null;

        // deactivate edit Button
        editBtn.setAttribute('disabled', 'disabled');

        // activate add Button
        addBtn.removeAttribute('disabled');        
    })
}

solve();