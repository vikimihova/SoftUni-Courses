function attachEvents() {
    const loadAllPostsButtonElement = document.getElementById('btnLoadPosts');
    const viewPostButtonElement = document.getElementById('btnViewPost');
    const selectElement = document.getElementById('posts');
    const selectPostTitleElement = document.getElementById('post-title');
    const selectPostBodyPElement = document.getElementById('post-body');
    const commentsUlElement = document.getElementById('post-comments');

    const postsURL = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsURL = 'http://localhost:3030/jsonstore/blog/comments';

    loadAllPostsButtonElement.addEventListener('click', () => {
        fetch(postsURL)
            .then(response => response.json())
            .then(allPosts => {
                let postKeys = Object.keys(allPosts);

                for (let key of postKeys) {
                    
                    const newOption = document.createElement('option');
                    newOption.value = key;
                    newOption.textContent = allPosts[key].title;

                    selectElement.appendChild(newOption);
                }
            });
    })

    viewPostButtonElement.addEventListener('click', async () => {
        while (commentsUlElement.firstChild) {
            commentsUlElement.removeChild(commentsUlElement.firstChild);
        }

        const postId = selectElement.value;

        const postResponse = await fetch(`${postsURL}/${postId}`);
        const post = await postResponse.json();

        selectPostTitleElement.textContent = post.title;
        selectPostBodyPElement.textContent = post.body;

        console.log(selectPostBodyPElement.textContent);
        console.log(selectPostTitleElement.textContent);

        const commentsResponse = await fetch(commentsURL);
        const allComments = await commentsResponse.json();

        let commentsValues = Object.values(allComments);

        for (let comment of commentsValues) {
            if (comment.postId == postId) {
                let newListItem = document.createElement('li');
                newListItem.textContent = comment.text;
                newListItem.id = comment.id;
                commentsUlElement.appendChild(newListItem);
            }
        }

        commentsUlElement.style.display = 'block';        
    })


}

attachEvents();