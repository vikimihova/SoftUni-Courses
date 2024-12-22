function attachGradientEvents() {
    const gradientElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (event) => {
        let currentProgress = event.offsetX;
        const totalProgress = event.target.clientWidth;

        resultElement.textContent = `${Math.floor(currentProgress / totalProgress * 100)}%`;
    })    
}