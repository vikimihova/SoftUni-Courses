function solve(employeeNames) {
    class Employee {
        constructor(name) {
            this.name = name;
            this.personalNumber = name.length;
        }
    }

    for (let name of employeeNames) {
        let currentEmployee = new Employee(name);
        console.log(`Name: ${currentEmployee.name} -- Personal Number: ${currentEmployee.personalNumber}`);
    }
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
);