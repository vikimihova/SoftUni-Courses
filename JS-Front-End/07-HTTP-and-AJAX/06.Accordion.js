function solution() {
    const articleTitlesUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const articleDetailsUrl = 'http://localhost:3030/jsonstore/advanced/articles/details';

    const mainElement = document.getElementById('main');    

    getAllArticles();

    async function getAllArticles() {
        const response = await fetch(articleTitlesUrl);
        const allArticleTitlesArray = await response.json();

        console.log(allArticleTitlesArray);

        allArticleTitlesArray.forEach(article => {
            const title = article.title;
            const id = article._id;

            console.log(title);

            const titleSpanElement = document.createElement('span');
            titleSpanElement.textContent = title;

            const buttonElement = document.createElement('button');
            buttonElement.textContent = 'More';
            buttonElement.classList.add('button');
            buttonElement.id = id;

            const divHeadElement = document.createElement('div');
            divHeadElement.classList.add('head');
            divHeadElement.appendChild(titleSpanElement);
            divHeadElement.appendChild(buttonElement);

            const accordionDivElement = document.createElement('div');
            accordionDivElement.classList.add('accordion');
            accordionDivElement.appendChild(divHeadElement);

            mainElement.appendChild(accordionDivElement);

            fetch(`${articleDetailsUrl}/${id}`)
                .then(response => response.json())
                .then(({ content }) => {
                    const newPElement = document.createElement('p');
                    newPElement.textContent = content;

                    const detailsDivElement = document.createElement('div');
                    detailsDivElement.classList.add('extra');
                    detailsDivElement.appendChild(newPElement);

                    

                    accordionDivElement.appendChild(detailsDivElement);
                })         
                
            buttonElement.addEventListener('click', () => {
                const hiddenDetailsDiv = accordionDivElement.querySelector('.extra');

                if (buttonElement.textContent == 'More'){
                    hiddenDetailsDiv.style.display = 'block';    
                    buttonElement.textContent = 'Less';
                } else {
                    hiddenDetailsDiv.style.display = 'none';    
                    buttonElement.textContent = 'More';
                }                
            })
        })
    }

    
}

solution();