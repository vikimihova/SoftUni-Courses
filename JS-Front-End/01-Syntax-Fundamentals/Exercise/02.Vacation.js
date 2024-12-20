function solve(num, groupType, weekday) {
    let pricePerPerson;
    let fullPrice;

    if (groupType === 'Students') {      

        switch(weekday) {
            case 'Friday':
                pricePerPerson = 8.45;
                break;
            case 'Saturday':
                pricePerPerson = 9.80;
                break;
            case 'Sunday':
                pricePerPerson = 10.46;
                break;
        }

        fullPrice = num * pricePerPerson;

        if (num >= 30) {
            fullPrice = fullPrice * 0.85;
        }

    } else if (groupType === 'Business') {

        switch(weekday) {
            case 'Friday':
                pricePerPerson = 10.90;
                break;
            case 'Saturday':
                pricePerPerson = 15.60;
                break;
            case 'Sunday':
                pricePerPerson = 16;
                break;
        }       
        
        fullPrice = num * pricePerPerson;

        if (num >= 100) {
            fullPrice = (num - 10) * pricePerPerson;
        }

    } else if (groupType === 'Regular') {
        
        switch(weekday) {
            case 'Friday':
                pricePerPerson = 15;
                break;
            case 'Saturday':
                pricePerPerson = 20;
                break;
            case 'Sunday':
                pricePerPerson = 22.50;
                break;
        }        

        fullPrice = num * pricePerPerson;

        if (num >= 10 && num <= 20) {
            fullPrice = fullPrice * 0.95;
        }

    }

    console.log(`Total price: ${fullPrice.toFixed(2)}`);
}

solve(40, 'Regular', 'Saturday');