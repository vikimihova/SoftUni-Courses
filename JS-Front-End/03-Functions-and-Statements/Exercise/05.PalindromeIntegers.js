function solve(array) {
    for (let number of array) {
        let digitArr = [];

        while (number > 0) {
        digitArr.push(getLastDigit(number));
        number = removeLastDigit(number);
        }

        console.log(checkPalindrome(digitArr));
    }    

    function checkPalindrome(digitArr) {
        while (digitArr.length > 1) {
            if (digitArr.shift() !== digitArr.pop()) {
                return false;
            } 
        }

        return true;
    }

    function getLastDigit(num) {
        return num % 10;
    }

    function removeLastDigit(num) {
        return (num - getLastDigit(num)) / 10;
    }
}

solve([32,2,232,1010]);