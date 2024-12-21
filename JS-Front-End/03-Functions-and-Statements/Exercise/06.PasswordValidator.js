function solve(password) {
    let isValid = true;

    if (checkLength(password) == false) {
        console.log('Password must be between 6 and 10 characters');
        isValid = false;
    } 
    
    if (checkCharacters(password) == false) {
        console.log('Password must consist only of letters and digits');
        isValid = false;
    }
    
    if (checkDigits(password) == false) {
        console.log('Password must have at least 2 digits');
        isValid = false;
    } 
    
    if (isValid) {
        console.log('Password is valid')
    }

    function checkLength(password) {
        return password.length >= 6 && password.length <= 10;
    }

    function checkCharacters(password) {
        let validationPattern = /^[A-Za-z0-9]*$/;
        return validationPattern.test(password);
    }

    function checkDigits(password) {
        let digitCountPattern = /\d{1}/g;
        let matches = password.match(digitCountPattern);
        if (matches !== null) {
            return matches.length >= 2;
        } else {
            return false;
        }        
    }
}

solve('Pa$s$s');
solve('MyPass123');
solve('logIn');