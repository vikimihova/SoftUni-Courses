function solve(meetingsArray) {
    let meetingsCalender = {};

    for (let entry of meetingsArray) {
        let [weekDay, name] = entry.split(' ');

        if (meetingsCalender[weekDay]) {
            console.log(`Conflict on ${weekDay}!`)
        } else {
            meetingsCalender[weekDay] = name;
            console.log(`Scheduled for ${weekDay}`);
        }
    }

    for (let weekDay in meetingsCalender) {
        console.log(`${weekDay} -> ${meetingsCalender[weekDay]}`);
        }
}

solve(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
);