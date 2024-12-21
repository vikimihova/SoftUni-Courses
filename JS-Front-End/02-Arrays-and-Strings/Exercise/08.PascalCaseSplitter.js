function solve(input) {
    let pattern = /[A-Z][a-z]*/g;
    let matches = input.match(pattern);

    console.log(matches.join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');