function solve(input) {
    let movies = [];

    for (let line of input) {
        if (line.startsWith('addMovie')){
            let currentMovie = {
                name: line.substring('addMovie'.length + 1),
            }

            movies.push(currentMovie);

        } else if (line.includes('directedBy')) {
            let directedByIndex = line.indexOf('directedBy');
            let movieName = line.substring(0, directedByIndex - 1);
            let directorName = line.substring(directedByIndex + 'directedBy'.length + 1);

            for (let movie of movies) {
                if (movie.name == movieName) {
                    movie.director = directorName;
                }
            }

        } else if (line.includes('onDate')) {
            let onDateIndex = line.indexOf('onDate');
            let movieName = line.substring(0, onDateIndex - 1);
            let movieDate = line.substring(onDateIndex + 'onDate'.length + 1);

            for (let movie of movies) {
                if (movie.name == movieName) {
                    movie.date = movieDate;
                }
            }
        }
    }

    movies.filter(movie => movie.date && movie.director)
    .forEach(movie => console.log(JSON.stringify(movie)));
}

solve([
    'addMovie The Avengers',
    'The Avengers directedBy Anthony Russo',
    'addMovie Superman',    
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]
);