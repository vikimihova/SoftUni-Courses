function colorize() {
    const evenRows = document.querySelectorAll('table tr:nth-child(2n)');
    
    for (let row of evenRows) {
        row.style.backgroundColor = 'teal';
    }

    // This works too, but not in Judge:
    // evenRows.forEach(x => x.style.backgroundColor = 'teal');
}