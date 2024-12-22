function editElement(elementReference, match, replacer) {
    while (elementReference.textContent.includes(match)){
        elementReference.textContent = elementReference.textContent.replace(match, replacer);
    }
}
