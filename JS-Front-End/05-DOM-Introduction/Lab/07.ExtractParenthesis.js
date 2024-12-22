function extract(content) {
    const element = document.getElementById(content);
    const pattern = /\(([A-Za-z ]+)\)/g;

    const matches = element.textContent.matchAll(pattern);
    // const matchesArray = Array.from(matches);
    // const text = matchesArray.join(';');

    let text = '';

    for (let match of matches) {
        text += match[1] + '; ';
    }

    return text.trim();
}