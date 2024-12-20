function solve(day, age){

    let price;

    if(age >= 0 && age <= 18){

        switch(day){
            case 'Weekday':
                price = 12;
                break;
            case 'Weekend':
                price = 15;
                break;
            case 'Holiday':
                price = 5;
                break;
        }

    } else if (age >= 19 && age <= 64) {

        switch(day){
            case 'Weekday':
                price = 18;
                break;
            case 'Weekend':
                price = 20;
                break;
            case 'Holiday':
                price = 12;
                break;
        }

    } else if (age >= 65 && age <= 122) {

        switch(day){
            case 'Weekday':
                price = 12;
                break;
            case 'Weekend':
                price = 15;
                break;
            case 'Holiday':
                price = 10;
                break;
        }

    } else {
        console.log('Error!');
        return;
    }

    console.log(price + '$')
}

solve('Weekday', -3);